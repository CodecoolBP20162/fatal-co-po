using System.Windows;
using GettingStartedLib;

namespace Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            ClientConnection client = ClientConnection.GetInstance();
            client.SetupChannels();
            IWcfPingTest channel = client.channels[0];
            string result = channel.Ping();
            tbSomething.Text = result;
            foreach(var item in channel.GetComputerInfo())
            {
                computerInfo.Items.Add(item);
            }
        }

        private void screenshotButton_Click(object sender, RoutedEventArgs e)
        {
            ClientConnection client = ClientConnection.GetInstance();
            client.SaveScreenShot(0);
        }
    }
}
