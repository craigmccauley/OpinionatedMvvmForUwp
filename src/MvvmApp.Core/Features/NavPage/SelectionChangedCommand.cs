using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MvvmApp.Features.NavPage;
public interface ISelectionChangedCommand : ICommand { }
public class SelectionChangedCommand(
    IHooks hooks) : CommandBase, ISelectionChangedCommand
{
    protected override async void ExecuteCommand(object parameter)
    {
        if (parameter is not NavigationViewSelectionChangedEventArgs args
            || !args.IsSettingsSelected)
        {
            return;
        }

        var viewModel = (NavPageViewModel)((NavigationViewItem)args.SelectedItem).DataContext;
        await hooks.RunAsync(() =>
        {
            viewModel.SelectedView = hooks.GetPageViewModel(Pages.SettingsPage);
        });
    }
}
