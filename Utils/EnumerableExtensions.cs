namespace Utils;

public static class EnumerableExtensions
{
    /// <summary>
    /// Yields an item while the predicate returns true and the first item that returns false.
    /// i.e. An inclusive version of TakeWhile.
    /// </summary>
    public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, int, bool> predicate)
    {
        var index = -1;

        foreach (var item in source)
        {
            index++;

            yield return item;

            if (!predicate(item, index)) yield break;
        }
    }

    public static void ForEachDo<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source) action.Invoke(item);
    }
    
    public static async Task ForEachDoAsync<T>(this IEnumerable<T> source, Func<T, Task> action)
    {
        var tasks = source.Select(action);
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    public static (IEnumerable<T> trueItems, IEnumerable<T> falseItems) Partition<T>(this IEnumerable<T> source,
        Func<T, bool> predicate)
    {
        var trueItems = new List<T>();
        var falseItems = new List<T>();

        foreach (var item in source)
            if (predicate(item))
                trueItems.Add(item);
            else
                falseItems.Add(item);

        return (trueItems, falseItems);
    }

    public static string Join<T>(this IEnumerable<T>? collection, string separator = ", ",
        Func<T?, string>? toStringFunction = null)
    {
        toStringFunction ??= t => t?.ToString() ?? "";

        return string.Join(separator, (collection ?? Array.Empty<T>()).Select(c => toStringFunction(c)));
    }
}