using System;
using System.ServiceModel.Discovery;
using GettingStartedLib;
using System.ServiceModel;

namespace Client
{
    class ClientConnection
    {
        public IWcfPingTest SetupChannel()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            var factory = new ChannelFactory<IWcfPingTest>(binding);
            var uri = DiscoverChannel();
            EndpointAddress ea = new EndpointAddress(uri.Endpoints[0].Address.Uri);
            IWcfPingTest channel = factory.CreateChannel(ea);
            return channel;
        }

        public FindResponse DiscoverChannel()
        {
            var dc = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindCriteria fc = new FindCriteria(typeof(IWcfPingTest));
            fc.Duration = TimeSpan.FromSeconds(5);
            FindResponse fr = dc.Find(fc);
            return fr;
        }
    }
}
