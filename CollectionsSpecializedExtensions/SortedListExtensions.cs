namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="SortedList{TKey,TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="SortedList{TKey,TValue}"/> from
/// enumerable sources with custom sorting.
/// </remarks>
public static class SortedListExtensions {
    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="comparer">A comparer for TKey that will be used to determine sorting and matching within the collection.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IComparer<TKey> comparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));
        var sortedList = new SortedList<TKey, TValue>(comparer);
        foreach (var item in source) {
            sortedList[item.Key] = item.Value;
        }
        return sortedList;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        var sortedList = new SortedList<TKey, TValue>();
        foreach (var item in source) {
            sortedList[item.Key] = item.Value;
        }
        return sortedList;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TSource}"/> from an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="comparer">A comparer for TKey that will be used to determine sorting and matching within the collection.</param>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see cref="SortedList{TKey, TSource}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
    public static SortedList<TKey, TSource> ToSortedList<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));
        var sortedList = new SortedList<TKey, TSource>(comparer);
        foreach (var element in source) {
            sortedList[keySelector(element)] = element;
        }
        return sortedList;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TSource}"/> from an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see cref="SortedList{TKey, TSource}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
    public static SortedList<TKey, TSource> ToSortedList<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        var sortedList = new SortedList<TKey, TSource>();
        foreach (var element in source) {
            sortedList[keySelector(element)] = element;
        }
        return sortedList;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> with key and value selectors.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    /// <param name="comparer">A comparer for TKey that will be used to determine sorting and matching within the collection.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, <paramref name="valueSelector"/>, or <paramref name="comparer"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IComparer<TKey> comparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));
        var sortedList = new SortedList<TKey, TValue>(comparer);
        foreach (var element in source) {
            var key = keySelector(element);
            var value = valueSelector(element);
            sortedList[key] = value;
        }
        return sortedList;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> with key and value selectors.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="valueSelector"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        var sortedList = new SortedList<TKey, TValue>();
        foreach (var element in source) {
            var key = keySelector(element);
            var value = valueSelector(element);
            sortedList[key] = value;
        }
        return sortedList;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="comparer">A comparer for TKey that will be used to determine sorting and matching within the collection.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source,
        IComparer<TKey> comparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));
        var sortedList = new SortedList<TKey, TValue>(comparer);
        foreach (var (key, value) in source) {
            sortedList[key] = value;
        }
        return sortedList;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        var sortedList = new SortedList<TKey, TValue>();
        foreach (var (key, value) in source) {
            sortedList[key] = value;
        }
        return sortedList;
    }
}
