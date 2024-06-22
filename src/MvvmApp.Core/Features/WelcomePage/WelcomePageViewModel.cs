using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.WelcomePage;

public partial class WelcomePageViewModel : ObservableObject, IPageViewModel
{
    public INavigateToNoNavPageCommand NavigateToNoNavPageCommand { get; init; }
}