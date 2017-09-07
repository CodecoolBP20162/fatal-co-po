﻿using System;
using System.IO;

namespace GettingStartedLib
{
    public class WcfPingTest : IWcfPingTest
    {
        public const string magicString = "Someshit"; // this is random, just to see if you get the right result

        public string Ping() { return magicString; }

        public Stream GetScreenshot()
        {
            try
            {
                MemoryStream ms = ScreenShotMaker.MakeScreenshot();
                ms.Position = 0;
                return ms;
            }
            catch (IOException ex)
            {
                Console.WriteLine(String.Format("An exception was thrown while trying to open the stream."));
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
