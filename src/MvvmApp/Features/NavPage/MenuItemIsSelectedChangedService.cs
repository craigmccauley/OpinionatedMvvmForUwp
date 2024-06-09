using MvvmApp.Infrastructure.Application;
using System.ComponentModel;

namespace MvvmApp.Features.NavPage;

public interface IMenuItemIsSelectedChangedService
{
    void HandleIsSelectedChanged(object sender, PropertyChangedEventArgs args);
}

public class MenuItemIsSelectedChangedService(IHooks hooks) : IMenuItemIsSelectedChangedService
{
    public async void HandleIsSelectedChanged(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName != nameof(MenuItem.IsSelected)
            || sender is not MenuItem item
            || !item.IsSelected)
        {
            return;
        }
        await hooks.RunAsync(() =>
        {
            item.Parent.SelectedView = hooks.GetPageViewModel(item.NavDestination);
        });
    }
}
