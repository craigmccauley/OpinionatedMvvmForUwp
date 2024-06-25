using MvvmApp.Features.MainPage;
using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp.Features.NoNavPage;
public interface INavigateToNavPageCommand : ICommand { }
public class NavigateToNavPageCommand(IHooks hooks) : CommandAsyncBase, INavigateToNavPageCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainPage) is MainPageViewModel mpvm)
        {
            await hooks.RunOnUIThreadAsync(() => mpvm.SelectedView = hooks.GetPageViewModel(Pages.NavPage));
        }
    }
}