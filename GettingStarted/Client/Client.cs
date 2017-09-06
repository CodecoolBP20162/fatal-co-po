using System;
using System.ServiceModel.Discovery;
using GettingStartedLib;
using System.ServiceModel;
using System.Collections.Generic;
using System.IO;

namespace Client
{
    class ClientConnection
    {
        private static ClientConnection instance;
        public List<IWcfPingTest> channels = new List<IWcfPingTest>();

        private ClientConnection() { }

        public static ClientConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new ClientConnection();
            }
            return instance;
        }

        public void SetupChannels()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            binding.MaxReceivedMessageSize = 4294967295;
            binding.TransferMode = TransferMode.Streamed;
            var factory = new ChannelFactory<IWcfPingTest>(binding);
            var uri = DiscoverChannel();
            foreach (var item in uri.Endpoints)
            {
                EndpointAddress newEndpoint = new EndpointAddress(item.Address.Uri);
                IWcfPingTest newChannel = factory.CreateChannel(newEndpoint);
                channels.Add(newChannel);
            }
        }

        public FindResponse DiscoverChannel()
        {
            var dc = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindCriteria fc = new FindCriteria(typeof(IWcfPingTest));
            fc.Duration = TimeSpan.FromSeconds(5);
            FindResponse fr = dc.Find(fc);
            return fr;
        }

        public void SaveScreenShot(int channelIndex)
        {
            try
            {
                Stream screenshot = channels[channelIndex].GetScreenshot();
                string path = @"C:\testfolder\screenshot.jpg";
                Console.WriteLine(path);
                FileStream fileStream = new FileStream(path, FileMode.Create);
                screenshot.CopyTo(fileStream);
                fileStream.Close();
                Console.WriteLine("File sending successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
