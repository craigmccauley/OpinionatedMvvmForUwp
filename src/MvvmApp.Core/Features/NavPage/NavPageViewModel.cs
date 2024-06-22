using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Infrastructure.ViewModel;
using System.Collections.ObjectModel;

namespace MvvmApp.Features.NavPage;
public partial class NavPageViewModel : ObservableObject, IPageViewModel
{
    public ObservableCollection<MenuItem> MenuItems { get; set; }
    public ISelectionChangedCommand SelectionChangedCommand { get; init; }
    [ObservableProperty]
    private IPageViewModel selectedView;
    public ILoadedCommand LoadedCommand { get; init; }
}