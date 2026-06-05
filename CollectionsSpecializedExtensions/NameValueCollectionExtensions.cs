namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="NameValueCollection"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="NameValueCollection"/> containing
/// from enumerable sources.
/// </remarks>
public static class NameValueCollectionExtensions
{
    #region ICollection<T> extensions
    /// <summary>
    /// Creates a new <see cref="NameValueCollection"/> from an <see
    /// cref="IEnumerable{TElement}"/> using the specified <paramref
    /// name="keySelector"/> and <paramref name="valueSelector"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements in the enumerable source.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A function that returns a key for each element.</param>
    /// <param name="valueSelector">A function that returns a value for each element.</param>
    /// <returns>A new <see cref="List{T}"/> containing the data from <paramref name="source"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="valueSelector"/> is null.</exception>
    public static NameValueCollection ToNameValueCollection<TElement>(
        this IEnumerable<TElement> source,
        Func<TElement, string> keySelector,
        Func<TElement, string> valueSelector)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var collection = new NameValueCollection();
        foreach (var element in source)
        {
            collection.Add(keySelector(element), valueSelector(element));
        }
        return collection;
    }

    /// <summary>
    /// Creates a new <see cref="NameValueCollection"/> from an <see
    /// cref="IEnumerable{TElement}"/> using the specified <paramref
    /// name="elementSelector"/>.
    /// </summary>
    /// <typeparam name="TElement">Type of the elements in the enumerable source.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="elementSelector">A function that returns both key and value.</param>
    /// <returns>A new <see cref="List{T}"/> containing the data from <paramref name="source"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="elementSelector"/> is null.</exception>
    public static NameValueCollection ToNameValueCollection<TElement>(
        this IEnumerable<TElement> source,
        Func<TElement, (string key, string value)> elementSelector)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(elementSelector, nameof(elementSelector));

        var collection = new NameValueCollection();
        foreach (var element in source)
        {
            var (key, value) = elementSelector(element);
            collection.Add(key, value);
        }
        return collection;
    }

    #endregion
}
