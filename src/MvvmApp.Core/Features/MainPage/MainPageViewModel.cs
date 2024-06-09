using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.MainPage;
public class MainPageViewModel : NotifyPropertyChangedBase, IPageViewModel
{
    public IPageViewModel SelectedView
    {
        get => Get<IPageViewModel>();
        set => Set(value);
    }
}
