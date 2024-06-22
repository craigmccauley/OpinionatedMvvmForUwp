using System;

namespace MvvmApp.Infrastructure.ViewModel;
public abstract class PageViewModelFactoryBase<TPageViewModel>
    : IPageViewModelFactory<TPageViewModel> where TPageViewModel : IPageViewModel
{
    public Type ViewModelType => typeof(TPageViewModel);

    public abstract TPageViewModel Invoke();

    IPageViewModel IPageViewModelFactory.Invoke() => Invoke();
}
