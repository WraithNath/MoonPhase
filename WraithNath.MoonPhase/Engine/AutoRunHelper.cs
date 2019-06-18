using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace WraithNath.MoonPhase.Engine
{
    /// <summary>
    /// Helper class for setting auto run on startup
    /// </summary>
    public static class AutoRunHelper
    {
        /// <summary>
        /// Checks whether Auto Run is enabled for the specified App
        /// </summary>
        /// <param name="appName">The Application Name</param>
        /// <returns>true or false</returns>
        public static bool IsAutoRunEnabled(string appName)
        {
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                return regKey.GetValue(appName) == null ? false : true;
            }
        }

        /// <summary>
        /// Sets whether Auto Run is enabled for the specified app
        /// </summary>
        /// <param name="appName">The App Name</param>
        /// <param name="executablePath">The Executable Path</param>
        /// <param name="autoRun">Whether Auto Run is enabled</param>
        public static void SetAutoRunEnabled(string appName, string executablePath, bool autoRun)
        {
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (autoRun)
                    regKey.SetValue(appName, executablePath);
                else
                    regKey.DeleteValue(appName, false);
            }
        }
    }
}
