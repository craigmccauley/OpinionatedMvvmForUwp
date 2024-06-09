using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.MainPage;
public class MainPageViewModelFactory : PageViewModelFactoryBase<MainPageViewModel>
{
    public override MainPageViewModel Invoke()
    {
        return new MainPageViewModel();
    }
}
