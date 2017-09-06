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
            ClientConnection client = new ClientConnection();
            IWcfPingTest channel = client.SetupChannel();
            string result = channel.Ping();
            tbSomething.Text = result;
        }
    }
}
