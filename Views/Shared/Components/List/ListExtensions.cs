using System;
using System.Collections;

public static class ListExtensions
{
    public static List ToListView(this IEnumerable items, Func<object,ViewItem> convert)
    {
        var result = new List();
        foreach(var item in items)
        {
            result.ListItems.Add(convert(item));
        }
        return result;
    }
}