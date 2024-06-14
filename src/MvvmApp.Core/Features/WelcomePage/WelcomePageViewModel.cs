using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.WelcomePage;

public partial class WelcomePageViewModel : ObservableObject, IPageViewModel
{
    public INavigateToNoNavPageCommand NavigateToNoNavPageCommand { get; init; }
}