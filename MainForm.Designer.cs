namespace TCP_Client_Server
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            LabelDescription = new Label();
            LabelMode = new Label();
            GroupBoxSetup = new GroupBox();
            RadioButtonModeClient = new RadioButton();
            RadioButtonModeServer = new RadioButton();
            LabelIP = new Label();
            TextBoxIP = new TextBox();
            LabelPort = new Label();
            TextBoxPort = new TextBox();
            ButtonConnect = new Button();
            ButtonDisconnect = new Button();
            GroupBoxSend = new GroupBox();
            LabelPeer = new Label();
            ComboBoxClients = new ComboBox();
            TextBoxSender = new TextBox();
            ButtonSender = new Button();
            GroupBoxRecieve = new GroupBox();
            TextBoxReciever = new TextBox();
            LabelAuthor = new Label();
            GroupBoxSetup.SuspendLayout();
            GroupBoxSend.SuspendLayout();
            GroupBoxRecieve.SuspendLayout();
            SuspendLayout();
            // 
            // LabelDescription
            // 
            resources.ApplyResources(LabelDescription, "LabelDescription");
            LabelDescription.Name = "LabelDescription";
            // 
            // LabelMode
            // 
            resources.ApplyResources(LabelMode, "LabelMode");
            LabelMode.Name = "LabelMode";
            // 
            // GroupBoxSetup
            // 
            resources.ApplyResources(GroupBoxSetup, "GroupBoxSetup");
            GroupBoxSetup.Controls.Add(LabelMode);
            GroupBoxSetup.Controls.Add(RadioButtonModeClient);
            GroupBoxSetup.Controls.Add(RadioButtonModeServer);
            GroupBoxSetup.Controls.Add(LabelIP);
            GroupBoxSetup.Controls.Add(TextBoxIP);
            GroupBoxSetup.Controls.Add(LabelPort);
            GroupBoxSetup.Controls.Add(TextBoxPort);
            GroupBoxSetup.Controls.Add(ButtonConnect);
            GroupBoxSetup.Controls.Add(ButtonDisconnect);
            GroupBoxSetup.Name = "GroupBoxSetup";
            GroupBoxSetup.TabStop = false;
            // 
            // RadioButtonModeClient
            // 
            resources.ApplyResources(RadioButtonModeClient, "RadioButtonModeClient");
            RadioButtonModeClient.Name = "RadioButtonModeClient";
            RadioButtonModeClient.UseVisualStyleBackColor = true;
            RadioButtonModeClient.CheckedChanged += RadioButtonModeClient_CheckedChanged;
            // 
            // RadioButtonModeServer
            // 
            resources.ApplyResources(RadioButtonModeServer, "RadioButtonModeServer");
            RadioButtonModeServer.Name = "RadioButtonModeServer";
            RadioButtonModeServer.UseVisualStyleBackColor = true;
            RadioButtonModeServer.CheckedChanged += RadioButtonModeServer_CheckedChanged;
            // 
            // LabelIP
            // 
            resources.ApplyResources(LabelIP, "LabelIP");
            LabelIP.ForeColor = SystemColors.ControlText;
            LabelIP.Name = "LabelIP";
            // 
            // TextBoxIP
            // 
            resources.ApplyResources(TextBoxIP, "TextBoxIP");
            TextBoxIP.Name = "TextBoxIP";
            // 
            // LabelPort
            // 
            resources.ApplyResources(LabelPort, "LabelPort");
            LabelPort.Name = "LabelPort";
            // 
            // TextBoxPort
            // 
            resources.ApplyResources(TextBoxPort, "TextBoxPort");
            TextBoxPort.Name = "TextBoxPort";
            // 
            // ButtonConnect
            // 
            resources.ApplyResources(ButtonConnect, "ButtonConnect");
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // ButtonDisconnect
            // 
            resources.ApplyResources(ButtonDisconnect, "ButtonDisconnect");
            ButtonDisconnect.Name = "ButtonDisconnect";
            ButtonDisconnect.UseVisualStyleBackColor = true;
            ButtonDisconnect.Click += ButtonDisconnect_Click;
            // 
            // GroupBoxSend
            // 
            resources.ApplyResources(GroupBoxSend, "GroupBoxSend");
            GroupBoxSend.Controls.Add(LabelPeer);
            GroupBoxSend.Controls.Add(ComboBoxClients);
            GroupBoxSend.Controls.Add(TextBoxSender);
            GroupBoxSend.Controls.Add(ButtonSender);
            GroupBoxSend.Name = "GroupBoxSend";
            GroupBoxSend.TabStop = false;
            // 
            // LabelPeer
            // 
            resources.ApplyResources(LabelPeer, "LabelPeer");
            LabelPeer.Name = "LabelPeer";
            // 
            // ComboBoxClients
            // 
            resources.ApplyResources(ComboBoxClients, "ComboBoxClients");
            ComboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxClients.FormattingEnabled = true;
            ComboBoxClients.Name = "ComboBoxClients";
            ComboBoxClients.SelectedIndexChanged += ComboBoxClients_SelectedIndexChanged;
            // 
            // TextBoxSender
            // 
            resources.ApplyResources(TextBoxSender, "TextBoxSender");
            TextBoxSender.Name = "TextBoxSender";
            // 
            // ButtonSender
            // 
            resources.ApplyResources(ButtonSender, "ButtonSender");
            ButtonSender.Name = "ButtonSender";
            ButtonSender.UseVisualStyleBackColor = true;
            ButtonSender.Click += ButtonSender_Click;
            // 
            // GroupBoxRecieve
            // 
            resources.ApplyResources(GroupBoxRecieve, "GroupBoxRecieve");
            GroupBoxRecieve.Controls.Add(TextBoxReciever);
            GroupBoxRecieve.Name = "GroupBoxRecieve";
            GroupBoxRecieve.TabStop = false;
            // 
            // TextBoxReciever
            // 
            resources.ApplyResources(TextBoxReciever, "TextBoxReciever");
            TextBoxReciever.Name = "TextBoxReciever";
            TextBoxReciever.ReadOnly = true;
            // 
            // LabelAuthor
            // 
            resources.ApplyResources(LabelAuthor, "LabelAuthor");
            LabelAuthor.Name = "LabelAuthor";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LabelDescription);
            Controls.Add(LabelAuthor);
            Controls.Add(GroupBoxSetup);
            Controls.Add(GroupBoxSend);
            Controls.Add(GroupBoxRecieve);
            Name = "MainForm";
            GroupBoxSetup.ResumeLayout(false);
            GroupBoxSetup.PerformLayout();
            GroupBoxSend.ResumeLayout(false);
            GroupBoxSend.PerformLayout();
            GroupBoxRecieve.ResumeLayout(false);
            GroupBoxRecieve.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label LabelDescription;
        private Label LabelMode;
        private GroupBox GroupBoxSetup;
        private GroupBox GroupBoxSend;
        private Button ButtonSender;
        private TextBox TextBoxSender;
        private GroupBox GroupBoxRecieve;
        private TextBox TextBoxReciever;
        private RadioButton RadioButtonModeServer;
        private RadioButton RadioButtonModeClient;
        private Label LabelIP;
        private TextBox TextBoxIP;
        private TextBox TextBoxPort;
        private Label LabelPort;
        private Button ButtonDisconnect;
        private Button ButtonConnect;
        private Label LabelAuthor;
        private Label LabelPeer;
        private ComboBox ComboBoxClients;
    }
}