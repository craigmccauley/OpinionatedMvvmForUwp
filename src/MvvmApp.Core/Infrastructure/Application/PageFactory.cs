using MvvmApp.Infrastructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvvmApp.Infrastructure.Application;

public interface IPageFactory
{
    Dictionary<Page, IPageViewModel> CreateIndex();
}

public class PageFactory(IEnumerable<IPageViewModelFactory> factories) : IPageFactory
{
    private readonly List<IPageViewModelFactory> factoryList = factories.ToList();
    public Dictionary<Page, IPageViewModel> CreateIndex()
    {
        var missingFactories = Pages.All.Select(p => p.ViewModelType).Except(
            factoryList.Select(f => f.ViewModelType)).ToList();

        if (missingFactories.Any())
        {
            throw new Exception($"The following PageViewModels do not have a factory: {string.Join(", ", missingFactories)}" +
                $"Check that you have created a factory for it and that the factory is being injected as a IPageViewModelFactory.");
        }

        return Pages.All.ToDictionary(
            page => page,
            page => factoryList.First(f => f.ViewModelType == page.ViewModelType).Invoke()
        );
    }
}
