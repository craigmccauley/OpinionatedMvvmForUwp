using MvvmApp.Features.MainPage;
using MvvmApp.Features.NavPage;
using MvvmApp.Features.NoNavPage;
using System;

namespace MvvmApp.Infrastructure.Application;

public record Page(Type PageType, Type ViewModelType);
public static class Pages
{
    public static Page MainPage = new(typeof(MainPage), typeof(MainPageViewModel));
    public static Page NoNavPage = new(typeof(NoNavPage), typeof(NoNavPageViewModel));
    public static Page NavPage = new(typeof(NavPage), typeof(NavPageViewModel));

    public static Page[] All =
    [
        MainPage,
        NoNavPage,
        NavPage,
    ];
}
