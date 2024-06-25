using MvvmApp.Features.MainPage;
using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp.Features.WelcomePage;
public interface INavigateToNoNavPageCommand : ICommand { }
public class NavigateToNoNavPageCommand(IHooks hooks) : CommandAsyncBase, INavigateToNoNavPageCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        if (hooks.GetPageViewModel(Pages.MainPage) is MainPageViewModel mpvm)
        {
            await hooks.RunOnUIThreadAsync(() => mpvm.SelectedView = hooks.GetPageViewModel(Pages.NoNavPage));
        }
    }
}