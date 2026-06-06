namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="SortedDictionary{TKey,TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="SortedDictionary{TKey,TValue}"/> from
/// enumerable sources using custom selector functions and comparison.
/// </remarks>
public static class SortedDictionaryExtensions
{
    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> source.
    /// </summary>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        var sortedDict = new SortedDictionary<TKey, TValue>();
        foreach (var item in source)
        {
            sortedDict.Add(item.Key, item.Value);
        }
        return sortedDict;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> source.
    /// </summary>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IComparer<TKey> comparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));
        var sortedDict = new SortedDictionary<TKey, TValue>(comparer);
        foreach (var item in source)
        {
            sortedDict.Add(item.Key, item.Value);
        }
        return sortedDict;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedDictionary<TKey, TSource> ToSortedDictionary<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector)
        where TKey : notnull
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
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static SortedDictionary<TKey, TSource> ToSortedDictionary<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var dictionary = new SortedDictionary<TKey, TSource>(comparer);
        foreach (var element in source)
        {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> with key and value selectors.
    /// </summary>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the key-selector and value-selector mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var dictionary = new SortedDictionary<TKey, TValue>();
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> with key and value selectors.
    /// </summary>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the key-selector and value-selector mapped data.</returns>
    /// <exception cref="ArgumentNullException"/>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TSource, TKey, TValue>(
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

        var dictionary = new SortedDictionary<TKey, TValue>();
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/>.
    /// </summary>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="source"/> is null.</exception>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var dictionary = new SortedDictionary<TKey, TValue>();
        foreach (var element in source)
        {
            dictionary[element.Item1] = element.Item2;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="SortedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/>.
    /// </summary>
    /// <returns>A new <see cref="SortedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="source"/> is null.</exception>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source,
        IComparer<TKey> comparer)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var dictionary = new SortedDictionary<TKey, TValue>(comparer);
        foreach (var element in source)
        {
            dictionary[element.Item1] = element.Item2;
        }
        return dictionary;
    }
}
