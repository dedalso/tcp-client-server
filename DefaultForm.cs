using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private const string PortErrorTitle = "Ошибка порта";
        private const string PortIsUnavailableMessage = "Указанный порт занят или закрыт.";
        private const string LostConnectionTitle = "Ошибка соединения";
        private const string LostConnectionMessage = "Подключение было разорвано.";

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

            if (status == -1)
            {
                MessageBox.Show("Порт введён в нечисловом формате. Задайте порт от 0 до " + IPEndPoint.MaxPort + ".", PortErrorTitle);
                return false;
            }
            else if (status == -2)
            {
                MessageBox.Show("Невозможное значение порта. Задайте порт от 0 до " + IPEndPoint.MaxPort + ".", PortErrorTitle);
                return false;
            }
            else if (status == -3)
            {
                MessageBox.Show(PortIsUnavailableMessage, PortErrorTitle);
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
                    ConnectionStart(port);
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

        private void ConnectionStart(int port)
        {
            try
            {
                if (IsClient)
                {
                    Client = new();
                    ConnectionStatus = Client.BeginConnect(IP, port, ConnectionCatched, null);
                }
                else
                {
                    Listener = new(IP, port);
                    Listener.Start();
                    ConnectionStatus = Listener.BeginAcceptTcpClient(ConnectionCatched, null);
                }
            }
            catch (SocketException)
            {
                Client?.Close();
                Listener?.Stop();
                throw new SocketException();
            }
            IsListening = true;
            MessageRecieveCycle();
            ConnectionLocker(true);
        }

        private void ConnectionCatched(IAsyncResult ar)
        {
            if (ConnectionStatus != null)
            {
                try
                {
                    if (IsClient)
                        Client?.EndConnect(ConnectionStatus);
                    else
                        Client = Listener?.EndAcceptTcpClient(ConnectionStatus);
                }
                catch (Exception e)
                {
                    ConnectionStop();

                    if (e is SocketException)
                        MessageBox.Show(PortIsUnavailableMessage, PortErrorTitle);
                    return;
                }

                if (Client != null)
                {
                    IsConnected = true;
                    IsListening = false;
                    DataStream = Client.GetStream();
                    Client.NoDelay = true;
                    IPEndPoint? remoteEndPoint = (IPEndPoint?)Client.Client.RemoteEndPoint;

                    if (remoteEndPoint != null)
                    {
                        RemoteIP = remoteEndPoint.Address.MapToIPv4();
                        RemotePort = remoteEndPoint.Port;
                    }
                    Invoke(() =>
                    {
                        ButtonSender.Enabled = true;
                    });
                    Print("Соединение с " + RemoteIP + ":" + RemotePort + " было установлено.");
                }
            }
        }

        private void ConnectionStop()
        {
            Client?.Close();
            Listener?.Stop();
            DataStream?.Dispose();
            IsListening = false;
            IsConnected = false;
            Invoke(() =>
            {
                ConnectionLocker(false);
            });
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
                ButtonSender.Enabled = false;
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
            if (Client != null && DataStream != null)
            {
                if (DataStream.CanWrite)
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    int length = messageBytes.Length;
                    byte[] lengthBytes = BitConverter.GetBytes(length);

                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(lengthBytes);

                    try
                    {
                        DataStream.Write(lengthBytes, 0, lengthBytes.Length);
                        DataStream.Write(messageBytes, 0, length);
                    }
                    catch (IOException)
                    {
                        ConnectionStop();
                        MessageBox.Show(LostConnectionMessage, LostConnectionTitle);
                    }
                }
                else
                    MessageBox.Show("Сейчас отправка невозможна, так как идёт запись в сетевой поток.", "Ошибка отправки");
            }
        }

        private void MessageRecieveCycle()
        {
            Task.Run(() =>
            {
                while (IsListening != IsConnected)
                {
                    Debug.WriteLine("...");

                    if (Client != null && DataStream != null)
                    {
                        try
                        {
                            if (DataStream.DataAvailable)
                                Print(RemoteIP + ":" + RemotePort + " - " + MessagePull());
                            else if (Client.Client != null && Client.Client.Poll(1, SelectMode.SelectRead) && Client.Client.Available == 0)
                            {
                                ConnectionStop();
                                Print("Соединение с " + RemoteIP + ":" + RemotePort + " было разорвано.");
                            }
                        }
                        catch (Exception) { }
                    }
                }
            });
        }

        private string? MessagePull()
        {
            byte[]? lengthBytes = MessageReadBytes(sizeof(int));

            if (lengthBytes != null)
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(lengthBytes);
                int length = BitConverter.ToInt32(lengthBytes, 0);
                byte[]? messageBytes = MessageReadBytes(length);

                if (messageBytes != null)
                    return Encoding.UTF8.GetString(messageBytes);
                else
                {
                    MessageBox.Show(LostConnectionMessage, LostConnectionTitle);
                    return null;
                }
            }
            return null;
        }

        private byte[]? MessageReadBytes(int count)
        {
            byte[]? bytes = null;

            if (DataStream != null)
            {
                try
                {
                    bytes = new byte[count];
                    int readedCount = 0;

                    while (readedCount < count)
                    {
                        int l = count - readedCount;
                        int r = DataStream.Read(bytes, readedCount, l);

                        if (r == 0)
                        {
                            ConnectionStop();
                            MessageBox.Show(LostConnectionMessage, LostConnectionTitle);
                            return null;
                        }
                        readedCount += r;
                    }
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
            DateTime time = DateTime.Now;

            Invoke(() =>
            {
                TextBoxReciever.Text += time.ToString("[HH:mm:ss]") + " " + message + Environment.NewLine;
                TextBoxReciever.SelectionStart = TextBoxReciever.Text.Length;
                TextBoxReciever.ScrollToCaret();
            });
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
                if (SetIP())
                    SetPort();
        }

        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            if (IsConnected)
                Print("Соединение с " + RemoteIP + ":" + RemotePort + " было разорвано.");
            ConnectionStop();
        }

        private void ButtonSender_Click(object sender, EventArgs e)
        {
            if (IsConnected && TextBoxSender.Text != String.Empty)
            {
                MessageSend(TextBoxSender.Text);
                TextBoxSender.Text = string.Empty;
            }
        }
    }
}