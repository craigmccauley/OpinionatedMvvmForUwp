using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Infrastructure.Application;


namespace MvvmApp.Features.NavPage
{
    public partial class MenuItem : ObservableObject
    {
        [ObservableProperty]
        private bool isSelected;
        public Page NavDestination { get; init; }
        public string Content { get; init; }
        public Windows.UI.Xaml.Controls.Symbol Glyph { get; init; }
        public NavPageViewModel Parent { get; init; }
    }
}