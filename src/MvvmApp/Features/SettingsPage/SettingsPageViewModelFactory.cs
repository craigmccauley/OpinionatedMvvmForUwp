using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.SettingsPage;

public class SettingsPageViewModelFactory : PageViewModelFactoryBase<SettingsPageViewModel>
{
    public override SettingsPageViewModel Invoke() => new();
}