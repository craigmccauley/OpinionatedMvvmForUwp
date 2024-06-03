using MvvmApp.Infrastructure.Common;
using System;
using System.Collections.Generic;

namespace MvvmApp.Infrastructure.Application;

public interface IPageService
{
    IPageViewModel GetPageViewModel(Page page);
}

public class PageService(IPageFactory pageFactory) : IPageService
{
    private readonly Dictionary<Page, IPageViewModel> pages = pageFactory.CreateIndex();

    public IPageViewModel GetPageViewModel(Page page)
    {
        if (!pages.TryGetValue(page, out var pageViewModel))
        {
            throw new Exception($"PageViewModel not found for page {page.PageType}");
        }
        return pageViewModel;
    }
}