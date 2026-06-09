namespace CollectionsSpecializedExtensions;

using System.Collections;

/// <summary>
/// Extension methods for <see cref="NameValueCollection"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="NameValueCollection"/> from
/// enumerable sources using custom selector functions.
/// </remarks>
public static class NameValueCollectionExtensions {
    /// <summary>
    /// Creates a new <see cref="NameValueCollection"/> from an <see
    /// cref="IEnumerable{TElement}"/> using selector parameters.
    /// </summary>
    /// <typeparam name="TElement">Type of elements in the source.</typeparam>
    /// <returns>A new <see cref="NameValueCollection"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException" />
    public static NameValueCollection ToNameValueCollection<TElement>(
        this IEnumerable<TElement> source,
        Func<TElement, string> keySelector,
        Func<TElement, string> valueSelector) {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var collection = new NameValueCollection();
        foreach (var element in source) {
            collection.Add(keySelector(element), valueSelector(element));
        }
        return collection;
    }

    /// <summary>
    /// Creates a new <see cref="NameValueCollection"/> from an <see
    /// cref="IEnumerable{TElement}"/> using selector parameters.
    /// </summary>
    /// <typeparam name="TElement">Type of elements in the source.</typeparam>
    /// <returns>A new <see cref="NameValueCollection"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException" />
    public static NameValueCollection ToNameValueCollection<TElement>(
        this IEnumerable<TElement> source,
        Func<TElement, string> keySelector,
        Func<TElement, string> valueSelector,
        IEqualityComparer equalityComparer) {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(equalityComparer, nameof(equalityComparer));

        var collection = new NameValueCollection(equalityComparer);
        foreach (var element in source) {
            collection.Add(keySelector(element), valueSelector(element));
        }
        return collection;
    }

    /// <summary>
    /// Creates a new <see cref="NameValueCollection"/> from pattern tuples.
    /// </summary>
    /// <returns>A new <see cref="NameValueCollection"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException" />
    public static NameValueCollection ToNameValueCollection(
        this IEnumerable<(string, string)> source) {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var collection = new NameValueCollection();
        foreach (var item in source) {
            collection.Add(item.Item1, item.Item2);
        }
        return collection;
    }

    /// <summary>
    /// Creates a new <see cref="NameValueCollection"/> from pattern tuples.
    /// </summary>
    /// <returns>A new <see cref="NameValueCollection"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException" />
    public static NameValueCollection ToNameValueCollection(
        this IEnumerable<(string, string)> source,
        IEqualityComparer? equalityComparer) {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(equalityComparer, nameof(equalityComparer));

        var collection = new NameValueCollection(equalityComparer);
        foreach (var item in source) {
            collection.Add(item.Item1, item.Item2);
        }
        return collection;
    }
}
