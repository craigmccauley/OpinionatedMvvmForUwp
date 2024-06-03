using System.Collections.Generic;

namespace MvvmApp.Infrastructure.Common;
public static class DictionaryExtensions
{
    public static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T value)
    {
        if (dictionary != null 
            && dictionary.TryGetValue(key, out var obj) && obj is T t)
        {
            value = t;
            return true;
       }
        value = default;
        return false;
    }
}
