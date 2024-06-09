using Microsoft.Extensions.DependencyInjection;
using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.FormPage;
public static class DependencyInjection
{
    public static IServiceCollection AddFeaturesFormPage(this IServiceCollection services)
    {
        services.AddSingleton<IPageViewModelFactory, FormPageViewModelFactory>();
        return services;
    }
}
