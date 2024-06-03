using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Features.MainPage;
using MvvmApp.Features.NavPage;
using MvvmApp.Features.NoNavPage;
using System;

namespace MvvmApp.Infrastructure.Application;

public class ApplicationSetup
{
    public static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ISuspendingService, SuspendingService>();
        services.AddSingleton<ILaunchedService, LaunchedService>();

        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<IPageFactory, PageFactory>();

        services.AddSingleton<IHooks, Hooks>();
        services.AddSingleton<INavigationFailedService, NavigationFailedService>();

        services.AddFeaturesMainPage();
        services.AddFeaturesNavPage();
        services.AddFeaturesNoNavPage();

        return services.BuildServiceProvider();
    }
}