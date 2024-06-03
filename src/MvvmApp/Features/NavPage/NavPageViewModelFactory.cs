using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.NavPage
{
    public class NavPageViewModelFactory(
        INavigateToNoNavPageCommand navigateToNoNavPageCommand) : PageViewModelFactoryBase<NavPageViewModel>
    {
        public override NavPageViewModel Invoke()
        {
            return new NavPageViewModel
            {
                NavigateToNoNavPageCommand = navigateToNoNavPageCommand
            };
        }
    }
}