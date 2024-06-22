using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.SettingsPage;
public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesSettingsPage(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, SettingsPageViewModelFactory>();
        return services;
    }
}
