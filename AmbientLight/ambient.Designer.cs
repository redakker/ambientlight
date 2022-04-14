using AmbientLight.models;

namespace AmbientLight
{
    partial class AmbientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbientForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.getColorNow = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.runningChk = new System.Windows.Forms.CheckBox();
            this.trayChk = new System.Windows.Forms.CheckBox();
            this.sleepTime = new System.Windows.Forms.TrackBar();
            this.buttonSaveConfig = new System.Windows.Forms.Button();
            this.calculatedColor = new System.Windows.Forms.Label();
            this.labelOptions = new System.Windows.Forms.Label();
            this.labelCalculation = new System.Windows.Forms.Label();
            this.calculationFrequencyNumber = new System.Windows.Forms.Label();
            this.inputMQTTserver = new System.Windows.Forms.TextBox();
            this.inputMQTTTopic = new System.Windows.Forms.TextBox();
            this.inputMQTTClientId = new System.Windows.Forms.TextBox();
            this.inputMQTTport = new System.Windows.Forms.TextBox();
            this.inputMQTTUsername = new System.Windows.Forms.TextBox();
            this.inputMQTTPassword = new System.Windows.Forms.TextBox();
            this.chkMQTTEnabled = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.inputMQTTMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inputWebhook = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkEnableWebhook = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelHEX = new System.Windows.Forms.Label();
            this.chkSkipDarkPixels = new System.Windows.Forms.CheckBox();
            this.labelSegmentH = new System.Windows.Forms.Label();
            this.inputSegmentNumberHorizontal = new System.Windows.Forms.TextBox();
            this.inputSegmentNumberVertical = new System.Windows.Forms.TextBox();
            this.labelSegmentV = new System.Windows.Forms.Label();
            this.inputHTTPMessage = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboHTTPMethod = new System.Windows.Forms.ComboBox();
            this.inputDataType = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tableLayoutColors = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.sleepTime)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Running";
            this.notifyIcon.BalloonTipTitle = "AmbientLight";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AmbientLight";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // getColorNow
            // 
            this.getColorNow.Location = new System.Drawing.Point(840, 251);
            this.getColorNow.Name = "getColorNow";
            this.getColorNow.Size = new System.Drawing.Size(200, 25);
            this.getColorNow.TabIndex = 0;
            this.getColorNow.Text = "Get color now";
            this.getColorNow.UseVisualStyleBackColor = true;
            this.getColorNow.Click += new System.EventHandler(this.getColorNow_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorPanel.Location = new System.Drawing.Point(840, 43);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(200, 193);
            this.colorPanel.TabIndex = 1;
            // 
            // runningChk
            // 
            this.runningChk.AutoSize = true;
            this.runningChk.Enabled = false;
            this.runningChk.Location = new System.Drawing.Point(27, 47);
            this.runningChk.Name = "runningChk";
            this.runningChk.Size = new System.Drawing.Size(71, 19);
            this.runningChk.TabIndex = 2;
            this.runningChk.Text = "Running";
            this.runningChk.UseVisualStyleBackColor = true;
            // 
            // trayChk
            // 
            this.trayChk.AutoSize = true;
            this.trayChk.Checked = true;
            this.trayChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayChk.Location = new System.Drawing.Point(27, 72);
            this.trayChk.Name = "trayChk";
            this.trayChk.Size = new System.Drawing.Size(112, 19);
            this.trayChk.TabIndex = 3;
            this.trayChk.Text = "Minimize to tray";
            this.trayChk.UseVisualStyleBackColor = true;
            // 
            // sleepTime
            // 
            this.sleepTime.LargeChange = 500;
            this.sleepTime.Location = new System.Drawing.Point(27, 532);
            this.sleepTime.Maximum = 15000;
            this.sleepTime.Minimum = 200;
            this.sleepTime.Name = "sleepTime";
            this.sleepTime.Size = new System.Drawing.Size(749, 45);
            this.sleepTime.SmallChange = 100;
            this.sleepTime.TabIndex = 5;
            this.sleepTime.TickFrequency = 100;
            this.sleepTime.Value = 200;
            this.sleepTime.ValueChanged += new System.EventHandler(this.frequencyChanged);
            // 
            // buttonSaveConfig
            // 
            this.buttonSaveConfig.Location = new System.Drawing.Point(909, 554);
            this.buttonSaveConfig.Name = "buttonSaveConfig";
            this.buttonSaveConfig.Size = new System.Drawing.Size(131, 23);
            this.buttonSaveConfig.TabIndex = 6;
            this.buttonSaveConfig.Text = "Apply configuration";
            this.buttonSaveConfig.UseVisualStyleBackColor = true;
            this.buttonSaveConfig.Click += new System.EventHandler(this.buttonSaveConfig_Click);
            // 
            // calculatedColor
            // 
            this.calculatedColor.AutoSize = true;
            this.calculatedColor.Location = new System.Drawing.Point(817, 20);
            this.calculatedColor.Name = "calculatedColor";
            this.calculatedColor.Size = new System.Drawing.Size(206, 15);
            this.calculatedColor.TabIndex = 7;
            this.calculatedColor.Text = "Calculated color for the whole screen:";
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Location = new System.Drawing.Point(11, 20);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(49, 15);
            this.labelOptions.TabIndex = 8;
            this.labelOptions.Text = "Options";
            // 
            // labelCalculation
            // 
            this.labelCalculation.AutoSize = true;
            this.labelCalculation.Location = new System.Drawing.Point(11, 514);
            this.labelCalculation.Name = "labelCalculation";
            this.labelCalculation.Size = new System.Drawing.Size(126, 15);
            this.labelCalculation.TabIndex = 9;
            this.labelCalculation.Text = "Calculation frequency:";
            // 
            // calculationFrequencyNumber
            // 
            this.calculationFrequencyNumber.AutoSize = true;
            this.calculationFrequencyNumber.Location = new System.Drawing.Point(724, 514);
            this.calculationFrequencyNumber.Name = "calculationFrequencyNumber";
            this.calculationFrequencyNumber.Size = new System.Drawing.Size(23, 15);
            this.calculationFrequencyNumber.TabIndex = 10;
            this.calculationFrequencyNumber.Text = "ms";
            this.calculationFrequencyNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputMQTTserver
            // 
            this.inputMQTTserver.Location = new System.Drawing.Point(239, 68);
            this.inputMQTTserver.Name = "inputMQTTserver";
            this.inputMQTTserver.Size = new System.Drawing.Size(100, 23);
            this.inputMQTTserver.TabIndex = 11;
            // 
            // inputMQTTTopic
            // 
            this.inputMQTTTopic.Location = new System.Drawing.Point(239, 97);
            this.inputMQTTTopic.Name = "inputMQTTTopic";
            this.inputMQTTTopic.Size = new System.Drawing.Size(100, 23);
            this.inputMQTTTopic.TabIndex = 12;
            // 
            // inputMQTTClientId
            // 
            this.inputMQTTClientId.Location = new System.Drawing.Point(239, 126);
            this.inputMQTTClientId.Name = "inputMQTTClientId";
            this.inputMQTTClientId.Size = new System.Drawing.Size(100, 23);
            this.inputMQTTClientId.TabIndex = 13;
            // 
            // inputMQTTport
            // 
            this.inputMQTTport.Location = new System.Drawing.Point(239, 155);
            this.inputMQTTport.Name = "inputMQTTport";
            this.inputMQTTport.Size = new System.Drawing.Size(100, 23);
            this.inputMQTTport.TabIndex = 14;
            // 
            // inputMQTTUsername
            // 
            this.inputMQTTUsername.Location = new System.Drawing.Point(239, 184);
            this.inputMQTTUsername.Name = "inputMQTTUsername";
            this.inputMQTTUsername.Size = new System.Drawing.Size(100, 23);
            this.inputMQTTUsername.TabIndex = 15;
            // 
            // inputMQTTPassword
            // 
            this.inputMQTTPassword.Location = new System.Drawing.Point(239, 213);
            this.inputMQTTPassword.Name = "inputMQTTPassword";
            this.inputMQTTPassword.PasswordChar = '*';
            this.inputMQTTPassword.Size = new System.Drawing.Size(100, 23);
            this.inputMQTTPassword.TabIndex = 16;
            this.inputMQTTPassword.UseSystemPasswordChar = true;
            // 
            // chkMQTTEnabled
            // 
            this.chkMQTTEnabled.AutoSize = true;
            this.chkMQTTEnabled.Location = new System.Drawing.Point(239, 43);
            this.chkMQTTEnabled.Name = "chkMQTTEnabled";
            this.chkMQTTEnabled.Size = new System.Drawing.Size(102, 19);
            this.chkMQTTEnabled.TabIndex = 17;
            this.chkMQTTEnabled.Text = "MQTT enabled";
            this.chkMQTTEnabled.UseVisualStyleBackColor = true;
            this.chkMQTTEnabled.CheckedChanged += new System.EventHandler(this.chkMQTTEnabled_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "MQTT Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "MQTT topic:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Client ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Password:";
            // 
            // inputMQTTMessage
            // 
            this.inputMQTTMessage.Location = new System.Drawing.Point(364, 68);
            this.inputMQTTMessage.Multiline = true;
            this.inputMQTTMessage.Name = "inputMQTTMessage";
            this.inputMQTTMessage.Size = new System.Drawing.Size(212, 168);
            this.inputMQTTMessage.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "MQTT message:";
            // 
            // inputWebhook
            // 
            this.inputWebhook.Location = new System.Drawing.Point(26, 323);
            this.inputWebhook.Name = "inputWebhook";
            this.inputWebhook.Size = new System.Drawing.Size(550, 23);
            this.inputWebhook.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "Webhook URL:";
            // 
            // chkEnableWebhook
            // 
            this.chkEnableWebhook.AutoSize = true;
            this.chkEnableWebhook.Location = new System.Drawing.Point(27, 280);
            this.chkEnableWebhook.Name = "chkEnableWebhook";
            this.chkEnableWebhook.Size = new System.Drawing.Size(122, 19);
            this.chkEnableWebhook.TabIndex = 28;
            this.chkEnableWebhook.Text = "Webhook enabled";
            this.chkEnableWebhook.UseVisualStyleBackColor = true;
            this.chkEnableWebhook.CheckedChanged += new System.EventHandler(this.chkEnableWebhook_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "MQTT settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "Webhook settings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(595, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 15);
            this.label11.TabIndex = 32;
            this.label11.Text = "Wildcards for colors:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(606, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 15);
            this.label12.TabIndex = 33;
            this.label12.Text = "Red:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(606, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 15);
            this.label13.TabIndex = 34;
            this.label13.Text = "Green:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(606, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 15);
            this.label14.TabIndex = 35;
            this.label14.Text = "Blue:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(606, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 36;
            this.label15.Text = "Hex code:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(595, 187);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(226, 30);
            this.label16.TabIndex = 37;
            this.label16.Text = "Wildcards can be used in MQTT and POST\r\nmessage and in the webhook URL as well.";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(683, 99);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(22, 15);
            this.labelRed.TabIndex = 39;
            this.labelRed.Text = "{R}";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(683, 119);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(23, 15);
            this.labelGreen.TabIndex = 40;
            this.labelGreen.Text = "{G}";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(683, 138);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(22, 15);
            this.labelBlue.TabIndex = 41;
            this.labelBlue.Text = "{B}";
            // 
            // labelHEX
            // 
            this.labelHEX.AutoSize = true;
            this.labelHEX.Location = new System.Drawing.Point(683, 157);
            this.labelHEX.Name = "labelHEX";
            this.labelHEX.Size = new System.Drawing.Size(37, 15);
            this.labelHEX.TabIndex = 42;
            this.labelHEX.Text = "{HEX}";
            // 
            // chkSkipDarkPixels
            // 
            this.chkSkipDarkPixels.AutoSize = true;
            this.chkSkipDarkPixels.Location = new System.Drawing.Point(27, 95);
            this.chkSkipDarkPixels.Name = "chkSkipDarkPixels";
            this.chkSkipDarkPixels.Size = new System.Drawing.Size(107, 19);
            this.chkSkipDarkPixels.TabIndex = 46;
            this.chkSkipDarkPixels.Text = "Skip dark pixels";
            this.chkSkipDarkPixels.UseVisualStyleBackColor = true;
            this.chkSkipDarkPixels.CheckedChanged += new System.EventHandler(this.chkSkipDarkPixels_CheckedChanged);
            // 
            // labelSegmentH
            // 
            this.labelSegmentH.AutoSize = true;
            this.labelSegmentH.Location = new System.Drawing.Point(26, 143);
            this.labelSegmentH.Name = "labelSegmentH";
            this.labelSegmentH.Size = new System.Drawing.Size(71, 15);
            this.labelSegmentH.TabIndex = 55;
            this.labelSegmentH.Text = "Segments H";
            // 
            // inputSegmentNumberHorizontal
            // 
            this.inputSegmentNumberHorizontal.Location = new System.Drawing.Point(107, 140);
            this.inputSegmentNumberHorizontal.Name = "inputSegmentNumberHorizontal";
            this.inputSegmentNumberHorizontal.Size = new System.Drawing.Size(42, 23);
            this.inputSegmentNumberHorizontal.TabIndex = 56;
            // 
            // inputSegmentNumberVertical
            // 
            this.inputSegmentNumberVertical.Location = new System.Drawing.Point(107, 169);
            this.inputSegmentNumberVertical.Name = "inputSegmentNumberVertical";
            this.inputSegmentNumberVertical.Size = new System.Drawing.Size(42, 23);
            this.inputSegmentNumberVertical.TabIndex = 57;
            // 
            // labelSegmentV
            // 
            this.labelSegmentV.AutoSize = true;
            this.labelSegmentV.Location = new System.Drawing.Point(27, 172);
            this.labelSegmentV.Name = "labelSegmentV";
            this.labelSegmentV.Size = new System.Drawing.Size(69, 15);
            this.labelSegmentV.TabIndex = 58;
            this.labelSegmentV.Text = "Segments V";
            // 
            // inputHTTPMessage
            // 
            this.inputHTTPMessage.Location = new System.Drawing.Point(381, 389);
            this.inputHTTPMessage.Multiline = true;
            this.inputHTTPMessage.Name = "inputHTTPMessage";
            this.inputHTTPMessage.Size = new System.Drawing.Size(195, 118);
            this.inputHTTPMessage.TabIndex = 59;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(379, 368);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 15);
            this.label18.TabIndex = 60;
            this.label18.Text = "POST body:";
            // 
            // comboHTTPMethod
            // 
            this.comboHTTPMethod.FormattingEnabled = true;
            this.comboHTTPMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.comboHTTPMethod.Location = new System.Drawing.Point(184, 389);
            this.comboHTTPMethod.Name = "comboHTTPMethod";
            this.comboHTTPMethod.Size = new System.Drawing.Size(191, 23);
            this.comboHTTPMethod.TabIndex = 61;
            this.comboHTTPMethod.Tag = "";
            this.comboHTTPMethod.SelectedIndexChanged += new System.EventHandler(this.comboHTTPMethod_SelectedIndexChanged);
            // 
            // inputDataType
            // 
            this.inputDataType.Location = new System.Drawing.Point(184, 418);
            this.inputDataType.Name = "inputDataType";
            this.inputDataType.Size = new System.Drawing.Size(191, 23);
            this.inputDataType.TabIndex = 62;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(123, 422);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 15);
            this.label19.TabIndex = 63;
            this.label19.Text = "Data type:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(130, 392);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 15);
            this.label20.TabIndex = 64;
            this.label20.Text = "Method:";
            // 
            // tableLayoutColors
            // 
            this.tableLayoutColors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutColors.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutColors.ColumnCount = 1;
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.Location = new System.Drawing.Point(595, 283);
            this.tableLayoutColors.Name = "tableLayoutColors";
            this.tableLayoutColors.RowCount = 1;
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutColors.Size = new System.Drawing.Size(445, 224);
            this.tableLayoutColors.TabIndex = 65;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 15);
            this.label21.TabIndex = 66;
            this.label21.Text = "Divide screen:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(808, 554);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(95, 23);
            this.buttonStart.TabIndex = 67;
            this.buttonStart.Text = "Save and start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(595, 246);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(232, 30);
            this.label22.TabIndex = 68;
            this.label22.Text = "The following table contains the wildcards \r\nfor the screen segments:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(221, 444);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(154, 75);
            this.label23.TabIndex = 69;
            this.label23.Text = "Post JSON example:\r\n{\r\n\"segment1_HEX\" : \"{HEX1}\",\r\n\"segment8_R\" : \"{R8}\"\r\n}\r\n";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.LinkColor = System.Drawing.Color.Firebrick;
            this.linkLabel.Location = new System.Drawing.Point(11, 568);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(159, 15);
            this.linkLabel.TabIndex = 70;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "https://github.com/redakker";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // AmbientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1052, 590);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tableLayoutColors);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.inputDataType);
            this.Controls.Add(this.comboHTTPMethod);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.inputHTTPMessage);
            this.Controls.Add(this.labelSegmentV);
            this.Controls.Add(this.inputSegmentNumberVertical);
            this.Controls.Add(this.inputSegmentNumberHorizontal);
            this.Controls.Add(this.labelSegmentH);
            this.Controls.Add(this.chkSkipDarkPixels);
            this.Controls.Add(this.labelHEX);
            this.Controls.Add(this.labelBlue);
            this.Controls.Add(this.labelGreen);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chkEnableWebhook);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.inputWebhook);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.inputMQTTMessage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkMQTTEnabled);
            this.Controls.Add(this.inputMQTTPassword);
            this.Controls.Add(this.inputMQTTUsername);
            this.Controls.Add(this.inputMQTTport);
            this.Controls.Add(this.inputMQTTClientId);
            this.Controls.Add(this.inputMQTTTopic);
            this.Controls.Add(this.inputMQTTserver);
            this.Controls.Add(this.calculationFrequencyNumber);
            this.Controls.Add(this.labelCalculation);
            this.Controls.Add(this.labelOptions);
            this.Controls.Add(this.calculatedColor);
            this.Controls.Add(this.buttonSaveConfig);
            this.Controls.Add(this.sleepTime);
            this.Controls.Add(this.trayChk);
            this.Controls.Add(this.runningChk);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.getColorNow);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AmbientForm";
            this.Text = "AmbientLight - v1.0";
            ((System.ComponentModel.ISupportInitialize)(this.sleepTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon;
        private Button getColorNow;
        private Panel colorPanel;
        private CheckBox runningChk;
        private CheckBox trayChk;
        private TrackBar sleepTime;
        private Button buttonSaveConfig;
        private Label calculatedColor;
        private Label labelOptions;
        private Label labelCalculation;
        private Label calculationFrequencyNumber;
        private TextBox inputMQTTserver;
        private TextBox inputMQTTTopic;
        private TextBox inputMQTTClientId;
        private TextBox inputMQTTport;
        private TextBox inputMQTTUsername;
        private TextBox inputMQTTPassword;
        private CheckBox chkMQTTEnabled;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox inputMQTTMessage;
        private Label label7;
        private TextBox inputWebhook;
        private Label label8;
        private CheckBox chkEnableWebhook;
        private Label label9;
        private Label label10;        
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label labelRed;
        private Label labelGreen;
        private Label labelBlue;
        private Label labelHEX;
        private CheckBox chkSkipDarkPixels;
        private CheckBox chkSkipBrightPixels;
        private Label labelSegmentH;
        private TextBox inputSegmentNumberHorizontal;
        private TextBox inputSegmentNumberVertical;
        private Label labelSegmentV;
        private TextBox inputHTTPMessage;
        private Label label18;
        private ComboBox comboHTTPMethod;
        private TextBox inputDataType;
        private Label label19;
        private Label label20;
        private TableLayoutPanel tableLayoutColors;
        private Label label21;
        private Button buttonStart;
        private Label label22;
        private Label label23;
        private LinkLabel linkLabel;
    }
}