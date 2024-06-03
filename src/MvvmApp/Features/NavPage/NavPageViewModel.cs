using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.NavPage;
public class NavPageViewModel : IPageViewModel
{
    public INavigateToNoNavPageCommand NavigateToNoNavPageCommand { get; set; }
}