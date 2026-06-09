namespace CollectionsSpecializedExtensions;

/// <summary>
/// Represents a <see cref="KeyedCollection{TKey,TItem}"/> with a lambda key selector.
/// </summary>
/// <typeparam name="TKey">Type of keys.</typeparam>
/// <typeparam name="TItem">Type of items.</typeparam>
public class LambdaKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>
    where TKey : notnull {
    /// <summary>
    /// Initializes a new instance of the <see cref="LambdaKeyedCollection{TKey,TItem}"/> class with a key selector.
    /// </summary>
    /// <param name="keySelector">The key selector function.</param>
    public LambdaKeyedCollection(Func<TItem, TKey> keySelector) {
        KeySelector = keySelector;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LambdaKeyedCollection{TKey,TItem}"/> class with a key selector and comparer.
    /// </summary>
    /// <param name="comparer">The IEqualityComparer{TKey} for comparing keys.</param>
    /// <param name="keySelector">The key selector function.</param>
    public LambdaKeyedCollection(Func<TItem, TKey> keySelector, IEqualityComparer<TKey> comparer)
        : base(comparer) {
        KeySelector = keySelector;
    }

    /// <summary>
    /// Gets the key selector function.
    /// </summary>
    public Func<TItem, TKey> KeySelector { get; init; }

    /// <summary>
    /// Gets the key for the specified item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The key for the item.</returns>
    protected override TKey GetKeyForItem(TItem item) => KeySelector(item);
}
