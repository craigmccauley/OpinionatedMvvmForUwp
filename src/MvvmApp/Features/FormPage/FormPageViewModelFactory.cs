using MvvmApp.Infrastructure.Common;

namespace MvvmApp.Features.FormPage;

public class FormPageViewModelFactory : PageViewModelFactoryBase<FormPageViewModel>
{
    public override FormPageViewModel Invoke() => new();
}