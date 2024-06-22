using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.NavPage;
public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesNavPage(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, NavPageViewModelFactory>();
        services.AddSingleton<ILoadedCommand, LoadedCommand>();
        services.AddSingleton<ISelectionChangedCommand, SelectionChangedCommand>();
        services.AddSingleton<IMenuItemIsSelectedChangedService, MenuItemIsSelectedChangedService>();
        return services;
    }
}
