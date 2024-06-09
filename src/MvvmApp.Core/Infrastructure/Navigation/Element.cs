using System;
using Windows.UI.Xaml;

namespace MvvmApp.Infrastructure.Navigation;
public class Element : DependencyObject
{
    public static readonly DependencyProperty DataTypeProperty = DependencyProperty.RegisterAttached(
        "DataType",
        typeof(Type),
        typeof(Element),
        new PropertyMetadata(default(Type)));

    public static void SetDataType(DependencyObject element, Type value) =>
        element.SetValue(DataTypeProperty, value);

    public static Type GetDataType(DependencyObject element) =>
        (Type)element.GetValue(DataTypeProperty);
}
