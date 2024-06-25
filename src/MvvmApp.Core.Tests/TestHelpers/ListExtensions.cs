using System;
using System.Collections.Generic;
using System.Linq;

namespace MvvmApp.Core.Tests.TestHelpers;
public static class ListExtensions
{
    //pick random item from list
    public static T PickRandom<T>(this IEnumerable<T> items)
    {
        var list = items.ToList();
        var random = new Random();
        return list[random.Next(list.Count)];
    }
}
