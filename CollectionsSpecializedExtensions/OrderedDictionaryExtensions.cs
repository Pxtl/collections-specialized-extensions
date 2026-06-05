namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="OrderedDictionary{TKey,TValue}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="OrderedDictionary{TKey,TValue}"/> from
/// enumerable sources.
/// </remarks>
public static class OrderedDictionaryExtensions
{
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source
    ) where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return new OrderedDictionary<TKey, TValue>(source, EqualityComparer<TKey>.Default);
    }

    public static OrderedDictionary<TKey, TElement> ToOrderedDictionary<TElement, TKey>(
        this IEnumerable<TElement> source,
        Func<TElement, TKey> keySelector
    ) where TKey : notnull
        => source.ToOrderedDictionary<TElement, TKey, TElement>(keySelector, v => v);

    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector
    ) where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var dictionary = new OrderedDictionary<TKey, TValue>(EqualityComparer<TKey>.Default);
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }
}
