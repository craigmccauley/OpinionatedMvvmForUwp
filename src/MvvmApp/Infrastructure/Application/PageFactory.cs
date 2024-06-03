using MvvmApp.Infrastructure.Common;
using System.Collections.Generic;
using System.Linq;

namespace MvvmApp.Infrastructure.Application;

public interface IPageFactory
{
    Dictionary<Page, IPageViewModel> CreateIndex();
}

public class PageFactory(IEnumerable<IPageViewModelFactory> factories) : IPageFactory
{
    private readonly List<IPageViewModelFactory> _factories = factories.ToList();
    public Dictionary<Page, IPageViewModel> CreateIndex() => Pages.All.ToDictionary(page => page, page =>
    {
        var fac = _factories.Single(f => f.ViewModelType == page.ViewModelType);
        return fac.Invoke();
    });
}
