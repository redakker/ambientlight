using MQTTnet;
using MQTTnet.Client.Options;
using System.Diagnostics;
using System.Web;

namespace AmbientLight
{
    public partial class AmbientForm : Form
    {
        Config config = null;
        public event EventHandler colorGeneratedEvent;
        MQTTService mqttService = new MQTTService();
        WebhookService webhookService = new WebhookService();


        public AmbientForm(Config config)
        {   
            this.config = config;
            
            InitializeComponent();
            this.SizeChanged += new EventHandler(AmbientForm_Resize);

            Thread background = new Thread(startAnalyzeInBackground);
            background.IsBackground = true;
            background.Start();
            
            // Set the config values on the UI
            sleepTime.Value = config.refreshFrequency;
            runningChk.Checked = config.isRunning;
            trayChk.Checked = config.minimizeToTray;
            loadMQTTSettings(config.mqtt);
            loadWebhookSettings(config.webhook);
            inputScreenMargin.Text = config.screenshotMargin.ToString();
            chkSkipDarkPixels.Checked = config.skipDarkPixels;

            displayFrequency();
            visibleMQTTInputs();
            visibleWebhhokInputs();

            // Event handling
            colorGeneratedEvent += ColorGeneratedEventHandler;
        }

        private async void ColorGeneratedEventHandler(object? sender, EventArgs e)
        {
            // We expecting a ColorEvent here
            ColorEvent colorEvent = (ColorEvent) e;

            await sendMQTT(colorEvent.color);
            await callWebhook(colorEvent.color);


            // Update the wildcards' value in the view
            updateWildcards(colorEvent.color);

        }

        private void frequencyChanged(object sender, System.EventArgs e)
        {
            displayFrequency();
        }

        private void startAnalyzeInBackground()
        {
            while (true)
            {
                if (config.isRunning)
                {
                    startAnalyze();
                }

                Thread.Sleep(config.refreshFrequency);

            }
        }
        /// <summary>
        /// This function analyzes the screen color and generate a color code and send over an event
        /// </summary>
        private void startAnalyze()
        {
            Bitmap screenshot = Utils.GetSreenshot(config);
            
            int red = 0;
            int green = 0;
            int blue = 0;
            int allPixels = 0;
            int darkPixels = 0;
            int brightPixels = 0;
            double calculatedRed;
            double calculatedGreen;
            double calculatedBlue;
            int pixelJump = 10;            

            for (int h = 0; h < screenshot.Height; h+= pixelJump)
            {
                for (int w = 0; w < screenshot.Width; w+= pixelJump)
                {
                    Color pixel = screenshot.GetPixel(w, h);

                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    bool addPixel = false;
                    if (config.skipDarkPixels)
                    {
                        if (r < Constants.DARK_PIXEL_LIMIT && g < Constants.DARK_PIXEL_LIMIT && b < Constants.DARK_PIXEL_LIMIT)
                        {
                            darkPixels++;
                        } else
                        {
                            brightPixels++;
                            addPixel = true;
                        }

                    } 
                    

                    if (!config.skipDarkPixels || addPixel)
                    {
                        // Mormal case, all pixel will be analized
                        red += r;
                        green += g;
                        blue += b;
                        allPixels++;
                    }

                }
            }

            if (allPixels == 0) { allPixels = 1; }

            calculatedRed = (double)red / allPixels;
            calculatedGreen = (double)green / allPixels;
            calculatedBlue = (double)blue / allPixels;

            // Make darker color if most of the screen surface is black
            if (brightPixels * 2 < darkPixels)
            {
                double ratio = (double)brightPixels / darkPixels;

                calculatedRed = Convert.ToInt32(calculatedRed * ratio);
                calculatedGreen = Convert.ToInt32(calculatedGreen * ratio);
                calculatedBlue = Convert.ToInt32(calculatedBlue * ratio);
            }

            Debug.WriteLine(calculatedRed + ", " + calculatedGreen + ", " + calculatedBlue);

            Color c = Color.FromArgb((int)calculatedRed, (int)calculatedGreen, (int)calculatedBlue);

            string hex = ColorTranslator.ToHtml(c);

            Debug.WriteLine("Hex color " + hex);
            Debug.WriteLine("RGB color " + (int)calculatedRed + ", " + (int)calculatedGreen + ", " + (int)calculatedBlue);
            colorPanel.BackColor = c;

            Debug.WriteLine("Timeout:" + config.refreshFrequency);

            colorGeneratedEvent.Invoke(this, new ColorEvent(c));

            // Otherwise the memory consumption is high till the normal GC running
            System.GC.Collect();
        }

        private async Task sendMQTT(Color color)
        {
            if (config.mqtt != null && config.mqtt.enabled)
            {
                if (!String.IsNullOrEmpty(config.mqtt.server))
                {
                    mqttService.createConnection(config);
                    mqttService.sendMessage(config, color);
                }
            }
        }

        private async Task callWebhook(Color color)
        {
            if (config.webhook != null && config.webhook.enabled)
            {
                if (!String.IsNullOrEmpty(config.webhook.url))
                {
                    webhookService.callWebhook(config, color);
                }
            }
        }

        private void updateWildcards(Color color)
        {
            string R = Utils.replaceWildCards("{R}", color);
            string G = Utils.replaceWildCards("{G}", color);
            string B = Utils.replaceWildCards("{B}", color);
            string HEX = Utils.replaceWildCards("{HEX}", color);
        }

        private void getColorNow_Click(object sender, EventArgs e)
        {
            startAnalyze();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
        private void AmbientForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (trayChk.Checked)
                {
                    Debug.WriteLine("Window is minimised");
                    Hide();
                    notifyIcon.Visible = true;
                }
                
            }
        }

        private void saveConfig_Click(object sender, EventArgs e)
        {
            config.refreshFrequency = sleepTime.Value;
            config.minimizeToTray = trayChk.Checked;
            config.isRunning = runningChk.Checked;            

            if (String.IsNullOrEmpty(inputScreenMargin.Text))
            {
                config.screenshotMargin = 0;
                inputScreenMargin.Text = "0";
            }

            try
            {
                config.screenshotMargin = Int32.Parse(inputScreenMargin.Text);
            }
            catch
            {
                config.screenshotMargin = 0;
                inputScreenMargin.Text = "0";
            }

            config.mqtt = getMQTTSettings();
            config.webhook = getWebhookSettings();
            Utils.ConfigToJson(this.config);
        }

        private void displayFrequency()
        {
            calculationFrequencyNumber.Text = sleepTime.Value.ToString() + " ms";
        }

        private MQTT getMQTTSettings()
        {
            MQTT mqtt = new MQTT();
            mqtt.enabled = chkMQTTEnabled.Checked;
            mqtt.server = inputMQTTserver.Text;
            mqtt.topic = inputMQTTTopic.Text;
            mqtt.clientId = inputMQTTClientId.Text;

            if (String.IsNullOrEmpty(inputMQTTClientId.Text))
            {
                mqtt.clientId = inputMQTTClientId.Text = Environment.MachineName;
            }

            try
            {
                mqtt.port = Int32.Parse(inputMQTTport.Text);
            } catch { 
                mqtt.port = Constants.MQTT_DEFAULT_PORT; 
                inputMQTTport.Text = Constants.MQTT_DEFAULT_PORT.ToString();
            }
            mqtt.message = inputMQTTMessage.Text;
            mqtt.username = inputMQTTUsername.Text;
            mqtt.password = inputMQTTPassword.Text;
            
            return mqtt;
        }

        private void loadMQTTSettings(MQTT mqtt)
        {
            if (mqtt != null)
            {
                chkMQTTEnabled.Checked = mqtt.enabled;
                inputMQTTserver.Text = mqtt.server;
                inputMQTTTopic.Text = mqtt.topic;
                inputMQTTClientId.Text = mqtt.clientId;

                inputMQTTport.Text = mqtt.port.ToString();

                inputMQTTMessage.Text = mqtt.message;
                inputMQTTUsername.Text = mqtt.username;
                inputMQTTPassword.Text = mqtt.password;

                if (!mqtt.enabled)
                {
                    inputMQTTserver.Enabled = false;
                    inputMQTTTopic.Enabled = false;
                    inputMQTTClientId.Enabled = false;

                    inputMQTTport.Enabled = false;

                    inputMQTTMessage.Enabled = false;
                    inputMQTTUsername.Enabled = false;
                    inputMQTTPassword.Enabled = false;
                }
            }
        }

        private Webhook getWebhookSettings()
        {
            Webhook webhook = new Webhook();
                        
            webhook.url = inputWebhook.Text;
            webhook.enabled = chkEnableWebhook.Checked;

            return webhook;
        }

        private void loadWebhookSettings(Webhook webhook)
        {
            if (webhook != null)
            {
                inputWebhook.Text = webhook.url;
                chkEnableWebhook.Checked = webhook.enabled;
            }
        }

        private void visibleMQTTInputs()
        {
            bool enabled = chkMQTTEnabled.Checked;

            inputMQTTserver.Enabled = enabled;
            inputMQTTTopic.Enabled = enabled;
            inputMQTTClientId.Enabled = enabled;

            inputMQTTport.Enabled = enabled;

            inputMQTTMessage.Enabled = enabled;
            inputMQTTUsername.Enabled = enabled;
            inputMQTTPassword.Enabled = enabled;
        }

        private void visibleWebhhokInputs()
        {
            bool enabled = chkEnableWebhook.Checked;

           inputWebhook.Enabled = enabled;
        }

        private void chkMQTTEnabled_CheckedChanged(object sender, EventArgs e)
        {
            visibleMQTTInputs();
        }

        private void chkEnableWebhook_CheckedChanged(object sender, EventArgs e)
        {
            visibleWebhhokInputs();
        }

        private void chkSkipDarkPixels_CheckedChanged(object sender, EventArgs e)
        {
            config.skipDarkPixels = chkSkipDarkPixels.Checked;
        }
    }
}