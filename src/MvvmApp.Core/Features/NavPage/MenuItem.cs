using CommunityToolkit.Mvvm.ComponentModel;
using MvvmApp.Infrastructure.Application;


namespace MvvmApp.Features.NavPage
{
    public partial class MenuItem : ObservableObject
    {
        public Page NavDestination { get; set; }
        public string Content { get; set; }
        public Windows.UI.Xaml.Controls.Symbol Glyph { get; set; }
        public NavPageViewModel Parent { get; set; }
    }
}