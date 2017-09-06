using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            WcfTestClient_SetupChannel();
            WcfTestClient_Ping();
            tbSomething.Text = result;

        }


        private static IWcfPingTest channel;
        public static string result;

        public static Uri WcfTestClient_DiscoverChannel()
        {
            var dc = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindCriteria fc = new FindCriteria(typeof(IWcfPingTest));
            fc.Duration = TimeSpan.FromSeconds(5);
            FindResponse fr = dc.Find(fc);
            foreach (EndpointDiscoveryMetadata edm in fr.Endpoints)
            {
                Console.WriteLine("uri found = " + edm.Address.Uri.ToString());
            }
            // here is the really nasty part
            // i am just returning the first channel, but it may not work.
            // you have to do some logic to decide which uri to use from the discovered uris
            // for example, you may discover "127.0.0.1", but that one is obviously useless.
            // also, catch exceptions when no endpoints are found and try again.
            return fr.Endpoints[0].Address.Uri;
        }
        public static void WcfTestClient_SetupChannel()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            var factory = new ChannelFactory<IWcfPingTest>(binding);
            var uri = WcfTestClient_DiscoverChannel();
            Console.WriteLine("creating channel to " + uri.ToString());
            EndpointAddress ea = new EndpointAddress(uri);
            channel = factory.CreateChannel(ea);
            Console.WriteLine("channel created");
            Console.WriteLine("pinging host");
            //string result = channel.Ping();
            //Console.WriteLine("ping result = " + result);
        }
        public static void WcfTestClient_Ping()
        {
            Console.WriteLine("pinging host");
            string result = channel.Ping();
            Console.WriteLine("ping result = " + result);
        }

    }
}
