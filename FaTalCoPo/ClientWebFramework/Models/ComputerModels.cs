using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebFramework.Models
{
    public class ComputerModels
    {
        public string IPAddress { get; set; }
        public DateTime UPTime { get; set; }
        public string ComputerName { get; set; }
        public string OSName { get; set; }
        public string OSVersion { get; set; }
        public int TotalMemory { get; set; }
        public int CPU { get; set; }
        public DateTime InstallDate { get; set; }
        public string InputLocale { get; set; }
        public string SystemLocale { get; set; }
    }
}