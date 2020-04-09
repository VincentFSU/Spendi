namespace SpendiDesktopUI {
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using SpendiDesktopUI.ViewModels;

    public class AppBootstrapper : BootstrapperBase 
    {
        public AppBootstrapper() 
        {
            Initialize();
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) 
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}