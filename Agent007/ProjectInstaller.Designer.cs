using System.ServiceProcess;

namespace Agent007
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller = new ServiceProcessInstaller();
            this.serviceInstaller = new ServiceInstaller();
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            // 
            // serviceInstaller
            // 
            this.serviceInstaller.Description = "Secret field operations.";
            this.serviceInstaller.DisplayName = "Agent 007";
            this.serviceInstaller.ServiceName = "SecretService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
                this.serviceProcessInstaller,
                this.serviceInstaller
            });

        }

        #endregion

        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;
    }
}