using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Resources;
using System.Text;

namespace TCP_Client_Server
{
    public partial class MainForm : Form
    {
        private const int MinimalWidth = 360;
        private const int MinimalHeight = 600;
        private readonly Color ColorSolid = Color.Black;
        private readonly Color ColorLessDimmed = Color.Gray;
        private readonly Color ColorDimmed = Color.FromArgb(160, 160, 160);
        private readonly Color ColorMoreDimmed = Color.FromArgb(200, 200, 200);
        private static ResourceManager? Local;
        private bool IsClient = true;
        private bool IsListening = false;
        private bool IsConnected = false;
        private string? ClientIP;
        private IPAddress IP = IPAddress.Any;
        private int Port;
        private TcpListener? Listener;
        private ClientProps LocalClient = new();
        private List<ClientProps>? ClientsList;
        private IAsyncResult? ConnectionStatus;
        private int Peer = 0;
        private List<int>? PeerIndexer;

        private struct ClientProps
        {
            public ClientProps(IPAddress ip, int port, TcpClient client, NetworkStream stream)
            {
                IP = ip;
                Port = port;
                Client = client;
                Stream = stream;
            }
            public IPAddress? IP { get; set; }
            public int? Port { get; set; }
            public TcpClient Client { get; set; }
            public NetworkStream Stream { get; set; }
        }

        public MainForm()
        {
            DefaultSetup();
            FormClosing += new FormClosingEventHandler(FormClose);
            InitializeComponent();
            FormSetup();
        }

        private static string? Localize(string name)
        {
            return Local?.GetString(name);
        }

        private void FormSetup()
        {
            MinimumSize = new Size(MinimalWidth, MinimalHeight);

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
            Local = new ResourceManager(typeof(MainForm).Namespace + ".Resources", typeof(Program).Assembly);
            IP = SearchForIP();
            Port = SearchForPort();
        }

        private bool SetIP()
        {
            string ip = TextBoxIP.Text;
            int status = ValidateIP(ip);

            if (status == -1)
            {
                ShowMessage(Localize("MessageIP"), Localize("MessageIPIsInvalid"));
                return false;
            }
            else if (status == -2)
            {
                ShowMessage(Localize("MessageIP"), Localize("MessageIPIsUnavailable"));
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
                ShowMessage(Localize("MessagePort"), Localize("MessagePortIsInvalid") + IPEndPoint.MaxPort + ".");
                return false;
            }
            else if (status == -2)
            {
                ShowMessage(Localize("MessagePort"), Localize("MessagePortOutOfRange") + IPEndPoint.MaxPort + ".");
                return false;
            }
            else if (status == -3)
            {
                ShowMessage(Localize("MessagePort"), Localize("MessagePortIsBusy"));
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
                    LocalClient.Client = new();
                    ConnectionStatus = LocalClient.Client.BeginConnect(IP, port, ConnectionCatched, null);
                }
                else
                {
                    Listener = new(IP, port);
                    ClientsList = new();
                    PeerIndexer = new();
                    Listener.Start();
                    ConnectionStatus = Listener.BeginAcceptTcpClient(ConnectionCatched, null);
                }
            }
            catch (SocketException)
            {
                ConnectionStop();
                throw new SocketException();
            }
            IsListening = true;
            ConnectionLocker(true);
        }

        private void ConnectionCatched(IAsyncResult ar)
        {
            if (ConnectionStatus != null)
            {
                try
                {
                    if (IsClient)
                    {
                        if (LocalClient.Client != null)
                        {
                            LocalClient.Client.EndConnect(ConnectionStatus);
                            IsListening = false;
                            LocalClient.Stream = LocalClient.Client.GetStream();
                            LocalClient.Client.NoDelay = true;
                            IPEndPoint? localEndPoint = (IPEndPoint?)LocalClient.Client.Client.LocalEndPoint;
                            IPEndPoint? remoteEndPoint = (IPEndPoint?)LocalClient.Client.Client.RemoteEndPoint;

                            if (localEndPoint != null)
                            {
                                LocalClient.IP = localEndPoint.Address.MapToIPv4();
                                LocalClient.Port = localEndPoint.Port;
                            }

                            if (remoteEndPoint != null)
                            {
                                IP = remoteEndPoint.Address.MapToIPv4();
                                Port = remoteEndPoint.Port;
                            }
                            AddPeer(IP, Port);
                            SelectPeer(Peer);
                            Print(Localize("OutputConnectionEvent") + " " + IP + ":" + Port + " " + Localize("OutputConnectionMade") + ".");
                        }
                        else
                        {
                            ShowMessage(Localize("MessageConnection"), Localize("MessageConnectionLost"), true);
                            ConnectionStop();
                            return;
                        }
                    }
                    else
                    {
                        if (Listener?.Server != null)
                        {
                            TcpClient? client = Listener?.EndAcceptTcpClient(ConnectionStatus);

                            if (ClientsList != null && client != null)
                            {
                                NetworkStream stream = client.GetStream();
                                client.NoDelay = true;
                                IPEndPoint? remoteEndPoint = (IPEndPoint?)client.Client.RemoteEndPoint;
                                IPAddress remoteIP;
                                int remotePort;

                                if (remoteEndPoint != null)
                                {
                                    remoteIP = remoteEndPoint.Address.MapToIPv4();
                                    remotePort = remoteEndPoint.Port;

                                    if (ClientsList != null && remoteEndPoint != null)
                                    {
                                        ClientsList.Add(new ClientProps(remoteIP, remotePort, client, stream));
                                        Peer = ClientsList.Count - 1;
                                    }
                                    AddPeer(remoteIP, remotePort);
                                    SelectPeer(Peer);
                                    Print(Localize("OutputConnectionEvent") + " " + remoteIP + ":" + remotePort + " " + Localize("OutputConnectionMade") + ".");
                                }
                                ConnectionStatus = Listener?.BeginAcceptTcpClient(ConnectionCatched, null);
                            }
                            else
                            {
                                ShowMessage(Localize("MessageConnection"), Localize("MessageConnectionLost"), true);
                                ConnectionStop();
                                return;
                            }
                        }
                    }
                }
                catch (Exception e) //Exception must be
                {
                    ConnectionStop();

                    if (e is SocketException)
                        ShowMessage(Localize("MessagePort"), Localize("MessagePortIsBusy"));
                    return;
                }
                IsConnected = true;
                Invoke(() =>
                {
                    if (Peer > 0)
                    {
                        LabelPeer.ForeColor = ColorSolid;
                        ComboBoxClients.Enabled = true;
                    }
                    ButtonSender.Enabled = true;
                });
                MessageRecieveCycle();
            }
        }

        private void ConnectionBreak(int peer)
        {
            if (ClientsList != null)
            {
                Print(Localize("OutputConnectionEvent") + " " + ClientsList[peer].IP + ":" + ClientsList[peer].Port + " " + Localize("OutputConnectionLost") + ".");
                ClientsList.RemoveAt(peer);
                PeerIndexer?.RemoveAt(peer);
                Peer = RemovePeer(peer);

                if (ClientsList.Count > 0)
                    SelectPeer(Peer);
                else
                {
                    ClearPeers();
                    IsConnected = false;
                }
            }
        }

        private void ConnectionStop(bool forServerToo = true)
        {
            LocalClient.Client?.Close();
            LocalClient.Stream?.Dispose();
            Listener?.Stop();
            Peer = 0;
            IsListening = false;
            IsConnected = false;
            Invoke(() =>
            {
                ConnectionLocker(false);
                ClearPeers();
            });

            if (forServerToo)
                ConnectionStopServer();
        }

        private void ConnectionStopServer()
        {
            if (ClientsList != null)
                foreach (ClientProps clientProps in ClientsList)
                {
                    clientProps.Client?.Close();
                    clientProps.Stream?.Dispose();
                }
            ClientsList = new();
            PeerIndexer = new();
        }

        private void MessageSend(string message)
        {
            NetworkStream? stream;

            if (IsClient)
                stream = LocalClient.Stream;
            else
                stream = ClientsList?[Peer].Stream;

            if (stream != null)
            {
                if (stream.CanWrite)
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    int length = messageBytes.Length;
                    byte[] lengthBytes = BitConverter.GetBytes(length);

                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(lengthBytes);

                    try
                    {
                        stream.Write(lengthBytes, 0, lengthBytes.Length);
                        stream.Write(messageBytes, 0, length);
                    }
                    catch (IOException)
                    {
                        ShowMessage(Localize("MessageConnection"), Localize("MessageConnectionLost"), true);
                        ConnectionStop();
                    }
                }
                else
                    ShowMessage(Localize("MessageSend"), Localize("MessageSendDenied"), true);
            }
        }

        private void MessageRecieveCycle()
        {
            Task.Run(() =>
            {
                PeerIndexer?.Add(Peer);
                int me = Peer;

                while (IsListening || IsConnected)
                {
                    Debug.Write("");

                    if (IsClient)
                    {
                        if (LocalClient.Client != null && LocalClient.Stream != null)
                        {
                            if (LocalClient.Stream.DataAvailable)
                                Print(IP + ":" + Port + " - " + MessagePull(Peer));
                            else if (LocalClient.Client.Client != null && LocalClient.Client.Client.Poll(1, SelectMode.SelectRead) && LocalClient.Client.Client.Available == 0)
                            {
                                Print(Localize("OutputConnectionEvent") + " " + IP + ":" + Port + " " + Localize("OutputConnectionLost") + ".");
                                ConnectionStop();
                            }
                        }
                    }
                    else
                    {
                        if (PeerIndexer != null)
                        {
                            if (me != PeerIndexer.Count)
                            {
                                if (me != PeerIndexer[me])
                                {
                                    me--;
                                    PeerIndexer[me] = me;
                                }
                            }
                            else
                            {
                                me--;
                                PeerIndexer[me] = me;
                            }


                            if (ClientsList != null)
                            {
                                if (ClientsList.Count > 0 && PeerIndexer[me] < ClientsList.Count)
                                {
                                    if (ClientsList[PeerIndexer[me]].Client != null && ClientsList[PeerIndexer[me]].Stream != null)
                                    {
                                        try
                                        {
                                            if (ClientsList[PeerIndexer[me]].Stream.DataAvailable)
                                                Print(ClientsList[PeerIndexer[me]].IP + ":" + ClientsList[PeerIndexer[me]].Port + " - " + MessagePull(PeerIndexer[me]));
                                            else if (ClientsList[PeerIndexer[me]].Client.Client != null)
                                            {
                                                if (ClientsList[PeerIndexer[me]].Client.Client.Poll(1, SelectMode.SelectRead) && ClientsList[PeerIndexer[me]].Client.Client.Available == 0)
                                                {
                                                    ConnectionBreak(PeerIndexer[me]);
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                ConnectionBreak(PeerIndexer[me]);
                                                break;
                                            }
                                        }
                                        catch (Exception) { }
                                    }
                                    else
                                    {
                                        ConnectionBreak(PeerIndexer[me]);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ConnectionStop();
                                break;
                            }
                        }
                        else
                        {
                            ConnectionStop();
                            break;
                        }
                    }
                }
            });
        }

        private string? MessagePull(int peer)
        {
            byte[]? lengthBytes = MessageReadBytes(peer, sizeof(int));

            if (lengthBytes != null)
            {
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(lengthBytes);
                int length = BitConverter.ToInt32(lengthBytes, 0);
                byte[]? messageBytes = MessageReadBytes(peer, length);

                if (messageBytes != null)
                    return Encoding.UTF8.GetString(messageBytes);
                else
                {
                    ShowMessage(Localize("MessageConnection"), Localize("MessageConnectionLost"), true);
                    return null;
                }
            }
            return null;
        }

        private byte[]? MessageReadBytes(int peer, int count)
        {
            byte[]? bytes = null;
            NetworkStream? stream;

            if (IsClient)
                stream = LocalClient.Stream;
            else
                stream = ClientsList?[peer].Stream;

            if (stream != null)
            {
                try
                {
                    bytes = new byte[count];
                    int readedCount = 0;

                    while (readedCount < count)
                    {
                        int l = count - readedCount;
                        int r = stream.Read(bytes, readedCount, l);

                        if (r == 0)
                        {
                            ShowMessage(Localize("MessageConnection"), Localize("MessageConnectionLost"), true);
                            ConnectionBreak(peer);
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

        private void ConnectionLocker(bool status)
        {
            if (status)
            {
                LabelMode.ForeColor = ColorDimmed;
                RadioButtonModeClient.Enabled = false;
                RadioButtonModeServer.Enabled = false;
                LabelIP.ForeColor = ColorDimmed;
                TextBoxIP.Enabled = false;
                LabelPort.ForeColor = ColorDimmed;
                TextBoxPort.ReadOnly = true;
                ButtonConnect.Enabled = false;
                ButtonDisconnect.Enabled = true;
                ButtonSender.Enabled = false;
            }
            else
            {
                LabelMode.ForeColor = ColorSolid;
                RadioButtonModeClient.Enabled = true;
                RadioButtonModeServer.Enabled = true;
                LabelIP.ForeColor = ColorSolid;

                if (IsClient)
                    TextBoxIP.Enabled = true;
                else
                    TextBoxIP.Enabled = false;
                LabelPort.ForeColor = ColorSolid;
                TextBoxPort.ReadOnly = false;
                ButtonConnect.Enabled = true;
                ButtonDisconnect.Enabled = false;
                ComboBoxClients.Enabled = false;
                LabelPeer.ForeColor = ColorMoreDimmed;
                ButtonSender.Enabled = false;
            }
        }

        private void AddPeer(IPAddress ip, int port)
        {
            Invoke(() =>
            {
                ComboBoxClients.Items.Add(ip + ":" + port);
                int peersCount = ComboBoxClients.Items.Count;

                if (peersCount > 1)
                {
                    ComboBoxClients.Enabled = true;
                    LabelPeer.ForeColor = ColorSolid;
                }
                else
                    LabelPeer.ForeColor = ColorLessDimmed;
            });
        }

        private int RemovePeer(int peer)
        {
            Invoke(() =>
            {
                ComboBoxClients.Items.RemoveAt(peer);
                int peersCount = ComboBoxClients.Items.Count;

                if (peersCount == 1)
                {
                    ComboBoxClients.Enabled = false;
                    LabelPeer.ForeColor = ColorLessDimmed;
                }
                return peersCount - 1;
            });
            return 0;
        }

        private void SelectPeer(int peer)
        {
            Invoke(() =>
            {
                ComboBoxClients.SelectedIndex = peer;
            });
        }

        private void ClearPeers()
        {
            Invoke(() =>
            {
                LabelPeer.ForeColor = ColorMoreDimmed;
                ComboBoxClients.Items.Clear();
                ComboBoxClients.Enabled = false;
                ButtonSender.Enabled = false;
            });
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

        private void ShowMessage(string? title, string? message, bool identifyMe = false)
        {
            string caller = "";

            if (IsConnected)
            {
                IPEndPoint? localEndPoint = (IPEndPoint?)ClientsList?[0].Client.Client.LocalEndPoint;
                caller = " (" + (IsClient ? LocalClient.IP : localEndPoint?.Address) + ":" + (IsClient ? LocalClient.Port : localEndPoint?.Port) + ")";
            }
            MessageBox.Show(message, title + (identifyMe ? caller : ""));
        }

        private void RadioButtonModeClient_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = true;
            ButtonConnect.Text = Localize("LabelClientStart");
            ButtonDisconnect.Text = Localize("LabelClientStop");

            if (RadioButtonModeClient.Checked)
                TextBoxIP.Text = ClientIP;
            TextBoxIP.Enabled = true;
        }

        private void RadioButtonModeServer_CheckedChanged(object sender, EventArgs e)
        {
            IsClient = false;
            ButtonConnect.Text = Localize("LabelServerStart");
            ButtonDisconnect.Text = Localize("LabelServerStop");

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
            {
                if (IsClient)
                    Print(Localize("OutputConnectionEvent") + " " + IP + ":" + Port + " " + Localize("OutputConnectionLost") + ".");
                else
                {
                    string? lostMessage = Localize("OutputConnectionAllWereLost");

                    if (lostMessage != null)
                        Print(lostMessage);
                }
            }
            ConnectionStop(false);
        }

        private void ComboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            Peer = ComboBoxClients.FindString(ComboBoxClients.SelectedItem.ToString());
        }

        private void ButtonSender_Click(object sender, EventArgs e)
        {
            if (IsConnected && TextBoxSender.Text != string.Empty)
            {
                MessageSend(TextBoxSender.Text);
                TextBoxSender.Text = string.Empty;
            }
        }
    }
}