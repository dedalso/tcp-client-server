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
            buttonDisconnect = new Button();
            buttonConnect = new Button();
            textBoxPort = new TextBox();
            labelPort = new Label();
            textBox2 = new TextBox();
            labelIP = new Label();
            radioButtonModeServer = new RadioButton();
            radioButtonModeClient = new RadioButton();
            groupBoxSend = new GroupBox();
            button1 = new Button();
            textBoxSender = new TextBox();
            groupBoxRecieve = new GroupBox();
            textBox1 = new TextBox();
            groupBoxSetup.SuspendLayout();
            groupBoxSend.SuspendLayout();
            groupBoxRecieve.SuspendLayout();
            SuspendLayout();
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescription.Location = new Point(70, 9);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(200, 25);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "TCP/IP клиент-сервер";
            // 
            // labelMode
            // 
            labelMode.AutoSize = true;
            labelMode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelMode.Location = new Point(26, 41);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(62, 21);
            labelMode.TabIndex = 1;
            labelMode.Text = "Режим:";
            // 
            // groupBoxSetup
            // 
            groupBoxSetup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSetup.Controls.Add(buttonDisconnect);
            groupBoxSetup.Controls.Add(buttonConnect);
            groupBoxSetup.Controls.Add(textBoxPort);
            groupBoxSetup.Controls.Add(labelPort);
            groupBoxSetup.Controls.Add(textBox2);
            groupBoxSetup.Controls.Add(labelIP);
            groupBoxSetup.Controls.Add(radioButtonModeServer);
            groupBoxSetup.Controls.Add(radioButtonModeClient);
            groupBoxSetup.Controls.Add(labelMode);
            groupBoxSetup.Location = new Point(12, 40);
            groupBoxSetup.Name = "groupBoxSetup";
            groupBoxSetup.Size = new Size(320, 195);
            groupBoxSetup.TabIndex = 2;
            groupBoxSetup.TabStop = false;
            groupBoxSetup.Text = "Настройки";
            // 
            // buttonDisconnect
            // 
            buttonDisconnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDisconnect.Location = new Point(12, 154);
            buttonDisconnect.Name = "buttonDisconnect";
            buttonDisconnect.Size = new Size(138, 23);
            buttonDisconnect.TabIndex = 9;
            buttonDisconnect.Text = "Отключиться";
            buttonDisconnect.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            buttonConnect.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonConnect.Location = new Point(18, 154);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(0, 23);
            buttonConnect.TabIndex = 8;
            buttonConnect.Text = "Соединиться";
            buttonConnect.UseVisualStyleBackColor = true;
            // 
            // textBoxPort
            // 
            textBoxPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPort.Location = new Point(155, 112);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(0, 23);
            textBoxPort.TabIndex = 7;
            // 
            // labelPort
            // 
            labelPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelPort.AutoSize = true;
            labelPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPort.Location = new Point(155, 84);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(49, 21);
            labelPort.TabIndex = 6;
            labelPort.Text = "Порт:";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(155, 49);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(0, 23);
            textBox2.TabIndex = 5;
            // 
            // labelIP
            // 
            labelIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelIP.AutoSize = true;
            labelIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelIP.Location = new Point(155, 21);
            labelIP.Name = "labelIP";
            labelIP.Size = new Size(73, 21);
            labelIP.TabIndex = 4;
            labelIP.Text = "IP-адрес:";
            // 
            // radioButtonModeServer
            // 
            radioButtonModeServer.AutoSize = true;
            radioButtonModeServer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonModeServer.Location = new Point(46, 92);
            radioButtonModeServer.Name = "radioButtonModeServer";
            radioButtonModeServer.Size = new Size(80, 25);
            radioButtonModeServer.TabIndex = 3;
            radioButtonModeServer.Text = "Сервер";
            radioButtonModeServer.UseVisualStyleBackColor = true;
            // 
            // radioButtonModeClient
            // 
            radioButtonModeClient.AutoSize = true;
            radioButtonModeClient.Checked = true;
            radioButtonModeClient.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonModeClient.Location = new Point(46, 65);
            radioButtonModeClient.Name = "radioButtonModeClient";
            radioButtonModeClient.Size = new Size(78, 25);
            radioButtonModeClient.TabIndex = 2;
            radioButtonModeClient.TabStop = true;
            radioButtonModeClient.Text = "Клиент";
            radioButtonModeClient.UseVisualStyleBackColor = true;
            // 
            // groupBoxSend
            // 
            groupBoxSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxSend.Controls.Add(button1);
            groupBoxSend.Controls.Add(textBoxSender);
            groupBoxSend.Location = new Point(12, 245);
            groupBoxSend.Name = "groupBoxSend";
            groupBoxSend.Size = new Size(320, 75);
            groupBoxSend.TabIndex = 3;
            groupBoxSend.TabStop = false;
            groupBoxSend.Text = "Отправка";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(87, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 47);
            button1.TabIndex = 1;
            button1.Text = "Вперёд!";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBoxSender
            // 
            textBoxSender.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSender.Location = new Point(6, 22);
            textBoxSender.Multiline = true;
            textBoxSender.Name = "textBoxSender";
            textBoxSender.Size = new Size(75, 46);
            textBoxSender.TabIndex = 0;
            // 
            // groupBoxRecieve
            // 
            groupBoxRecieve.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxRecieve.Controls.Add(textBox1);
            groupBoxRecieve.Location = new Point(12, 330);
            groupBoxRecieve.Name = "groupBoxRecieve";
            groupBoxRecieve.Size = new Size(320, 167);
            groupBoxRecieve.TabIndex = 4;
            groupBoxRecieve.TabStop = false;
            groupBoxRecieve.Text = "Прослушка";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(6, 22);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(156, 138);
            textBox1.TabIndex = 0;
            // 
            // DefaultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 509);
            Controls.Add(groupBoxRecieve);
            Controls.Add(groupBoxSend);
            Controls.Add(groupBoxSetup);
            Controls.Add(labelDescription);
            Name = "DefaultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TCP/IP клиент";
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
        private Button button1;
        private TextBox textBoxSender;
        private GroupBox groupBoxRecieve;
        private TextBox textBox1;
        private RadioButton radioButtonModeServer;
        private RadioButton radioButtonModeClient;
        private Label labelIP;
        private TextBox textBox2;
        private TextBox textBoxPort;
        private Label labelPort;
        private Button buttonDisconnect;
        private Button buttonConnect;
    }
}