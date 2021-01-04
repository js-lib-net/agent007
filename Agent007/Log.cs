using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Agent007
{
    class Log
    {
        public static void Debug(string message)
        {
            string logFile = AppDomain.CurrentDomain.BaseDirectory + "\\log";
            if (File.Exists(logFile))
            {
                using (StreamWriter sw = File.AppendText(logFile))
                {
                    sw.WriteLine(message);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(logFile))
                {
                    sw.WriteLine(message);
                }
            }
        }
    }
}
