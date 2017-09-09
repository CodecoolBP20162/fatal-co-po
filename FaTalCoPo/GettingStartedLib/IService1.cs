using System.IO;
using System.ServiceModel;

namespace WcfLib
{
    [ServiceContract]
    public interface IWcfPingTest
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        Stream GetScreenshot();

        [OperationContract]
        string GetComputerInfo();
    }
}
