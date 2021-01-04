using log4net;
using log4net.Config;
using System;
using System.IO;
using System.ServiceProcess;
using System.Text;

namespace Agent007
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                XmlConfigurator.Configure();

                log.Debug("Starting service program...");
                SecretService service = new SecretService();
                log.Debug("Secret service created.");

                ServiceBase[] services = new ServiceBase[] { service };
                ServiceBase.Run(services);
            }
            catch (Exception e)
            {
                log.Debug(e);
            }
        }
    }
}
