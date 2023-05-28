namespace TCP_Client_Server
{
    public partial class DefaultForm : Form
    {
        private int MinimalWidth = 360;
        private int MinimalHeight = 548;

        public DefaultForm()
        {
            WindowSetup();
            InitializeComponent();
        }

        private void WindowSetup()
        {
            this.MinimumSize = new Size(MinimalWidth, MinimalHeight);
        }
    }
}