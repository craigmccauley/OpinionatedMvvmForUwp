using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.WelcomePage;
public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesWelcomePage(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, WelcomePageViewModelFactory>();
        services.AddSingleton<INavigateToNoNavPageCommand, NavigateToNoNavPageCommand>();
        return services;
    }
}
