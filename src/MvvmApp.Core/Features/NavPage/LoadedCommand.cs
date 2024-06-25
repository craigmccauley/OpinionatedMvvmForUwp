using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmApp.Features.NavPage;
public interface ILoadedCommand : ICommand { }
public class LoadedCommand(
    IHooks hooks) : CommandAsyncBase, ILoadedCommand
{
    protected override async Task ExecuteAsync(object parameter)
    {
        if (parameter is not NavPageViewModel vm
            || vm.MenuItems == null
            || !vm.MenuItems.Any())
        {
            return;
        }

        await hooks.RunOnUIThreadAsync(() =>
        {
            vm.SelectedView = hooks.GetPageViewModel(vm.MenuItems.FirstOrDefault().NavDestination);
        });
    }
}
