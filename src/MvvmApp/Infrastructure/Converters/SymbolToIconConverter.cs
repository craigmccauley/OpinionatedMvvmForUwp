using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace MvvmApp.Infrastructure.Converters;
public class SymbolToIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is Symbol symbol)
        {
            return new SymbolIcon(symbol);
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

