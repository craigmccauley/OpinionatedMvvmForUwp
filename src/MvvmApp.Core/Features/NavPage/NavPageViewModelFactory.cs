using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using Windows.UI.Xaml.Controls;

namespace MvvmApp.Features.NavPage;

public class NavPageViewModelFactory(
    ISelectionChangedCommand selectionChangedCommand,
    ILoadedCommand loadedCommand) : PageViewModelFactoryBase<NavPageViewModel>
{
    public override NavPageViewModel Invoke()
    {
        var vm = new NavPageViewModel
        {
            MenuItems = [],
            SelectionChangedCommand = selectionChangedCommand,
            LoadedCommand = loadedCommand,
        };

        var firstItem = new MenuItem
        {
            Content = "Home",
            Glyph = Symbol.Home,
            NavDestination = Pages.WelcomePage,
            Parent = vm,
        };

        vm.MenuItems.Add(firstItem);
        vm.MenuItems.Add(new()
        {
            Content = "Form",
            Glyph = Symbol.Page,
            NavDestination = Pages.FormPage,
            Parent = vm,
        });

        vm.SelectedItem = firstItem;

        return vm;
    }
}