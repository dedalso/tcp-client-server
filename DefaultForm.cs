using System.Diagnostics;
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
        private const string ClientStart = "Соединиться";
        private const string ClientStop = "Отключиться";
        private const string ServerStart = "Слушать порт";
        private const string ServerStop = "Закрыть порт";
        private bool IsClient = true;
        private bool IsListening = false;
        private bool IsConnected = false;
        private string? ClientIP;
        private IPAddress IP = IPAddress.Any;
        private IPAddress RemoteIP = IPAddress.Any;
        private int Port;
        private int RemotePort;
        private TcpListener? Listener;
        private TcpClient? Client;
        private IAsyncResult? ConnectionStatus;
        private NetworkStream? DataStream;

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

            if (IsClient)
                RadioButtonModeClient.Checked = true;
            else
                RadioButtonModeServer.Checked = true;
            TextBoxIP.Text = IP.ToString();
            TextBoxPort.Text = Port.ToString();
            ConnectionLocker(false);
        }

        private void FormClose(object? sender, FormClosingEventArgs e)
        {
            ConnectionStop();
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
                MessageBox.Show("Указанный порт занят или закрыт.", messageTitle);
                return false;
            }
            Port = int.Parse(port);
            return true;
        }

        private static int ValidateIP(string ipWanted)
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
                Ping pinger = new();
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
                ConnectionStatus = Client.BeginConnect(IP, Port, ConnectionCatched, null);
            }
            else
            {
                Listener = new TcpListener(IP, Port);
                Listener.Start();
                ConnectionStatus = Listener.BeginAcceptTcpClient(ConnectionCatched, null);
                IsListening = true;
                MessageRecieveCycle();
            }
        }

        private void ConnectionCatched(IAsyncResult ar)
        {
            if (ConnectionStatus != null)
            {
                if (IsClient)
                {
                    try
                    {
                        Client?.EndConnect(ConnectionStatus);
                        DataStream = Client?.GetStream();
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                }
                else
                {
                    try
                    {
                        Client = Listener?.EndAcceptTcpClient(ConnectionStatus);
                        DataStream = Client?.GetStream();
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                }

                if (Client != null)
                {
                    IsConnected = true;
                    IPEndPoint? remoteEndPoint = (IPEndPoint?)Client.Client.RemoteEndPoint;

                    if (remoteEndPoint != null)
                    {
                        RemoteIP = remoteEndPoint.Address.MapToIPv4();
                        RemotePort = remoteEndPoint.Port;
                    }
                    Print("Соединение с " + RemoteIP + ":" + RemotePort + " было установлено.");
                }
            }
        }

        /* private async void ConnectionCycle()
        {
            if (IsClient)
            {

            }
            else
            {
                await MessageRecieve();
                await Task.Factory.StartNew(async () =>
                {
                    await MessageRecieve();
                });
            }
        } */

        private void ConnectionStop()
        {
            Client?.Close();
            Listener?.Stop();
            DataStream?.Dispose();
            IsListening = false;
            IsConnected = false;
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

        private void MessageSend(string message)
        {
            if (IsClient)
            {
                if (Client != null && DataStream != null)
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    int length = messageBytes.Length;
                    byte[] lengthBytes = BitConverter.GetBytes(length);

                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(lengthBytes);
                    DataStream.Write(lengthBytes, 0, lengthBytes.Length);
                    DataStream.Write(messageBytes, 0, length);
                }
            }
            else
            {
                //
            }
        }

        private void MessageRecieveCycle()
        {
            Task.Run(() =>
            {
                while (IsListening)
                {
                    if (IsConnected && DataStream != null)
                        if (DataStream.DataAvailable)
                            Print(MessagePull());
                }
            });
        }

        private string MessagePull()
        {
            if (IsClient)
            {

            }
            else
            {
                byte[]? lengthBytes = MessageReadBytes(sizeof(int)).Result;

                if (lengthBytes != null)
                {
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(lengthBytes);
                    int length = BitConverter.ToInt32(lengthBytes, 0);
                    byte[]? messageBytes = MessageReadBytes(length).Result;

                    if (messageBytes != null)
                    {
                        string message = Encoding.UTF8.GetString(messageBytes);
                        return message;
                    }
                }
            }
            return "";
        }

        private async Task<byte[]?> MessageReadBytes(int count)
        {
            byte[]? bytes = null;

            if (Client != null && DataStream != null)
            {
                try
                {
                    bytes = new byte[count];
                    await DataStream.ReadAsync(bytes, 0, count);
                    /* int readedCount = 0;

                    while (Client.Connected && readedCount < count)
                    {
                        int l = count - readedCount;
                        int r = DataStream.Read(bytes, readedCount, l);

                        if (r == 0)
                        {
                            //throw new Exception("Соединение потерено при передаче данных.");
                        }
                        readedCount += r;
                    } */
                }
                catch (ObjectDisposedException)
                {
                    return null;
                }
            }
            return bytes;
        }

        private void Print(string message)
        {
            if (message != string.Empty)
            {
                DateTime time = DateTime.Now;

                Invoke(() =>
                {
                    TextBoxReciever.Text += time.ToString("[HH:mm:ss]") + " " + message + Environment.NewLine;
                    TextBoxReciever.SelectionStart = TextBoxReciever.Text.Length;
                    TextBoxReciever.ScrollToCaret();
                });
            }
        }

        private void RadioButtonModeClient_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = true;
            ButtonConnect.Text = ClientStart;
            ButtonDisconnect.Text = ClientStop;

            if (RadioButtonModeClient.Checked)
                TextBoxIP.Text = ClientIP;
            TextBoxIP.Enabled = true;
        }

        private void RadioButtonModeServer_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = false;
            ButtonConnect.Text = ServerStart;
            ButtonDisconnect.Text = ServerStop;

            if (RadioButtonModeServer.Checked)
                ClientIP = TextBoxIP.Text;
            TextBoxIP.Text = SearchForIP().ToString();
            TextBoxIP.Enabled = false;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (!IsListening && !IsConnected)
                if (SetIP() && SetPort())
                {
                    ConnectionStart();
                    ConnectionLocker(true);
                }
        }

        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            ConnectionStop();
            ConnectionLocker(false);
        }

        private void ButtonSender_Click(object sender, EventArgs e)
        {
            if (TextBoxSender.Text != String.Empty)
            {
                MessageSend(TextBoxSender.Text);
                TextBoxSender.Text = string.Empty;
            }
        }
    }
}