using MvvmApp.Infrastructure.Common;
using System.Collections.ObjectModel;

namespace MvvmApp.Features.NavPage;
public class NavPageViewModel : NotifyPropertyChangedBase, IPageViewModel
{
    public ObservableCollection<MenuItem> MenuItems { get; init; }

    public ISelectionChangedCommand SelectionChangedCommand { get; init; }
    public IPageViewModel SelectedView
    {
        get => Get<IPageViewModel>();
        set => Set(value);
    }
    public ILoadedCommand LoadedCommand { get; init; }
}