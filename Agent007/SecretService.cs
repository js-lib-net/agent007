using log4net;
using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using TinyServer;

namespace Agent007
{
    public partial class SecretService : ServiceBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SecretService));

        private readonly HttpServer tinyServer;

        public SecretService()
        {
            log.Debug("SecretService()");
            InitializeComponent();
            CanPauseAndContinue = true;
            CanHandlePowerEvent = true;

            IContainer container = new RmiContainer();
            container.AddMapping("API", typeof(Controller));
            tinyServer = new HttpServer(container, 7777);
        }

        protected override void OnStart(string[] args)
        {
            log.Debug("OnStart(string[])");
            base.OnStart(args);
            tinyServer.Start();
        }

        protected override void OnStop()
        {
            log.Debug("OnStop()");
            base.OnStop();
            tinyServer.Stop();
        }

        protected override void OnPause()
        {
            log.Debug("OnPause()");
            base.OnPause();
        }

        protected override void OnContinue()
        {
            log.Debug("OnContinue()");
            base.OnContinue();
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            log.Debug("OnPowerEvent(PowerBroadcastStatus)");
            log.Info($"OnPowerEvent: {powerStatus}");
            return base.OnPowerEvent(powerStatus);
        }
    }
}
