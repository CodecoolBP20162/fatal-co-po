using System;
using System.Windows;
using System.ServiceModel.Discovery;
using GettingStartedLib;
using System.ServiceModel;

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
            ClientConnection client = ClientConnection.GetInstance;
            client.SetupChannels();
            IWcfPingTest channel = client.Channels[0];
            string result = channel.Ping();
            tbSomething.Text = result;
        }

        private void screenshotButton_Click(object sender, RoutedEventArgs e)
        {
            ClientConnection client = ClientConnection.GetInstance;
            client.SaveScreenShot(0);
        }
    }
}
