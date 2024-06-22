using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.MainPage;
public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesMainPage(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, MainPageViewModelFactory>();
        return services;
    }
}
