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
            labelDescription = new Label();
            labelMode = new Label();
            groupBoxSetup = new GroupBox();
            radioButtonModeClient = new RadioButton();
            radioButtonModeServer = new RadioButton();
            labelIP = new Label();
            textBoxIP = new TextBox();
            labelPort = new Label();
            textBoxPort = new TextBox();
            buttonConnect = new Button();
            buttonDisconnect = new Button();
            groupBoxSend = new GroupBox();
            buttonSender = new Button();
            textBoxSender = new TextBox();
            groupBoxRecieve = new GroupBox();
            textBoxReciever = new TextBox();
            labelAuthor = new Label();
            groupBoxSetup.SuspendLayout();
            groupBoxSend.SuspendLayout();
            groupBoxRecieve.SuspendLayout();
            SuspendLayout();
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Top;
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescription.Location = new Point(72, 3);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(200, 25);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "TCP/IP клиент-сервер";
            // 
            // labelMode
            // 
            labelMode.AutoSize = true;
            labelMode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMode.Location = new Point(32, 43);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(62, 21);
            labelMode.TabIndex = 1;
            labelMode.Text = "Режим:";
            // 
            // groupBoxSetup
            // 
            groupBoxSetup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSetup.Controls.Add(labelMode);
            groupBoxSetup.Controls.Add(radioButtonModeClient);
            groupBoxSetup.Controls.Add(radioButtonModeServer);
            groupBoxSetup.Controls.Add(labelIP);
            groupBoxSetup.Controls.Add(textBoxIP);
            groupBoxSetup.Controls.Add(labelPort);
            groupBoxSetup.Controls.Add(textBoxPort);
            groupBoxSetup.Controls.Add(buttonConnect);
            groupBoxSetup.Controls.Add(buttonDisconnect);
            groupBoxSetup.Location = new Point(12, 40);
            groupBoxSetup.Name = "groupBoxSetup";
            groupBoxSetup.Size = new Size(320, 195);
            groupBoxSetup.TabIndex = 2;
            groupBoxSetup.TabStop = false;
            groupBoxSetup.Text = "Настройки";
            // 
            // radioButtonModeClient
            // 
            radioButtonModeClient.AutoSize = true;
            radioButtonModeClient.Checked = true;
            radioButtonModeClient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonModeClient.Location = new Point(52, 67);
            radioButtonModeClient.Name = "radioButtonModeClient";
            radioButtonModeClient.Size = new Size(78, 25);
            radioButtonModeClient.TabIndex = 2;
            radioButtonModeClient.TabStop = true;
            radioButtonModeClient.Text = "Клиент";
            radioButtonModeClient.UseVisualStyleBackColor = true;
            radioButtonModeClient.CheckedChanged += radioButtonModeClient_CheckedChanged;
            // 
            // radioButtonModeServer
            // 
            radioButtonModeServer.AutoSize = true;
            radioButtonModeServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonModeServer.Location = new Point(52, 94);
            radioButtonModeServer.Name = "radioButtonModeServer";
            radioButtonModeServer.Size = new Size(80, 25);
            radioButtonModeServer.TabIndex = 3;
            radioButtonModeServer.Text = "Сервер";
            radioButtonModeServer.UseVisualStyleBackColor = true;
            radioButtonModeServer.CheckedChanged += radioButtonModeServer_CheckedChanged;
            // 
            // labelIP
            // 
            labelIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelIP.AutoSize = true;
            labelIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIP.Location = new Point(161, 21);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(73, 21);
            labelIP.TabIndex = 4;
            labelIP.Text = "IP-адрес:";
            // 
            // textBoxIP
            // 
            textBoxIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxIP.Location = new Point(164, 49);
            textBoxIP.MaxLength = 15;
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(137, 23);
            textBoxIP.TabIndex = 5;
            // 
            // labelPort
            // 
            labelPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPort.AutoSize = true;
            labelPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPort.Location = new Point(161, 84);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(49, 21);
            labelPort.TabIndex = 6;
            labelPort.Text = "Порт:";
            // 
            // textBoxPort
            // 
            textBoxPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPort.Location = new Point(164, 112);
            textBoxPort.MaxLength = 5;
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(137, 23);
            textBoxPort.TabIndex = 7;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(18, 153);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(138, 23);
            buttonConnect.TabIndex = 8;
            buttonConnect.Text = "Соединиться";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonDisconnect.Location = new Point(164, 153);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new Size(138, 23);
            buttonDisconnect.TabIndex = 9;
            buttonDisconnect.Text = "Отключиться";
            buttonDisconnect.UseVisualStyleBackColor = true;
            buttonDisconnect.Click += buttonDisconnect_Click;
            // 
            // groupBoxSend
            // 
            groupBoxSend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSend.Controls.Add(buttonSender);
            groupBoxSend.Controls.Add(textBoxSender);
            groupBoxSend.Location = new Point(12, 245);
            groupBoxSend.Name = "groupBoxSend";
            groupBoxSend.Size = new Size(320, 76);
            groupBoxSend.TabIndex = 3;
            groupBoxSend.TabStop = false;
            groupBoxSend.Text = "Отправка";
            // 
            // buttonSender
            // 
            buttonSender.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSender.Location = new Point(239, 21);
            buttonSender.Name = "buttonSender";
            buttonSender.Size = new Size(75, 48);
            buttonSender.TabIndex = 1;
            buttonSender.Text = "Вперёд!";
            buttonSender.UseVisualStyleBackColor = true;
            buttonSender.Click += buttonSender_Click;
            // 
            // textBoxSender
            // 
            textBoxSender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSender.Location = new Point(6, 21);
            textBoxSender.Multiline = true;
            textBoxSender.Name = "textBoxSender";
            textBoxSender.Size = new Size(227, 46);
            textBoxSender.TabIndex = 0;
            // 
            // groupBoxRecieve
            // 
            groupBoxRecieve.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRecieve.Controls.Add(textBoxReciever);
            groupBoxRecieve.Location = new Point(12, 330);
            groupBoxRecieve.Name = "groupBoxRecieve";
            groupBoxRecieve.Size = new Size(320, 167);
            groupBoxRecieve.TabIndex = 4;
            groupBoxRecieve.TabStop = false;
            groupBoxRecieve.Text = "Прослушка";
            // 
            // textBoxReciever
            // 
            textBoxReciever.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxReciever.Location = new Point(6, 22);
            textBoxReciever.Multiline = true;
            textBoxReciever.Name = "textBoxReciever";
            textBoxReciever.ReadOnly = true;
            textBoxReciever.Size = new Size(308, 138);
            textBoxReciever.TabIndex = 0;
            // 
            // labelAuthor
            // 
            labelAuthor.Anchor = AnchorStyles.Top;
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new Point(139, 26);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(64, 15);
            labelAuthor.TabIndex = 5;
            labelAuthor.Text = "by dedalso";
            // 
            // DefaultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 509);
            Controls.Add(labelDescription);
            Controls.Add(labelAuthor);
            Controls.Add(groupBoxSetup);
            Controls.Add(groupBoxSend);
            Controls.Add(groupBoxRecieve);
            Name = "DefaultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TCP/IP прослушка";
            groupBoxSetup.ResumeLayout(false);
            groupBoxSetup.PerformLayout();
            groupBoxSend.ResumeLayout(false);
            groupBoxSend.PerformLayout();
            groupBoxRecieve.ResumeLayout(false);
            groupBoxRecieve.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDescription;
        private Label labelMode;
        private GroupBox groupBoxSetup;
        private GroupBox groupBoxSend;
        private Button buttonSender;
        private TextBox textBoxSender;
        private GroupBox groupBoxRecieve;
        private TextBox textBoxReciever;
        private RadioButton radioButtonModeServer;
        private RadioButton radioButtonModeClient;
        private Label labelIP;
        private TextBox textBoxIP;
        private TextBox textBoxPort;
        private Label labelPort;
        private Button buttonDisconnect;
        private Button buttonConnect;
        private Label labelAuthor;
    }
}