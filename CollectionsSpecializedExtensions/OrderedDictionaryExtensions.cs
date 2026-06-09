namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="OrderedDictionary{TKey,TValue}"/>.
/// </summary>
public static class OrderedDictionaryExtensions {
    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return new OrderedDictionary<TKey, TValue>(source);
    }

    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="KeyValuePair{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="equalityComparer">The equality comparer.</param>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="equalityComparer"/> is null.</exception>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IEqualityComparer<TKey> equalityComparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(equalityComparer, nameof(equalityComparer));
        return new OrderedDictionary<TKey, TValue>(source, equalityComparer);
    }

    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TSource}"/> from an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TSource}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
    public static OrderedDictionary<TKey, TSource> ToOrderedDictionary<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        var dictionary = new OrderedDictionary<TKey, TSource>();
        foreach (var element in source) {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TSource}"/> from an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="equalityComparer">The equality comparer.</param>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TSource}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="equalityComparer"/> is null.</exception>
    public static OrderedDictionary<TKey, TSource> ToOrderedDictionary<TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey> equalityComparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(equalityComparer, nameof(equalityComparer));

        var dictionary = new OrderedDictionary<TKey, TSource>(equalityComparer);
        foreach (var element in source) {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TValue}"/> with key and value selectors.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <typeparam name="TValue">Type of values.</typeparam>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="valueSelector"/> is null.</exception>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var dictionary = new OrderedDictionary<TKey, TValue>();
        foreach (var element in source) {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TValue}"/> with key and value selectors.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    /// <param name="equalityComparer">The equality comparer.</param>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <typeparam name="TValue">Type of values.</typeparam>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, <paramref name="valueSelector"/>, or <paramref name="equalityComparer"/> is null.</exception>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IEqualityComparer<TKey> equalityComparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(equalityComparer, nameof(equalityComparer));

        var dictionary = new OrderedDictionary<TKey, TValue>(equalityComparer);
        foreach (var element in source) {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var dictionary = new OrderedDictionary<TKey, TValue>();
        foreach (var item in source) {
            dictionary[item.Item1] = item.Item2;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="OrderedDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="equalityComparer">The equality comparer.</param>
    /// <returns>A new <see cref="OrderedDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="equalityComparer"/> is null.</exception>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source,
        IEqualityComparer<TKey> equalityComparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(equalityComparer, nameof(equalityComparer));

        var dictionary = new OrderedDictionary<TKey, TValue>(equalityComparer);
        foreach (var item in source) {
            dictionary[item.Item1] = item.Item2;
        }
        return dictionary;
    }
}
