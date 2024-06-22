using MvvmApp.Features.MainPage;
using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using System.Windows.Input;

namespace MvvmApp.Features.NoNavPage;
public interface INavigateToNavPageCommand : ICommand { }
public class NavigateToNavPageCommand(IHooks hooks) : CommandBase, INavigateToNavPageCommand
{
    protected override void ExecuteCommand(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainPage) is MainPageViewModel mpvm)
        {
            mpvm.SelectedView = hooks.GetPageViewModel(Pages.NavPage);
        }
    }
}