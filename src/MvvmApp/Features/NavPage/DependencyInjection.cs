using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.NavPage;
public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesNavPage(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, NavPageViewModelFactory>();
        services.AddSingleton<INavigateToNoNavPageCommand, NavigateToNoNavPageCommand>();
        return services;
    }
}
