using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace GettingStartedLib
{
    [ServiceContract]
    public interface IWcfPingTest
    {
        [OperationContract]
        string Ping();
        
        
    }

}
