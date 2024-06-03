using MvvmApp.Infrastructure.Common;
using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace MvvmApp.Infrastructure.Application;

public interface IHooks
{
    IPageViewModel GetPageViewModel(Page page);
    void Initialize(CoreDispatcher coreDispatcher, IPageService pageService);
    Task RunAsync(Action action);
}

public class Hooks : IHooks
{
    private CoreDispatcher coreDispatcher;
    private IPageService pageService;
    private bool isInitialized = false;

    public void Initialize(
        CoreDispatcher coreDispatcher,
        IPageService pageService)
    {
        this.coreDispatcher ??= coreDispatcher;
        this.pageService ??= pageService;
        isInitialized = true;
    }

    public async Task RunAsync(Action action)
    {
        if(!isInitialized) throw new Exception("Dispatcher not initialized");
        await coreDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
    }

    public IPageViewModel GetPageViewModel(Page page)
    {
        if (!isInitialized) throw new Exception("Dispatcher not initialized");
        return pageService.GetPageViewModel(page);
    }
}
