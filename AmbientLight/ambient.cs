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
            TableLayoutPanel.CheckForIllegalCrossThreadCalls = false;
            this.config = config;
            
            InitializeComponent();
            this.SizeChanged += new EventHandler(AmbientForm_Resize);

            Thread background = new Thread(startAnalyzeInBackground);
            background.IsBackground = true;
            background.Start();

            setConfigValues(config);
            displayFrequency();
            displayWildcardsTable();
            setUI();
            

            // Event handling
            colorGeneratedEvent += ColorGeneratedEventHandler;
        }

        private async void ColorGeneratedEventHandler(object? sender, EventArgs e)
        {
            // We expecting a ScreenColorEvent here
            ColorEvent colorEvent = (ColorEvent) e;

            displayColors(colorEvent.screenColor);

            string hex = Utils.replaceWildCards("{HEX}", colorEvent.screenColor);

            if (lastColor != hex)
            {
                Debug.WriteLine("Sending color...");
                lastColor = hex;
                await sendMQTT(colorEvent.screenColor);
                await callWebhook(colorEvent.screenColor);

                // Update the wildcards' value in the view
                // updateWildcards(colorEvent.color);
            }
        }

        private void setConfigValues(Config config)
        {
            // Set the config values on the UI
            sleepTime.Value = config.refreshFrequency;
            runningChk.Checked = config.isRunning;
            trayChk.Checked = config.minimizeToTray;
            loadMQTTSettings(config.mqtt);
            loadWebhookSettings(config.webhook);
            chkSkipDarkPixels.Checked = config.skipDarkPixels;            
            inputSegmentNumberHorizontal.Text = config.segmentHorizontal.ToString();
            inputSegmentNumberVertical.Text = config.segmentVertical.ToString();
            inputDataType.Text = config.webhook.HTTPDataType;
            inputHTTPMessage.Text = config.webhook.PostBody;
        }
        private void setUI()
        {
            // Webhook

            inputWebhook.Enabled = chkEnableWebhook.Checked;
            inputHTTPMessage.Enabled = chkEnableWebhook.Checked;
            inputDataType.Enabled = chkEnableWebhook.Checked;
            comboHTTPMethod.Enabled = chkEnableWebhook.Checked;

            if (chkEnableWebhook.Checked && comboHTTPMethod.SelectedIndex == (int)Webhook.Method.GET)
            {
                inputHTTPMessage.Enabled = false;
                inputDataType.Enabled = false;                
            }

            if (chkEnableWebhook.Checked && comboHTTPMethod.SelectedIndex == (int)Webhook.Method.POST)
            {

                inputHTTPMessage.Enabled = true;
                inputDataType.Enabled = true;
            }

            // MQTT
            inputMQTTserver.Enabled = chkMQTTEnabled.Checked;
            inputMQTTTopic.Enabled = chkMQTTEnabled.Checked;
            inputMQTTClientId.Enabled = chkMQTTEnabled.Checked;

            inputMQTTport.Enabled = chkMQTTEnabled.Checked;

            inputMQTTMessage.Enabled = chkMQTTEnabled.Checked;
            inputMQTTUsername.Enabled = chkMQTTEnabled.Checked;
            inputMQTTPassword.Enabled = chkMQTTEnabled.Checked;

            // Button

            if (!runningChk.Checked)
            {   
                buttonStart.Text = "Save and start";
            }
            else
            {   
                buttonStart.Text = "Stop";
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
            ScreenColor screenColor = new ScreenColor();

            // First of all calculate the color for the whole screen
            Rectangle screen = new Rectangle(0, 0, screenshot.Width, screenshot.Height);
            Bitmap wholeScreen = screenshot.Clone(screen, screenshot.PixelFormat);
            Color mainColor = Utils.getPictureAverageColor(wholeScreen, config);
            screenColor.mainColor = mainColor;


            // Then divide the screen and calculate the segments            
            int segmentX = 0;
            int segmentY = 0;
            int segmentWidth = (int) screenshot.Width / config.segmentHorizontal;
            int segmentHeight = (int)screenshot.Height / config.segmentVertical;

            // Segment cannot be bigger then the screen size
            if (segmentWidth > screenshot.Width) { segmentHeight = screenshot.Width; }
            if (segmentHeight > screenshot.Height) { segmentHeight = screenshot.Height; }
            

            // Go troug the segments from the upper left to right and down
            // *-----> |
            // *<------¡
            int segmentCounter = 0;
            for (var j = 0; j < screenshot.Height; j = j + segmentHeight)
            {
                for (var i = 0; i < screenshot.Width; i = i + segmentWidth)
                {
                    Rectangle segmentArea = new Rectangle(i, j, segmentWidth, segmentHeight);
                    Bitmap segmentPicture = screenshot.Clone(segmentArea, screenshot.PixelFormat);
                    Color segmenColor = Utils.getPictureAverageColor(segmentPicture, config);
                    try
                    {
                        screenColor.screenColors.TryAdd(segmentCounter++, segmenColor);
                    } catch {
                        Debug.WriteLine("Cannot add color to the list. This should not happen.");
                    }
                }
            }

            Rectangle screenPart = new Rectangle(segmentX, segmentY, segmentWidth, segmentHeight);
            Bitmap segmentPic = screenshot.Clone(screenPart, screenshot.PixelFormat);

            Color c = Utils.getPictureAverageColor(screenshot, config);

            Debug.WriteLine("Timeout:" + config.refreshFrequency);

            colorGeneratedEvent.Invoke(this, new ColorEvent(screenColor));

            // Otherwise the memory consumption is high till the normal GC running
            System.GC.Collect();
        }

        // Display color on the UI
        private void displayColors(ScreenColor screenColor)
        {
            colorPanel.BackColor = screenColor.mainColor;            
            
            Debug.WriteLine("Horizontal segments: " + config.segmentHorizontal);
            Debug.WriteLine("Vertical segments: " + config.segmentVertical);

            // It is too slow, application almost crashes
            /*
            tableLayoutColors.Controls.Clear();            
            
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            tableLayoutColors.ColumnCount = config.segmentHorizontal;
            tableLayoutColors.RowCount = config.segmentVertical;

            for (var i = 0; i < config.segmentHorizontal; i++) {
                for (var j = 0; j < config.segmentVertical; j++)
                {
                    Label text = new Label();
                    text.Text = "test";
                    this.BeginInvoke((Action)(() =>
                    {
                        tableLayoutColors.Controls.Add(text, i, j);
                    }));
                }
            }


            tableLayoutColors.ResumeLayout();
            */

        }

        private void displayWildcardsTable()
        {
            tableLayoutColors.SuspendLayout();            
            tableLayoutColors.Controls.Clear();
            tableLayoutColors.ColumnCount = config.segmentHorizontal;
            tableLayoutColors.RowCount = config.segmentVertical;

            int fontSize = 8;
            if (config.segmentHorizontal * config.segmentVertical > 16)
            {
                fontSize = 6;
            }

            Font smallFont = new Font("Arial", fontSize);
            tableLayoutColors.Font = smallFont;

            int cellCounter = 0;
            for (var i = 0; i < config.segmentVertical; i++)
            {
                for (var j = 0; j < config.segmentHorizontal; j++)
                {
                    Label text = new Label();
                    text.Text = "{R" + cellCounter + "} " + " {G" + cellCounter + "} " + " {B" + cellCounter + "}\r\n{HEX" + cellCounter + "}";
                    text.TextAlign = ContentAlignment.MiddleCenter;
                    text.Anchor = AnchorStyles.None;
                    text.AutoSize = true;

                    tableLayoutColors.Controls.Add(text, j, i);
                    
                    cellCounter++;
                }
            }
            
            tableLayoutColors.ResumeLayout();
        }

        private async Task sendMQTT(ScreenColor color)
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

        private async Task callWebhook(ScreenColor screenColor)
        {
            if (config.webhook != null && config.webhook.enabled)
            {
                if (!String.IsNullOrEmpty(config.webhook.url))
                {
                    webhookService.callWebhook(config, screenColor);
                }
            }
        }

        private void updateWildcards(ScreenColor screenColor)
        {
            /*
            string R = Utils.replaceWildCards("{R}", color);
            string G = Utils.replaceWildCards("{G}", color);
            string B = Utils.replaceWildCards("{B}", color);
            string HEX = Utils.replaceWildCards("{HEX}", color);
            */
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

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            saveConfig();
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
                if (mqtt.port < 1) { mqtt.port = 1; }
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
            webhook.HTTPMethod = (Webhook.Method) comboHTTPMethod.SelectedIndex;
            webhook.PostBody = inputHTTPMessage.Text;
            webhook.HTTPDataType = inputDataType.Text;

            return webhook;
        }

        private void loadWebhookSettings(Webhook webhook)
        {
            if (webhook != null)
            {
                inputWebhook.Text = webhook.url;
                chkEnableWebhook.Checked = webhook.enabled;
                comboHTTPMethod.SelectedIndex = (int) webhook.HTTPMethod;
            }
        }

        private void saveConfig()
        {
            config.refreshFrequency = sleepTime.Value;
            config.minimizeToTray = trayChk.Checked;
            config.isRunning = runningChk.Checked;
            config.mqtt = getMQTTSettings();
            config.webhook = getWebhookSettings();

            try
            {
                config.segmentHorizontal = Int32.Parse(inputSegmentNumberHorizontal.Text);
                if (config.segmentHorizontal < 1) { config.segmentHorizontal = 1; }
                if (config.segmentHorizontal > 8) { config.segmentHorizontal = 8; }
            }
            catch
            {
                config.segmentHorizontal = Constants.DEFAULT_SEGMENT_NUMBER;
                inputSegmentNumberHorizontal.Text = Constants.DEFAULT_SEGMENT_NUMBER.ToString();
            }

            try
            {
                config.segmentVertical = Int32.Parse(inputSegmentNumberVertical.Text);
                if (config.segmentVertical < 1) { config.segmentVertical = 1; }
                if (config.segmentVertical > 8) { config.segmentVertical = 8; }
            }
            catch
            {
                config.segmentVertical = Constants.DEFAULT_SEGMENT_NUMBER;
                inputSegmentNumberVertical.Text = Constants.DEFAULT_SEGMENT_NUMBER.ToString();
            }

            displayWildcardsTable();

            Utils.ConfigToJson(this.config);
            // Just for sure
            setConfigValues(config);
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

        private void comboHTTPMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            setUI();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (config.isRunning)
            {
                config.isRunning = false;
                runningChk.Checked = false;
                saveConfig();             
            } else
            {
                config.isRunning = true;
                runningChk.Checked = true;
                saveConfig();             
            }
            setUI();
        }
    }
}
