using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.WelcomePage;

public class WelcomePageViewModel : NotifyPropertyChangedBase, IPageViewModel
{
    public INavigateToNoNavPageCommand NavigateToNoNavPageCommand { get; init; }
}