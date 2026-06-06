namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="SortedList{TKey, TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="SortedList{TKey, TValue}"/> from
/// enumerable sources with custom sorting comparers.
/// </remarks>
public static class SortedListExtensions
{
    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{KeyValuePair{TKey, TValue}}"/> source.
    /// </summary>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <typeparam name="TValue">Type of values.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var list = new SortedList<TKey, TValue>();
        foreach (var item in source)
        {
            list[item.Key] = item.Value;
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{KeyValuePair{TKey, TValue}}"/> source with a custom comparer.
    /// </summary>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <typeparam name="TValue">Type of values.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="comparer">The IComparer{TKey} for sorting keys.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IComparer<TKey> comparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var list = new SortedList<TKey, TValue>(comparer);
        foreach (var item in source)
        {
            list[item.Key] = item.Value;
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> source using key and value selectors.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <typeparam name="TValue">Type of values.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">The key selector function.</param>
    /// <param name="valueSelector">The value selector function.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="valueSelector"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var list = new SortedList<TKey, TValue>();
        foreach (var element in source)
        {
            list[keySelector(element)] = valueSelector(element);
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see cref="SortedList{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> source using key and value selectors with a custom comparer.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <typeparam name="TValue">Type of values.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">The key selector function.</param>
    /// <param name="valueSelector">The value selector function.</param>
    /// <param name="comparer">The IComparer{TKey} for sorting keys.</param>
    /// <returns>A new <see cref="SortedList{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="valueSelector"/> or <paramref name="comparer"/> is null.</exception>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IComparer<TKey> comparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var list = new SortedList<TKey, TValue>(comparer);
        foreach (var element in source)
        {
            list[keySelector(element)] = valueSelector(element);
        }
        return list;
    }
}
