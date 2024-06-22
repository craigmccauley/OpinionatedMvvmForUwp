using MvvmApp.Features.FormPage;
using MvvmApp.Features.MainPage;
using MvvmApp.Features.NavPage;
using MvvmApp.Features.NoNavPage;
using MvvmApp.Features.SettingsPage;
using MvvmApp.Features.WelcomePage;
using System;
using System.Collections.Generic;

namespace MvvmApp.Infrastructure.Application;

public record Page(Type ViewModelType);
public static class Pages
{
    public static readonly Page MainPage = new(typeof(MainPageViewModel));
    public static readonly Page NoNavPage = new(typeof(NoNavPageViewModel));
    public static readonly Page NavPage = new(typeof(NavPageViewModel));
    public static readonly Page WelcomePage = new(typeof(WelcomePageViewModel));
    public static readonly Page FormPage = new(typeof(FormPageViewModel));
    public static readonly Page SettingsPage = new(typeof(SettingsPageViewModel));

    public static readonly IReadOnlyList<Page> All =
    [
        MainPage,
        NoNavPage,
        NavPage,
        WelcomePage,
        FormPage,
        SettingsPage,
    ];
}
