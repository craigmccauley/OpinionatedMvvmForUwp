using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.Common;


namespace MvvmApp.Features.NavPage
{
    public class MenuItem : NotifyPropertyChangedBase
    {
        public bool IsSelected
        {
            get => Get<bool>();
            set => Set(value);
        }

        public Page NavDestination { get; init; }
        public string Content { get; init; }
        public Windows.UI.Xaml.Controls.Symbol Glyph { get; init; }
        public NavPageViewModel Parent { get; init; }
    }
}