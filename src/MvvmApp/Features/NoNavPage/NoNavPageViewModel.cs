using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.NoNavPage;
public class NoNavPageViewModel : IPageViewModel
{
    public INavigateToNavPageCommand NavigateToNavPageCommand { get; set; }
}