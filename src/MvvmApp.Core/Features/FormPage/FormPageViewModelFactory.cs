using MvvmApp.Infrastructure.ViewModel;

namespace MvvmApp.Features.FormPage;

public class FormPageViewModelFactory : PageViewModelFactoryBase<FormPageViewModel>
{
    public override FormPageViewModel Invoke() => new();
}