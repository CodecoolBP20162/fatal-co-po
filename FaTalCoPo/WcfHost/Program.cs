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

        string LogName = "kk.log";
        //log4net.GlobalContext.Properties["LogName"] = LogName;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
           WcfTestHost_Open();
           Console.ReadKey();
        }

        public static void WcfTestHost_Open()
        {
            string hostname = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            log.Debug("Hostname: " + hostname);
            var baseAddress = new UriBuilder("http", hostname, 2000, "WcfPing");
            log.Debug("baseAddress: " + baseAddress);
            var serviceHost = new ServiceHost(typeof(WcfPing), baseAddress.Uri);
            log.Debug("New ServiceHost created: " + serviceHost.ToString());

            // enable processing of discovery messages.  use UdpDiscoveryEndpoint to enable listening. use EndpointDiscoveryBehavior for fine control.
            serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
            log.Debug("Fine control added to " + serviceHost.ToString());
            serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());
            log.Debug("Listening enabled on " + serviceHost.ToString());

            // enable wsdl, so you can use the service from WcfStorm, or other tools.
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            serviceHost.Description.Behaviors.Add(smb);
            log.Debug("ServiceeMetaDataBehaviour added to " + serviceHost.ToString());

            // create endpoint
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            binding.MaxReceivedMessageSize = 4294967295;
            binding.TransferMode = TransferMode.Streamed;
            serviceHost.AddServiceEndpoint(typeof(IWcfPing), binding, "");
            log.Debug("Endpoint added to " + serviceHost.ToString());
            serviceHost.Open();
            log.Debug(serviceHost.ToString() + " is open");
            Console.WriteLine("host open at " + baseAddress);
        }
    }
}
