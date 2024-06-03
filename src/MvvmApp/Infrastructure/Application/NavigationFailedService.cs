using System;
using Windows.UI.Xaml.Navigation;

namespace MvvmApp.Infrastructure.Application;

public interface INavigationFailedService
{
    void OnNavigationFailed(object sender, NavigationFailedEventArgs e);
}

public class NavigationFailedService : INavigationFailedService
{
    public void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
    {
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }
}
