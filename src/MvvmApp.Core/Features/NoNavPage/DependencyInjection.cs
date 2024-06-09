using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.NoNavPage;
public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesNoNavPage(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, NoNavPageViewModelFactory>();
        services.AddSingleton<INavigateToNavPageCommand, NavigateToNavPageCommand>();
        return services;
    }
}
