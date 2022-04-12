using AmbientLight.models;
using MQTTnet;
using MQTTnet.Client.Options;
using System.Diagnostics;
using System.Web;

namespace AmbientLight
{
    public partial class AmbientForm : Form
    {
        Config config;
        public event EventHandler colorGeneratedEvent;
        MQTTService mqttService = new MQTTService();
        WebhookService webhookService = new WebhookService();
        string lastColor = ""; // Prevent sending duplicates


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
            chkSkipDarkPixels.Checked = config.skipDarkPixels;
            chkDivideScreen.Checked = config.divideScreen;            
            inputSegmentNumberHorizontal.Text = config.segmentHorizontal.ToString();
            inputSegmentNumberVertical.Text = config.segmentVertical.ToString();

            displayFrequency();            
            setUI();

            // Event handling
            colorGeneratedEvent += ColorGeneratedEventHandler;
        }

        private async void ColorGeneratedEventHandler(object? sender, EventArgs e)
        {
            // We expecting a ColorEvent here
            ColorEvent colorEvent = (ColorEvent) e;

            string hex = Utils.replaceWildCards("{HEX}", colorEvent.color);

            if (lastColor != hex)
            {
                Debug.WriteLine("Sending color...");
                lastColor = hex;
                await sendMQTT(colorEvent.color);
                await callWebhook(colorEvent.color);

                // Update the wildcards' value in the view
                // updateWildcards(colorEvent.color);
            }
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
            Bitmap screenshot = Utils.GetSreenshot();

            int segmentX = 0;
            int segmentY = 0;
            int segmentWidth = screenshot.Width;
            int segmentHeight = screenshot.Height;

            if (config.divideScreen)
            {
                segmentX = 0;
                segmentY = 0;
                segmentWidth = (int) screenshot.Width / config.segmentHorizontal;
                segmentHeight = (int)screenshot.Height / config.segmentVertical;

                // Segment cannot be bigger then the screen size
                if (segmentWidth > screenshot.Width) { segmentHeight = screenshot.Width; }
                if (segmentHeight > screenshot.Height) { segmentHeight = screenshot.Height; }
            }

            for (var j = 0; j < screenshot.Height; j = j + segmentHeight)
            {
                for (var i = 0; i < screenshot.Width; i = i + segmentWidth)
                {
                    Rectangle screenP = new Rectangle(i, j, segmentWidth, segmentHeight);
                    Bitmap segmentP = screenshot.Clone(screenP, screenshot.PixelFormat);
                }
            }

            
            Rectangle screenPart = new Rectangle(segmentX, segmentY, segmentWidth, segmentHeight);
            Bitmap segmentPic = screenshot.Clone(screenPart, screenshot.PixelFormat);
            

            Pixels pixels = new Pixels();

            for (int h = 0; h < segmentHeight; h+= Constants.SKIP_PIXEL)
            {   
                for (int w = 0; w < segmentWidth; w+= Constants.SKIP_PIXEL)
                {
                    Color pixelColor = segmentPic.GetPixel(w, h);
                    pixels.addPixel(pixelColor, config);
                }
            }

            Color c = pixels.getAverageColor();
            string hex = ColorTranslator.ToHtml(c);

            Debug.WriteLine("Hex color " + hex);
            Debug.WriteLine("RGB color " + c.R + ", " + c.G + ", " + c.B);
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
            config.mqtt = getMQTTSettings();
            config.webhook = getWebhookSettings();
            config.divideScreen = chkDivideScreen.Checked;
            
            
            try
            {
                config.segmentHorizontal = Int32.Parse(inputSegmentNumberHorizontal.Text);
            }
            catch
            {
                config.segmentHorizontal = Constants.DEFAULT_SEGMENT_NUMBER;
                inputSegmentNumberHorizontal.Text = Constants.DEFAULT_SEGMENT_NUMBER.ToString();
            }

            try
            {
                config.segmentVertical = Int32.Parse(inputSegmentNumberVertical.Text);
            }
            catch
            {
                config.segmentVertical = Constants.DEFAULT_SEGMENT_NUMBER;
                inputSegmentNumberVertical.Text = Constants.DEFAULT_SEGMENT_NUMBER.ToString();
            }

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

        private void setUI()
        {   
            
            // Segment settings            
            inputSegmentNumberHorizontal.Enabled = chkDivideScreen.Checked;
            inputSegmentNumberVertical.Enabled = chkDivideScreen.Checked;
            labelSegmentH.Enabled = chkDivideScreen.Checked;
            labelSegmentV.Enabled = chkDivideScreen.Checked;

            // Webhook
            inputWebhook.Enabled = chkEnableWebhook.Checked;

            // MQTT
            inputMQTTserver.Enabled = chkMQTTEnabled.Checked;
            inputMQTTTopic.Enabled = chkMQTTEnabled.Checked;
            inputMQTTClientId.Enabled = chkMQTTEnabled.Checked;

            inputMQTTport.Enabled = chkMQTTEnabled.Checked;

            inputMQTTMessage.Enabled = chkMQTTEnabled.Checked;
            inputMQTTUsername.Enabled = chkMQTTEnabled.Checked;
            inputMQTTPassword.Enabled = chkMQTTEnabled.Checked;
        }

        private void chkMQTTEnabled_CheckedChanged(object sender, EventArgs e)
        {
            setUI();
        }

        private void chkEnableWebhook_CheckedChanged(object sender, EventArgs e)
        {
            setUI();
        }

        private void chkSkipDarkPixels_CheckedChanged(object sender, EventArgs e)
        {
            config.skipDarkPixels = chkSkipDarkPixels.Checked;
        }

        private void chkBorderOnly_CheckedChanged(object sender, EventArgs e)
        {
           config.divideScreen = chkDivideScreen.Checked;
           setUI();
        }
    }
}
