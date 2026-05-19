using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace TestProject3
{
    public class AppManager
    {
        private UIA3Automation automation;

        public UIA3Automation Automation
        {
            get { return automation; }
        }

        public AppManager()
        {
            automation = new UIA3Automation();
        }

        public Process StartOnScreenKeyboard()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Windows\System32\osk.exe",
                UseShellExecute = true
            };

            return Process.Start(startInfo);
        }

        public AutomationElement GetDesktop()
        {
            return automation.GetDesktop();
        }

        public void Stop()
        {
            automation.Dispose();
        }
    }
}
