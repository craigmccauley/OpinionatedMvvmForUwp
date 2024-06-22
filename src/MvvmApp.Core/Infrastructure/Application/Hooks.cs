using MvvmApp.Infrastructure.ViewModel;
using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace MvvmApp.Infrastructure.Application;

public interface IHooks
{
    IPageViewModel GetPageViewModel(Page page);
    void Initialize(CoreDispatcher coreDispatcher, IPageViewModelService pageViewModelService);
    Task RunAsync(Action action);
}

public class Hooks : IHooks
{
    private CoreDispatcher coreDispatcher;
    private IPageViewModelService pageViewModelService;
    private bool isInitialized = false;

    public void Initialize(
        CoreDispatcher coreDispatcher,
        IPageViewModelService pageViewModelService)
    {
        this.coreDispatcher ??= coreDispatcher;
        this.pageViewModelService ??= pageViewModelService;
        isInitialized = true;
    }

    public async Task RunAsync(Action action)
    {
        EnsureInitialized();
        await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
    }
    public IPageViewModel GetPageViewModel(Page page)
    {
        EnsureInitialized();
        return pageViewModelService.GetPageViewModel(page);
    }
    private void EnsureInitialized()
    {
        if (!isInitialized)
        {
            throw new Exception("Dispatcher not initialized");
        }
    }
}
