﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace WcfLib
{
    class ComputerInfo
    {
        private PerformanceCounter totalCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter totalMemCounter = new PerformanceCounter("Memory", "Available MBytes");

        public string GatherComputerInfo()
        {
            string computerName = computerName = Environment.MachineName;
            var data = new Dictionary<string, string>();
            data.Add("computerName", computerName);
            data.Add("uptime", UpTime().ToString());
            data.Add("osInfo", Environment.OSVersion.ToString());
            // data.Add("cpuName", GetProcessorName());
            data.Add("cpuUsage", string.Format(("{0:F1} %"), getCPUCounter()));
            data.Add("installDate", GetWindowsInstallationDateTime(computerName).ToString());
            data.Add("inputLocale", InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName);
            data.Add("systemLocale", CultureInfo.InstalledUICulture.EnglishName);
            return JsonConvert.SerializeObject(data);
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
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;
        }

        public DateTime GetWindowsInstallationDateTime(string computerName)
        {
            DateTime installDate = new DateTime();
            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            key = key.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);
            if (key != null)
            {
                DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0);
                object objValue = key.GetValue("InstallDate");
                string stringValue = objValue.ToString();
                Int64 regVal = Convert.ToInt64(stringValue);

                installDate = startDate.AddSeconds(regVal);
            }
            return installDate;
        }

        public object getCPUCounter()
        {
            dynamic firstValue = totalCPUCounter.NextValue();
            System.Threading.Thread.Sleep(1000);

            dynamic secondValue = totalCPUCounter.NextValue();

            return secondValue;
        }

        public string getProcessName()
        {
            Process[] processes=Process.GetProcesses();
            List<string> processName = new List<string>();
            foreach(Process process in processes)
            {
                processName.Add(process.ProcessName);
            }
            return JsonConvert.SerializeObject(processName);
        }
    }
}
