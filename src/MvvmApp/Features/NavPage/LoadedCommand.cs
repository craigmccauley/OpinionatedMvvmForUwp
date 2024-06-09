using MvvmApp.Infrastructure.Common;
using System.Linq;
using System.Windows.Input;

namespace MvvmApp.Features.NavPage;
public interface ILoadedCommand : ICommand { }
public class LoadedCommand() : CommandBase, ILoadedCommand
{
    protected override void ExecuteCommand(object parameter)
    {
        if(parameter is not NavPageViewModel vm)
        {
            return;
        }
        vm.MenuItems.FirstOrDefault().IsSelected = true;
    }
}
