using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.NoNavPage;

public class NoNavPageViewModelFactory(
    INavigateToNavPageCommand navigateToNavPageCommand) : PageViewModelFactoryBase<NoNavPageViewModel>
{
    public override NoNavPageViewModel Invoke()
    {
        return new NoNavPageViewModel
        {
            NavigateToNavPageCommand = navigateToNavPageCommand
        };
    }
}