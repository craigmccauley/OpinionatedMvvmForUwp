using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.Application;
using MvvmApp.Pages;
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace MvvmApp
{
    sealed partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;
        public App()
        {
            this.InitializeComponent();
            serviceProvider = ApplicationSetup.BuildServiceProvider<MainPage>();
            this.Suspending += serviceProvider.GetService<ISuspendingService>().OnSuspending;
        }
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            serviceProvider.GetService<ILaunchedService>().OnLaunched(this, e);
        }
    }
}
