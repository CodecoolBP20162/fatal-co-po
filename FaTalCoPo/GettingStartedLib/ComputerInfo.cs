using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace GettingStartedLib
{
    class ComputerInfo
    {
        private PerformanceCounter totalCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter totalMemCounter = new PerformanceCounter("Memory", "Available MBytes");

        public string[] GatherComputerInfo()
        {
            string[] data = new string[8];
            data[0] = Environment.MachineName; // computerName
            data[1] = UpTime().ToString(); // uptime
            data[2] = Environment.OSVersion.ToString(); // osInfo
            data[3] = GetProcessorName(); // cpuName
            data[4] = string.Format(("{0:F1} %"), totalCPUCounter.NextValue()); // cpuUsage
            data[5] = GetWindowsInstallationDateTime(data[0]).ToString(); // installDate
            data[6] = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName; // inputLocale
            data[7] = CultureInfo.InstalledUICulture.EnglishName; // systemLocale
            return data;
        }

        public TimeSpan UpTime()
        {
            using (var uptime = new PerformanceCounter("System", "System Up Time"))
            {
                uptime.NextValue(); // Call this an extra time before reading its value
                return TimeSpan.FromSeconds(uptime.NextValue());
            }
        }

        public string GetProcessorName()
        {
            string procInfo = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject share in searcher.Get())
            {
                foreach (PropertyData PC in share.Properties)
                {
                    procInfo = PC.Name;
                }
            }
            return procInfo;
        }

        public DateTime GetWindowsInstallationDateTime(string computerName)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, computerName);
            key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);
            if (key != null)
            {
                DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0);
                Int64 regVal = Convert.ToInt64(key.GetValue("InstallDate").ToString());

                DateTime installDate = startDate.AddSeconds(regVal);

                return installDate;
            }

            return DateTime.MinValue;
        }
    }
}
