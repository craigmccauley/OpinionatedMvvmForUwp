using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MvvmApp.Features.NavPage;
public interface ISelectionChangedCommand : ICommand { }
public class SelectionChangedCommand(
    IHooks hooks) : CommandAsyncBase, ISelectionChangedCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        if (parameter is not NavigationViewSelectionChangedEventArgs args)
        {
            return;
        }
        if (args.IsSettingsSelected)
        {
            var viewModel = (NavPageViewModel)((NavigationViewItem)args.SelectedItem).DataContext;
            await hooks.RunOnUIThreadAsync(() =>
            {
                viewModel.SelectedView = hooks.GetPageViewModel(Pages.SettingsPage);
            });
        }
        else if (args.SelectedItem is MenuItem menuItem)
        {
            await hooks.RunOnUIThreadAsync(() =>
            {
                menuItem.Parent.SelectedView = hooks.GetPageViewModel(menuItem.NavDestination);
            });
        }
    }
}
