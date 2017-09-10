using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using WcfLib;

namespace WcfHost
{

    class Program
    {
        public static void Main(string[] args)
        {
           WcfTestHost_Open();
           Console.ReadKey();
        }

        public static void WcfTestHost_Open()
        {
            string hostname = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            var baseAddress = new UriBuilder("http", hostname, 2000, "WcfPing");
            var h = new ServiceHost(typeof(WcfPing), baseAddress.Uri);

            // enable processing of discovery messages.  use UdpDiscoveryEndpoint to enable listening. use EndpointDiscoveryBehavior for fine control.
            h.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            h.AddServiceEndpoint(new UdpDiscoveryEndpoint());

            // enable wsdl, so you can use the service from WcfStorm, or other tools.
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            h.Description.Behaviors.Add(smb);

            // create endpoint
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            binding.MaxReceivedMessageSize = 4294967295;
            binding.TransferMode = TransferMode.Streamed;
            h.AddServiceEndpoint(typeof(IWcfPing), binding, "");
            h.Open();
            Console.WriteLine("host open at " + baseAddress);
        }
    }
}
