using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmApp.Infrastructure.Common;
public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private readonly Dictionary<string, object> properties = new();
    protected T Get<T>([CallerMemberName] string propertyName = null)
    {
        _ = properties.TryGetValue(propertyName, out T value);
        return value;
    }
    protected bool Set<T>(
        T value,
        [CallerMemberName] string propertyName = null)
    {
        if (properties.TryGetValue(propertyName, out object existingValue) 
            && Equals(existingValue, value))
        {
            return false;
        }
        properties[propertyName] = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}
