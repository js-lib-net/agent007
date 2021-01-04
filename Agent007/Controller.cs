using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace Agent007
{
    class Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Controller));

        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public string Hello(string user)
        {
            return $"Hello {user}!";
        }

        public void Hibernate()
        {
            log.Warn("Put the system on hibernation.");
            //Application.SetSuspendState(PowerState.Hibernate, true, true);
            SetSuspendState(true, true, true);
        }

        public void Standby()
        {
            log.Warn("Put the system on standby.");
            SetSuspendState(false, true, true);
        }

        public string Shutdown()
        {
            log.Warn("Shutdown the system.");

            ManagementClass win32 = new ManagementClass("Win32_OperatingSystem");
            win32.Get();

            // You can't shutdown without security privileges
            win32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject parameters = win32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            parameters["Flags"] = "12";
            parameters["Reserved"] = "0";
            foreach (ManagementObject @object in win32.GetInstances())
            {
                ManagementBaseObject result = @object.InvokeMethod("Win32Shutdown", parameters, null);
                return result.GetText(TextFormat.Mof);
            }

            return null;
        }
    }
}
