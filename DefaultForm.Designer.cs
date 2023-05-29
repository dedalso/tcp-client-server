namespace TCP_Client_Server
{
    partial class DefaultForm
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
            ButtonSender = new Button();
            TextBoxSender = new TextBox();
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
            LabelDescription.Anchor = AnchorStyles.Top;
            LabelDescription.AutoSize = true;
            LabelDescription.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            LabelDescription.Location = new Point(72, 3);
            LabelDescription.Name = "LabelDescription";
            LabelDescription.Size = new Size(200, 25);
            LabelDescription.TabIndex = 0;
            LabelDescription.Text = "TCP/IP клиент-сервер";
            // 
            // LabelMode
            // 
            LabelMode.AutoSize = true;
            LabelMode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelMode.Location = new Point(32, 43);
            LabelMode.Name = "LabelMode";
            LabelMode.Size = new Size(62, 21);
            LabelMode.TabIndex = 1;
            LabelMode.Text = "Режим:";
            // 
            // GroupBoxSetup
            // 
            GroupBoxSetup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GroupBoxSetup.Controls.Add(LabelMode);
            GroupBoxSetup.Controls.Add(RadioButtonModeClient);
            GroupBoxSetup.Controls.Add(RadioButtonModeServer);
            GroupBoxSetup.Controls.Add(LabelIP);
            GroupBoxSetup.Controls.Add(TextBoxIP);
            GroupBoxSetup.Controls.Add(LabelPort);
            GroupBoxSetup.Controls.Add(TextBoxPort);
            GroupBoxSetup.Controls.Add(ButtonConnect);
            GroupBoxSetup.Controls.Add(ButtonDisconnect);
            GroupBoxSetup.Location = new Point(12, 40);
            GroupBoxSetup.Name = "GroupBoxSetup";
            GroupBoxSetup.Size = new Size(320, 195);
            GroupBoxSetup.TabIndex = 2;
            GroupBoxSetup.TabStop = false;
            GroupBoxSetup.Text = "Настройки";
            // 
            // RadioButtonModeClient
            // 
            RadioButtonModeClient.AutoSize = true;
            RadioButtonModeClient.Checked = true;
            RadioButtonModeClient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonModeClient.Location = new Point(52, 67);
            RadioButtonModeClient.Name = "RadioButtonModeClient";
            RadioButtonModeClient.Size = new Size(78, 25);
            RadioButtonModeClient.TabIndex = 2;
            RadioButtonModeClient.TabStop = true;
            RadioButtonModeClient.Text = "Клиент";
            RadioButtonModeClient.UseVisualStyleBackColor = true;
            RadioButtonModeClient.CheckedChanged += RadioButtonModeClient_CheckedChanged;
            // 
            // RadioButtonModeServer
            // 
            RadioButtonModeServer.AutoSize = true;
            RadioButtonModeServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RadioButtonModeServer.Location = new Point(52, 94);
            RadioButtonModeServer.Name = "RadioButtonModeServer";
            RadioButtonModeServer.Size = new Size(80, 25);
            RadioButtonModeServer.TabIndex = 3;
            RadioButtonModeServer.Text = "Сервер";
            RadioButtonModeServer.UseVisualStyleBackColor = true;
            RadioButtonModeServer.CheckedChanged += RadioButtonModeServer_CheckedChanged;
            // 
            // LabelIP
            // 
            LabelIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelIP.AutoSize = true;
            LabelIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelIP.Location = new Point(161, 21);
            LabelIP.Name = "LabelIP";
            LabelIP.Size = new Size(73, 21);
            LabelIP.TabIndex = 4;
            LabelIP.Text = "IP-адрес:";
            // 
            // TextBoxIP
            // 
            TextBoxIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxIP.Location = new Point(164, 49);
            TextBoxIP.MaxLength = 15;
            TextBoxIP.Name = "TextBoxIP";
            TextBoxIP.Size = new Size(137, 23);
            TextBoxIP.TabIndex = 5;
            // 
            // LabelPort
            // 
            LabelPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LabelPort.AutoSize = true;
            LabelPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelPort.Location = new Point(161, 84);
            LabelPort.Name = "LabelPort";
            LabelPort.Size = new Size(49, 21);
            LabelPort.TabIndex = 6;
            LabelPort.Text = "Порт:";
            // 
            // TextBoxPort
            // 
            TextBoxPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxPort.Location = new Point(164, 112);
            TextBoxPort.MaxLength = 5;
            TextBoxPort.Name = "TextBoxPort";
            TextBoxPort.Size = new Size(137, 23);
            TextBoxPort.TabIndex = 7;
            // 
            // ButtonConnect
            // 
            ButtonConnect.Location = new Point(18, 153);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(138, 23);
            ButtonConnect.TabIndex = 8;
            ButtonConnect.Text = "Соединиться";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // ButtonDisconnect
            // 
            ButtonDisconnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ButtonDisconnect.Location = new Point(164, 153);
            ButtonDisconnect.Name = "ButtonDisconnect";
            ButtonDisconnect.Size = new Size(138, 23);
            ButtonDisconnect.TabIndex = 9;
            ButtonDisconnect.Text = "Отключиться";
            ButtonDisconnect.UseVisualStyleBackColor = true;
            ButtonDisconnect.Click += ButtonDisconnect_Click;
            // 
            // GroupBoxSend
            // 
            GroupBoxSend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GroupBoxSend.Controls.Add(ButtonSender);
            GroupBoxSend.Controls.Add(TextBoxSender);
            GroupBoxSend.Location = new Point(12, 245);
            GroupBoxSend.Name = "GroupBoxSend";
            GroupBoxSend.Size = new Size(320, 76);
            GroupBoxSend.TabIndex = 3;
            GroupBoxSend.TabStop = false;
            GroupBoxSend.Text = "Отправка";
            // 
            // ButtonSender
            // 
            ButtonSender.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonSender.Location = new Point(239, 21);
            ButtonSender.Name = "ButtonSender";
            ButtonSender.Size = new Size(75, 48);
            ButtonSender.TabIndex = 1;
            ButtonSender.Text = "Вперёд!";
            ButtonSender.UseVisualStyleBackColor = true;
            ButtonSender.Click += ButtonSender_Click;
            // 
            // TextBoxSender
            // 
            TextBoxSender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxSender.Location = new Point(6, 21);
            TextBoxSender.Multiline = true;
            TextBoxSender.Name = "TextBoxSender";
            TextBoxSender.Size = new Size(227, 46);
            TextBoxSender.TabIndex = 0;
            // 
            // GroupBoxRecieve
            // 
            GroupBoxRecieve.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GroupBoxRecieve.Controls.Add(TextBoxReciever);
            GroupBoxRecieve.Location = new Point(12, 330);
            GroupBoxRecieve.Name = "GroupBoxRecieve";
            GroupBoxRecieve.Size = new Size(320, 167);
            GroupBoxRecieve.TabIndex = 4;
            GroupBoxRecieve.TabStop = false;
            GroupBoxRecieve.Text = "Прослушка";
            // 
            // TextBoxReciever
            // 
            TextBoxReciever.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxReciever.Location = new Point(6, 22);
            TextBoxReciever.Multiline = true;
            TextBoxReciever.Name = "TextBoxReciever";
            TextBoxReciever.ReadOnly = true;
            TextBoxReciever.Size = new Size(308, 138);
            TextBoxReciever.TabIndex = 0;
            // 
            // LabelAuthor
            // 
            LabelAuthor.Anchor = AnchorStyles.Top;
            LabelAuthor.AutoSize = true;
            LabelAuthor.Location = new Point(139, 26);
            LabelAuthor.Name = "LabelAuthor";
            LabelAuthor.Size = new Size(64, 15);
            LabelAuthor.TabIndex = 5;
            LabelAuthor.Text = "by dedalso";
            // 
            // DefaultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 509);
            Controls.Add(LabelDescription);
            Controls.Add(LabelAuthor);
            Controls.Add(GroupBoxSetup);
            Controls.Add(GroupBoxSend);
            Controls.Add(GroupBoxRecieve);
            Name = "DefaultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TCP/IP прослушка";
            GroupBoxSetup.ResumeLayout(false);
            GroupBoxSetup.PerformLayout();
            GroupBoxSend.ResumeLayout(false);
            GroupBoxSend.PerformLayout();
            GroupBoxRecieve.ResumeLayout(false);
            GroupBoxRecieve.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
    }
}