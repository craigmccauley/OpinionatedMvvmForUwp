using MvvmApp.Features.FormPage;
using MvvmApp.Features.MainPage;
using MvvmApp.Features.NavPage;
using MvvmApp.Features.NoNavPage;
using MvvmApp.Features.SettingsPage;
using MvvmApp.Features.WelcomePage;
using System;

namespace MvvmApp.Infrastructure.Application;

public record Page(Type ViewModelType);
public static class Pages
{
    public static Page MainPage = new(typeof(MainPageViewModel));
    public static Page NoNavPage = new(typeof(NoNavPageViewModel));
    public static Page NavPage = new(typeof(NavPageViewModel));
    public static Page WelcomePage = new(typeof(WelcomePageViewModel));
    public static Page FormPage = new(typeof(FormPageViewModel));
    public static Page SettingsPage = new(typeof(SettingsPageViewModel));

    public static Page[] All =
    [
        MainPage,
        NoNavPage,
        NavPage,
        WelcomePage,
        FormPage,
        SettingsPage,
    ];
}
