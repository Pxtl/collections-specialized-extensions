namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="KeyedCollection{TKey,TItem}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="KeyedCollection{TKey,TItem}"/> from
/// enumerable sources using custom key selector functions.
/// </remarks>
public static class KeyedCollectionExtensions {
    /// <summary>
    /// Creates a new <see cref="KeyedCollection{TKey,TItem}"/> from an <see
    /// cref="IEnumerable{T}"/> source using a key selector.
    /// </summary>
    /// <typeparam name="T">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">The key selector function.</param>
    /// <returns>A new <see cref="KeyedCollection{TKey,TItem}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
    public static KeyedCollection<TKey, T> ToKeyedCollection<T, TKey>(
        this IEnumerable<T> source,
        Func<T, TKey> keySelector
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        var collection = new LambdaKeyedCollection<TKey, T>(keySelector);
        foreach (var element in source) {
            collection.Add(element);
        }
        return collection;
    }

    /// <summary>
    /// Creates a new <see cref="KeyedCollection{TKey,TItem}"/> from an <see
    /// cref="IEnumerable{T}"/> source using a key selector and comparer.
    /// </summary>
    /// <typeparam name="T">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">The key selector function.</param>
    /// <param name="comparer">The IEqualityComparer{TKey} for comparing keys.</param>
    /// <returns>A new <see cref="KeyedCollection{TKey,TItem}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="comparer"/> is null.</exception>
    public static KeyedCollection<TKey, T> ToKeyedCollection<T, TKey>(
        this IEnumerable<T> source,
        Func<T, TKey> keySelector,
        IEqualityComparer<TKey> comparer
    )
    where TKey : notnull {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var collection = new LambdaKeyedCollection<TKey, T>(keySelector, comparer);
        foreach (var element in source) {
            collection.Add(element);
        }
        return collection;
    }
}
