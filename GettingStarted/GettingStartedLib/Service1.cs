using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedLib
{
    public class WcfPingTest : IWcfPingTest
    {
        public const string magicString = "Someshit"; // this is random, just to see if you get the right result

        public ArrayList Files()
        {
            ArrayList al = new ArrayList();
            //get files from Database
            return al;
        }

        public string Ping() { return magicString; }

       /* public FileTransferResponse Put(FileTransferRequest fileToPush)
        {
            throw new NotImplementedException();
        }*/
    }

}
