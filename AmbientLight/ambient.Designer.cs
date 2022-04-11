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
            this.saveConfig = new System.Windows.Forms.Button();
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
            this.label17 = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelHEX = new System.Windows.Forms.Label();
            this.inputScreenMargin = new System.Windows.Forms.TextBox();
            this.labelScreenMargin = new System.Windows.Forms.Label();
            this.chkSkipDarkPixels = new System.Windows.Forms.CheckBox();
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
            this.getColorNow.Location = new System.Drawing.Point(1016, 314);
            this.getColorNow.Margin = new System.Windows.Forms.Padding(4);
            this.getColorNow.Name = "getColorNow";
            this.getColorNow.Size = new System.Drawing.Size(250, 31);
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
            this.colorPanel.Location = new System.Drawing.Point(1016, 54);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(4);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(250, 241);
            this.colorPanel.TabIndex = 1;
            // 
            // runningChk
            // 
            this.runningChk.AutoSize = true;
            this.runningChk.Location = new System.Drawing.Point(34, 59);
            this.runningChk.Margin = new System.Windows.Forms.Padding(4);
            this.runningChk.Name = "runningChk";
            this.runningChk.Size = new System.Drawing.Size(85, 24);
            this.runningChk.TabIndex = 2;
            this.runningChk.Text = "Running";
            this.runningChk.UseVisualStyleBackColor = true;
            // 
            // trayChk
            // 
            this.trayChk.AutoSize = true;
            this.trayChk.Checked = true;
            this.trayChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayChk.Location = new System.Drawing.Point(34, 90);
            this.trayChk.Margin = new System.Windows.Forms.Padding(4);
            this.trayChk.Name = "trayChk";
            this.trayChk.Size = new System.Drawing.Size(139, 24);
            this.trayChk.TabIndex = 3;
            this.trayChk.Text = "Minimize to tray";
            this.trayChk.UseVisualStyleBackColor = true;
            // 
            // sleepTime
            // 
            this.sleepTime.LargeChange = 500;
            this.sleepTime.Location = new System.Drawing.Point(34, 490);
            this.sleepTime.Margin = new System.Windows.Forms.Padding(4);
            this.sleepTime.Maximum = 15000;
            this.sleepTime.Minimum = 200;
            this.sleepTime.Name = "sleepTime";
            this.sleepTime.Size = new System.Drawing.Size(936, 56);
            this.sleepTime.SmallChange = 100;
            this.sleepTime.TabIndex = 5;
            this.sleepTime.TickFrequency = 100;
            this.sleepTime.Value = 200;
            this.sleepTime.ValueChanged += new System.EventHandler(this.frequencyChanged);
            // 
            // saveConfig
            // 
            this.saveConfig.Location = new System.Drawing.Point(1102, 518);
            this.saveConfig.Margin = new System.Windows.Forms.Padding(4);
            this.saveConfig.Name = "saveConfig";
            this.saveConfig.Size = new System.Drawing.Size(164, 29);
            this.saveConfig.TabIndex = 6;
            this.saveConfig.Text = "Apply configuration";
            this.saveConfig.UseVisualStyleBackColor = true;
            this.saveConfig.Click += new System.EventHandler(this.saveConfig_Click);
            // 
            // calculatedColor
            // 
            this.calculatedColor.AutoSize = true;
            this.calculatedColor.Location = new System.Drawing.Point(1016, 25);
            this.calculatedColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.calculatedColor.Name = "calculatedColor";
            this.calculatedColor.Size = new System.Drawing.Size(120, 20);
            this.calculatedColor.TabIndex = 7;
            this.calculatedColor.Text = "Calculated color:";
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Location = new System.Drawing.Point(14, 25);
            this.labelOptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(61, 20);
            this.labelOptions.TabIndex = 8;
            this.labelOptions.Text = "Options";
            // 
            // labelCalculation
            // 
            this.labelCalculation.AutoSize = true;
            this.labelCalculation.Location = new System.Drawing.Point(14, 459);
            this.labelCalculation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCalculation.Name = "labelCalculation";
            this.labelCalculation.Size = new System.Drawing.Size(155, 20);
            this.labelCalculation.TabIndex = 9;
            this.labelCalculation.Text = "Calculation frequency:";
            // 
            // calculationFrequencyNumber
            // 
            this.calculationFrequencyNumber.AutoSize = true;
            this.calculationFrequencyNumber.Location = new System.Drawing.Point(905, 459);
            this.calculationFrequencyNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.calculationFrequencyNumber.Name = "calculationFrequencyNumber";
            this.calculationFrequencyNumber.Size = new System.Drawing.Size(28, 20);
            this.calculationFrequencyNumber.TabIndex = 10;
            this.calculationFrequencyNumber.Text = "ms";
            this.calculationFrequencyNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputMQTTserver
            // 
            this.inputMQTTserver.Location = new System.Drawing.Point(274, 85);
            this.inputMQTTserver.Margin = new System.Windows.Forms.Padding(4);
            this.inputMQTTserver.Name = "inputMQTTserver";
            this.inputMQTTserver.Size = new System.Drawing.Size(124, 27);
            this.inputMQTTserver.TabIndex = 11;
            // 
            // inputMQTTTopic
            // 
            this.inputMQTTTopic.Location = new System.Drawing.Point(274, 121);
            this.inputMQTTTopic.Margin = new System.Windows.Forms.Padding(4);
            this.inputMQTTTopic.Name = "inputMQTTTopic";
            this.inputMQTTTopic.Size = new System.Drawing.Size(124, 27);
            this.inputMQTTTopic.TabIndex = 12;
            // 
            // inputMQTTClientId
            // 
            this.inputMQTTClientId.Location = new System.Drawing.Point(274, 158);
            this.inputMQTTClientId.Margin = new System.Windows.Forms.Padding(4);
            this.inputMQTTClientId.Name = "inputMQTTClientId";
            this.inputMQTTClientId.Size = new System.Drawing.Size(124, 27);
            this.inputMQTTClientId.TabIndex = 13;
            // 
            // inputMQTTport
            // 
            this.inputMQTTport.Location = new System.Drawing.Point(274, 194);
            this.inputMQTTport.Margin = new System.Windows.Forms.Padding(4);
            this.inputMQTTport.Name = "inputMQTTport";
            this.inputMQTTport.Size = new System.Drawing.Size(124, 27);
            this.inputMQTTport.TabIndex = 14;
            // 
            // inputMQTTUsername
            // 
            this.inputMQTTUsername.Location = new System.Drawing.Point(274, 230);
            this.inputMQTTUsername.Margin = new System.Windows.Forms.Padding(4);
            this.inputMQTTUsername.Name = "inputMQTTUsername";
            this.inputMQTTUsername.Size = new System.Drawing.Size(124, 27);
            this.inputMQTTUsername.TabIndex = 15;
            // 
            // inputMQTTPassword
            // 
            this.inputMQTTPassword.Location = new System.Drawing.Point(274, 266);
            this.inputMQTTPassword.Margin = new System.Windows.Forms.Padding(4);
            this.inputMQTTPassword.Name = "inputMQTTPassword";
            this.inputMQTTPassword.PasswordChar = '*';
            this.inputMQTTPassword.Size = new System.Drawing.Size(124, 27);
            this.inputMQTTPassword.TabIndex = 16;
            this.inputMQTTPassword.UseSystemPasswordChar = true;
            // 
            // chkMQTTEnabled
            // 
            this.chkMQTTEnabled.AutoSize = true;
            this.chkMQTTEnabled.Location = new System.Drawing.Point(274, 54);
            this.chkMQTTEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.chkMQTTEnabled.Name = "chkMQTTEnabled";
            this.chkMQTTEnabled.Size = new System.Drawing.Size(128, 24);
            this.chkMQTTEnabled.TabIndex = 17;
            this.chkMQTTEnabled.Text = "MQTT enabled";
            this.chkMQTTEnabled.UseVisualStyleBackColor = true;
            this.chkMQTTEnabled.CheckedChanged += new System.EventHandler(this.chkMQTTEnabled_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "MQTT Url:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "MQTT topic:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Client ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 234);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 270);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Password:";
            // 
            // inputMQTTMessage
            // 
            this.inputMQTTMessage.Location = new System.Drawing.Point(430, 85);
            this.inputMQTTMessage.Margin = new System.Windows.Forms.Padding(4);
            this.inputMQTTMessage.Multiline = true;
            this.inputMQTTMessage.Name = "inputMQTTMessage";
            this.inputMQTTMessage.Size = new System.Drawing.Size(264, 209);
            this.inputMQTTMessage.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "MQTT message:";
            // 
            // inputWebhook
            // 
            this.inputWebhook.Location = new System.Drawing.Point(32, 404);
            this.inputWebhook.Margin = new System.Windows.Forms.Padding(4);
            this.inputWebhook.Name = "inputWebhook";
            this.inputWebhook.Size = new System.Drawing.Size(530, 27);
            this.inputWebhook.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 378);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Webhook URL:";
            // 
            // chkEnableWebhook
            // 
            this.chkEnableWebhook.AutoSize = true;
            this.chkEnableWebhook.Location = new System.Drawing.Point(34, 350);
            this.chkEnableWebhook.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnableWebhook.Name = "chkEnableWebhook";
            this.chkEnableWebhook.Size = new System.Drawing.Size(152, 24);
            this.chkEnableWebhook.TabIndex = 28;
            this.chkEnableWebhook.Text = "Webhook enabled";
            this.chkEnableWebhook.UseVisualStyleBackColor = true;
            this.chkEnableWebhook.CheckedChanged += new System.EventHandler(this.chkEnableWebhook_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "MQTT settings";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 326);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Webhook settings";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(706, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 20);
            this.label11.TabIndex = 32;
            this.label11.Text = "Wildcards for colors:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(720, 124);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Red:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(720, 149);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "Green:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(720, 172);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 20);
            this.label14.TabIndex = 35;
            this.label14.Text = "Blue:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(720, 196);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 20);
            this.label15.TabIndex = 36;
            this.label15.Text = "Hex code:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(715, 226);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(279, 20);
            this.label16.TabIndex = 37;
            this.label16.Text = "Wildcards can be used in MQTT message";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(778, 249);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(157, 20);
            this.label17.TabIndex = 38;
            this.label17.Text = "and in the URL as well.";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(816, 124);
            this.labelRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(28, 20);
            this.labelRed.TabIndex = 39;
            this.labelRed.Text = "{R}";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(816, 149);
            this.labelGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(29, 20);
            this.labelGreen.TabIndex = 40;
            this.labelGreen.Text = "{G}";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(816, 172);
            this.labelBlue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(28, 20);
            this.labelBlue.TabIndex = 41;
            this.labelBlue.Text = "{B}";
            // 
            // labelHEX
            // 
            this.labelHEX.AutoSize = true;
            this.labelHEX.Location = new System.Drawing.Point(816, 196);
            this.labelHEX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHEX.Name = "labelHEX";
            this.labelHEX.Size = new System.Drawing.Size(47, 20);
            this.labelHEX.TabIndex = 42;
            this.labelHEX.Text = "{HEX}";
            // 
            // inputScreenMargin
            // 
            this.inputScreenMargin.Location = new System.Drawing.Point(34, 139);
            this.inputScreenMargin.Margin = new System.Windows.Forms.Padding(4);
            this.inputScreenMargin.Name = "inputScreenMargin";
            this.inputScreenMargin.Size = new System.Drawing.Size(124, 27);
            this.inputScreenMargin.TabIndex = 44;
            // 
            // labelScreenMargin
            // 
            this.labelScreenMargin.AutoSize = true;
            this.labelScreenMargin.Location = new System.Drawing.Point(30, 116);
            this.labelScreenMargin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelScreenMargin.Name = "labelScreenMargin";
            this.labelScreenMargin.Size = new System.Drawing.Size(107, 20);
            this.labelScreenMargin.TabIndex = 45;
            this.labelScreenMargin.Text = "Screen margin:";
            // 
            // chkSkipDarkPixels
            // 
            this.chkSkipDarkPixels.AutoSize = true;
            this.chkSkipDarkPixels.Location = new System.Drawing.Point(34, 179);
            this.chkSkipDarkPixels.Margin = new System.Windows.Forms.Padding(4);
            this.chkSkipDarkPixels.Name = "chkSkipDarkPixels";
            this.chkSkipDarkPixels.Size = new System.Drawing.Size(134, 24);
            this.chkSkipDarkPixels.TabIndex = 46;
            this.chkSkipDarkPixels.Text = "Skip dark pixels";
            this.chkSkipDarkPixels.UseVisualStyleBackColor = true;
            this.chkSkipDarkPixels.CheckedChanged += new System.EventHandler(this.chkSkipDarkPixels_CheckedChanged);
            // 
            // AmbientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1282, 571);
            this.Controls.Add(this.chkSkipDarkPixels);
            this.Controls.Add(this.labelScreenMargin);
            this.Controls.Add(this.inputScreenMargin);
            this.Controls.Add(this.labelHEX);
            this.Controls.Add(this.labelBlue);
            this.Controls.Add(this.labelGreen);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.label17);
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
            this.Controls.Add(this.saveConfig);
            this.Controls.Add(this.sleepTime);
            this.Controls.Add(this.trayChk);
            this.Controls.Add(this.runningChk);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.getColorNow);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AmbientForm";
            this.Text = "AmbientLight - v0.85";
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
        private Button saveConfig;
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
        private Label label17;
        private Label labelRed;
        private Label labelGreen;
        private Label labelBlue;
        private Label labelHEX;
        private TextBox inputScreenMargin;
        private Label labelScreenMargin;
        private CheckBox chkSkipDarkPixels;
        private CheckBox chkSkipBrightPixels;
    }
}