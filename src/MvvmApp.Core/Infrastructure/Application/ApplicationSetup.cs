using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Features.FormPage;
using MvvmApp.Features.MainPage;
using MvvmApp.Features.NavPage;
using MvvmApp.Features.NoNavPage;
using MvvmApp.Features.SettingsPage;
using MvvmApp.Features.WelcomePage;
using System;

namespace MvvmApp.Infrastructure.Application;

public class ApplicationSetup
{
    public static IServiceProvider BuildServiceProvider<TMainPage>() where TMainPage : Windows.UI.Xaml.Controls.Page
    {
        var services = new ServiceCollection();

        services.AddSingleton<ISuspendingService, SuspendingService>();
        services.AddSingleton<ILaunchedService, LaunchedService<TMainPage>>();

        services.AddSingleton<IPageViewModelService, PageViewModelService>();
        services.AddSingleton<IPageFactory, PageFactory>();

        services.AddSingleton<IHooks, Hooks>();
        services.AddSingleton<INavigationFailedService, NavigationFailedService>();

        services.AddFeaturesFormPage();
        services.AddFeaturesMainPage();
        services.AddFeaturesNavPage();
        services.AddFeaturesNoNavPage();
        services.AddFeaturesSettingsPage();
        services.AddFeaturesWelcomePage();

        return services.BuildServiceProvider();
    }
}