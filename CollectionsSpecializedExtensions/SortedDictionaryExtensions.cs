namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="SortedDictionary{TKey,TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="SortedDictionary{TKey,TValue}"/> from
/// enumerable sources using custom selector functions and sorting comparers.
/// </remarks>
public static class SortedDictionaryExtensions
{
    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see
    /// cref="IEnumerable{KeyValuePair{TKey, TValue}}"/> source.
    /// </summary>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull, IEquatable<TKey>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var dictionary = new SortedDictionary<TKey, TValue>();
        foreach (var item in source)
        {
            dictionary[item.Key] = item.Value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see
    /// cref="IEnumerable{KeyValuePair{TKey, TValue}}"/> source with a custom key comparer.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="comparer">The IComparer{TKey} for sorting keys.</param>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="comparer"/> is null.</exception>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IComparer<TKey> comparer)
        where TKey : notnull, IEquatable<TKey>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var dictionary = new SortedDictionary<TKey, TValue>(comparer);
        foreach (var item in source)
        {
            dictionary[item.Key] = item.Value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see
    /// cref="IEnumerable{TSource}"/> using key selector.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">The key selector function.</param>
    /// <returns>A new <see cref="SortedDictionary{TKey, TKey}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
    public static SortedDictionary<TKey, TSource> ToSortedDictionary<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector)
        where TKey : notnull, IEquatable<TKey>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        var dictionary = new SortedDictionary<TKey, TSource>();
        foreach (var element in source)
        {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see
    /// cref="IEnumerable{TSource}"/> using key selector with a custom key comparer.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">The key selector function.</param>
    /// <param name="comparer">The IComparer{TKey} for sorting keys.</param>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="comparer"/> is null.</exception>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IComparer<TKey> comparer)
        where TKey : notnull, IEquatable<TKey>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var dictionary = new SortedDictionary<TKey, TValue>(comparer);
        foreach (var element in source)
        {
            dictionary[keySelector(element)] = valueSelector(element);
        }
        return dictionary;
    }
}
