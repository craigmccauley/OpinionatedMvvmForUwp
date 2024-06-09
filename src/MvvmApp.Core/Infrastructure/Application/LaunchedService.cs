using MvvmApp.Features.MainPage;
using Windows.ApplicationModel.Activation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MvvmApp.Infrastructure.Application;

public interface ILaunchedService
{

   void OnLaunched(object sender, LaunchActivatedEventArgs e);
}

public class LaunchedService<TMainPage>(
    IPageService pageService,
    IHooks hooks,
    INavigationFailedService navigationFailedService) : ILaunchedService
    where TMainPage : Windows.UI.Xaml.Controls.Page
{
    public void OnLaunched(object sender, LaunchActivatedEventArgs e)
    {
        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (Window.Current.Content is not Frame rootFrame)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();

            rootFrame.NavigationFailed += navigationFailedService.OnNavigationFailed;

            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Load state from previously suspended application
            }

            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }

        if (e.PrelaunchActivated == false)
        {
            hooks.Initialize(
                CoreWindow.GetForCurrentThread().Dispatcher,
                pageService);

            if (rootFrame.Content != null)
            {
                return;
            }

            var mainPageViewModel = pageService.GetPageViewModel(Pages.MainPage) as MainPageViewModel;
            mainPageViewModel.SelectedView = pageService.GetPageViewModel(Pages.NavPage);
            rootFrame.DataContext = mainPageViewModel;
            rootFrame.Navigate(typeof(TMainPage), e.Arguments);
            Window.Current.Activate();
        }
    }
}
