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
        public List<IWcfPingTest> Channels { get; set; }

        private ClientConnection() { }

        public static ClientConnection GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientConnection();
                }
                return instance;
            }
        }

        public void SetupChannels()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            var factory = new ChannelFactory<IWcfPingTest>(binding);
            var uri = DiscoverChannel();
            foreach (var item in uri.Endpoints)
            {
                EndpointAddress newEndpoint = new EndpointAddress(item.Address.Uri);
                IWcfPingTest newChannel = factory.CreateChannel(newEndpoint);
                Channels.Add(newChannel);
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
                var screenshot = Channels[channelIndex].GetScreenshot();
                string path = @"C:\testfolder\" + Channels[channelIndex].ToString() + @"\screenshot.jpg";
                Console.WriteLine(path);
                FileStream fileStream = new FileStream(path, FileMode.Create);
                screenshot.CopyTo(fileStream);
                screenshot.Close();
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
