using MvvmApp.Features.MainPage;
using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.Common;
using System.Windows.Input;

namespace MvvmApp.Features.NavPage;
public interface INavigateToNoNavPageCommand : ICommand { }
public class NavigateToNoNavPageCommand(IHooks hooks) : CommandBase, INavigateToNoNavPageCommand
{
    protected override void ExecuteCommand(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainPage) is MainPageViewModel mpvm)
        {
            mpvm.SelectedView = hooks.GetPageViewModel(Pages.NoNavPage);
        }
    }
}