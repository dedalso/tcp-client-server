using System.Buffers;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace TCP_Client_Server
{
    public partial class DefaultForm : Form
    {
        private const int MinimalWidth = 360;
        private const int MinimalHeight = 548;
        private bool IsClient = true;
        private bool IsConnected = false;
        private string? ClientIP;
        private IPAddress IP = IPAddress.Any;
        private int Port;
        private TcpListener? Listener;
        private TcpClient? Client;

        public DefaultForm()
        {
            DefaultSetup();
            this.FormClosing += new FormClosingEventHandler(FormClose);
            InitializeComponent();
            FormSetup();
        }

        private void FormSetup()
        {
            this.MinimumSize = new Size(MinimalWidth, MinimalHeight);
            TextBoxIP.Text = IP.ToString();
            TextBoxPort.Text = Port.ToString();
            ConnectionLocker(false);
        }

        private void FormClose(object? sender, FormClosingEventArgs e)
        {
            if (IsClient)
            {
                Listener?.Stop();
            }
            else
                Client?.Close();
        }

        private void DefaultSetup()
        {
            IP = SearchForIP();
            Port = SearchForPort();
        }

        private bool SetIP()
        {
            string ip = TextBoxIP.Text;
            int status = ValidateIP(ip);
            string messageTitle = "Ошибка IP";

            if (status == -1)
            {
                MessageBox.Show("IP введён в некорректном формате.", messageTitle);
                return false;
            }
            else if (status == -2)
            {
                MessageBox.Show("Указанный порт по этому IP недоступен.", messageTitle);
                return false;
            }
            IP = IPAddress.Parse(ip);
            return true;
        }

        private bool SetPort()
        {
            string port = TextBoxPort.Text;
            int status = ValidatePort(port);
            string messageTitle = "Ошибка порта";

            if (status == -1)
            {
                MessageBox.Show("Порт введён в нечисловом формате. Задайте порт от 0 до " + IPEndPoint.MaxPort + ".", messageTitle);
                return false;
            }
            else if (status == -2)
            {
                MessageBox.Show("Невозможное значение порта. Задайте порт от 0 до " + IPEndPoint.MaxPort + ".", messageTitle);
                return false;
            }
            else if (status == -3)
            {
                MessageBox.Show("Указанный порт занят или закрыт. Выберите другой порт.", messageTitle);
                return false;
            }
            Port = int.Parse(port);
            return true;
        }

        private int ValidateIP(string ipWanted)
        {
            IPAddress? ip;

            try
            {
                if (!IPAddress.TryParse(ipWanted, out ip))
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }

            try
            {
                Ping pinger = new Ping();
                PingReply reply = pinger.Send(ip);
            }
            catch (PingException)
            {
                return -2;
            }
            return 1;
        }

        private int ValidatePort(string portWanted)
        {
            int port;

            try
            {
                port = int.Parse(portWanted);
            }
            catch (Exception)
            {
                return -1;
            }

            if (port >= 0 && port <= IPEndPoint.MaxPort)
            {
                try
                {
                    if (IsClient)
                    {
                        TcpClient client = new();
                        client.Connect(IP, port);
                        client.Close();
                    }
                    else
                    {
                        TcpListener listener = new(IP, port);
                        listener.Start();
                        listener.Stop();
                    }
                }
                catch (SocketException)
                {
                    return -3;
                }
            }
            else
                return -2;
            return 1;
        }

        private static IPAddress SearchForIP()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(addr => addr.AddressFamily == AddressFamily.InterNetwork);
        }

        private static int SearchForPort()
        {
            TcpListener listener = new(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        private void ConnectionStart()
        {
            if (IsClient)
            {
                Client = new TcpClient();
                Client.Connect(IP, Port);
            }
            else
            {
                Listener = new TcpListener(IP, Port);
                Listener.Start();
            }
        }

        private void ConnectionCycle()
        {
            //while (true)
            //{
            Client = Listener.AcceptTcpClient();
            NetworkStream stream = Client.GetStream();
            byte[] getThis = new byte[100];
            getThis = Encoding.Default.GetBytes("Get this!");
            stream.Write(getThis, 0, getThis.Length);

            //while (Client.Connected)
            //{
            byte[] message = new byte[1024];
            int count = stream.Read(message, 0, message.Length);
            TextBoxReciever.Text = Encoding.Default.GetString(message, 0, count);
            //}
            //}
        }

        private void ConnectionStop()
        {
            if (IsClient)
                Client?.Close();
            else
                Listener?.Stop();
        }

        private void ConnectionLocker(bool status)
        {
            if (status)
            {
                RadioButtonModeClient.Enabled = false;
                RadioButtonModeServer.Enabled = false;
                TextBoxIP.Enabled = false;
                TextBoxPort.ReadOnly = true;
                ButtonConnect.Enabled = false;
                ButtonDisconnect.Enabled = true;
                ButtonSender.Enabled = true;
            }
            else
            {
                RadioButtonModeClient.Enabled = true;
                RadioButtonModeServer.Enabled = true;

                if (IsClient)
                    TextBoxIP.Enabled = true;
                else
                    TextBoxIP.Enabled = false;
                TextBoxPort.ReadOnly = false;
                ButtonConnect.Enabled = true;
                ButtonDisconnect.Enabled = false;
                ButtonSender.Enabled = false;
            }
        }

        private void RadioButtonModeClient_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = true;

            if (RadioButtonModeClient.Checked)
                TextBoxIP.Text = ClientIP;
            TextBoxIP.Enabled = true;
        }

        private void RadioButtonModeServer_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = false;

            if (RadioButtonModeServer.Checked)
                ClientIP = TextBoxIP.Text;
            TextBoxIP.Text = SearchForIP().ToString();
            TextBoxIP.Enabled = false;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
                if (SetIP() && SetPort())
                {
                    ConnectionStart();
                    IsConnected = true;
                    ConnectionLocker(true);
                }
        }

        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                ConnectionStop();
                IsConnected = false;
                ConnectionLocker(false);
            }
        }

        private void ButtonSender_Click(object sender, EventArgs e)
        {

        }
    }
}