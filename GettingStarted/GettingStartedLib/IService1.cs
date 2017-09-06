using System.ServiceModel;

namespace GettingStartedLib
{
    [ServiceContract]
    public interface IWcfPingTest
    {
        [OperationContract]
        string Ping();
    }
}
