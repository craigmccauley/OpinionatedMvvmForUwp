using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.MainPage;
public partial class MainPageViewModel : ObservableObject, IPageViewModel
{
    [ObservableProperty]
    private IPageViewModel selectedView;
}
