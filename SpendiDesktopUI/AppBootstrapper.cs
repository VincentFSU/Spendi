namespace SpendiDesktopUI {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    using Caliburn.Micro;
    using SpendiDesktopUI.Helpers;
    using SpendiDesktopUI.ViewModels;

    public class AppBootstrapper : BootstrapperBase 
    {
        private SimpleContainer _container = new SimpleContainer();

        public AppBootstrapper() 
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container.Singleton<IWindowManager, WindowManager>().Singleton<IEventAggregator, EventAggregator>();

            //register each ViewModel to the container (reflection)
            GetType().Assembly.GetTypes().Where(type => type.IsClass).Where(type => type.Name.EndsWith("ViewModel")).ToList().ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) 
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}