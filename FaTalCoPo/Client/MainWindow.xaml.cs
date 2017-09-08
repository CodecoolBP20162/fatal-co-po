using System.Windows;
using GettingStartedLib;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            string content = client.SaveComputerInfo(0);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            testLabel.Content = dict["computerName"];
        }

        private void screenshotButton_Click(object sender, RoutedEventArgs e)
        {
            ClientConnection client = ClientConnection.GetInstance();
            client.SaveScreenShot(0);
        }
    }
}
