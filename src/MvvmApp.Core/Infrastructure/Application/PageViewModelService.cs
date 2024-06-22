using MvvmApp.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;

namespace MvvmApp.Infrastructure.Application;

public interface IPageViewModelService
{
    IPageViewModel GetPageViewModel(Page page);
}

public class PageViewModelService(IPageFactory pageFactory) : IPageViewModelService
{
    private readonly Dictionary<Page, IPageViewModel> pages = pageFactory.CreateIndex();

    public IPageViewModel GetPageViewModel(Page page)
    {
        if (!pages.TryGetValue(page, out var pageViewModel))
        {
            throw new Exception($"PageViewModel \"{page.ViewModelType.Name}\" not found. " +
                $"Check that you have created a factory for it and that the factory is being injected as a IPageViewModelFactory.");
        }
        return pageViewModel;
    }
}