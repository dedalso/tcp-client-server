using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_Client_Server
{
    public partial class DefaultForm : Form
    {
        private int MinimalWidth = 360;
        private int MinimalHeight = 548;
        private bool IsClient = true;
        private bool IsConnected = false;
        private IPAddress IP = IPAddress.Any;
        private int Port;
        private const int PortMaximum = 65536;
        private TcpListener Listener;
        private TcpClient Client;

        public DefaultForm()
        {
            InitializeComponent();
            DefaultSetup();
            FormSetup();
        }

        private void FormSetup()
        {
            this.MinimumSize = new Size(MinimalWidth, MinimalHeight);
            textBoxIP.Text = IP.ToString();
            textBoxPort.Text = Port.ToString();
            ConnectionLocker(false);
        }

        private void DefaultSetup()
        {
            //IP = SearchForIP();
            Port = SearchForPort();
        }

        private bool SetIP()
        {
            string ip = textBoxIP.Text;
            int status = ValidateIP(ip);

            if (status == -1)
            {
                MessageBox.Show("Ошибка IP", "IP введён в некорректном формате.");
                return false;
            }
            // Проверить IP
            IP = IPAddress.Parse(ip);
            return true;
        }

        private bool SetPort()
        {
            string port = textBoxPort.Text;
            int status = ValidatePort(port);

            if (status == -1)
            {
                MessageBox.Show("Ошибка порта", "Порт введён в нечисловом формате. Задайте порт от 0 до " + PortMaximum + ".");
                return false;
            }
            else if (status == -2)
            {
                MessageBox.Show("Ошибка порта", "Невозможное значение порта. Задайте порт от 0 до " + PortMaximum + ".");
                return false;
            }
            else if (status == -3)
            {
                MessageBox.Show("Ошибка порта", "Указанный порт занят. Выберите другой порт.");
                return false;
            }
            Port = int.Parse(port);
            return true;
        }

        private int ValidateIP(string ipWanted)
        {
            try
            {
                if (!IPAddress.TryParse(ipWanted, out _))
                    return -1;
            }
            catch (Exception)
            {
                return -1;
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

            if (port > 0 && port < PortMaximum)
            {
                try
                {
                    TcpListener listener = new TcpListener(IP, port);
                    listener.Start();
                    listener.Stop();
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

        private IPAddress SearchForIP()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            IPAddress ip = IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            listener.Stop();
            return ip;
        }

        private int SearchForPort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        private void ConnectionStart()
        {
            IPEndPoint endPoint = new IPEndPoint(IP, Port);

            if (IsClient)
            {
                Client = new TcpClient();
                Client.ConnectAsync(endPoint);
            }
            else
            {
                Listener = new TcpListener(endPoint);
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
            textBoxReciever.Text = Encoding.Default.GetString(message, 0, count);
            //}
            //}
        }

        private void ConnectionStop()
        {
            if (!IsClient)
                Listener.Stop();
        }

        private void ConnectionLocker(bool status)
        {
            if (status)
            {
                radioButtonModeClient.Enabled = false;
                radioButtonModeServer.Enabled = false;
                textBoxIP.Enabled = false;
                textBoxPort.Enabled = false;
                buttonConnect.Enabled = false;
                buttonDisconnect.Enabled = true;
                buttonSender.Enabled = true;
            }
            else
            {
                radioButtonModeClient.Enabled = true;
                radioButtonModeServer.Enabled = true;
                textBoxIP.Enabled = true;
                textBoxPort.Enabled = true;
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                buttonSender.Enabled = false;
            }
        }

        private void radioButtonModeClient_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = true;
        }

        private void radioButtonModeServer_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
                if (SetIP() && SetPort())
                {
                    ConnectionStart();
                    IsConnected = true;
                    ConnectionLocker(true);
                }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                ConnectionStop();
                IsConnected = false;
                ConnectionLocker(false);
            }
        }

        private void buttonSender_Click(object sender, EventArgs e)
        {

        }
    }
}