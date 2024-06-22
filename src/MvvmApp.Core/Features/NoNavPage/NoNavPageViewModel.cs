using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.NoNavPage;
public class NoNavPageViewModel : IPageViewModel
{
    public INavigateToNavPageCommand NavigateToNavPageCommand { get; set; }
}