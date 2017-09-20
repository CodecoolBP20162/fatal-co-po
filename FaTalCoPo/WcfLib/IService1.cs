using System.Diagnostics;
using System.IO;
using System.ServiceModel;

namespace WcfLib
{
    [ServiceContract]
    public interface IWcfPing
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        Stream GetScreenshot();

        [OperationContract]
        string GetComputerInfo();

        [OperationContract]
        Process[] GetProcessesInfo();
    }
}
