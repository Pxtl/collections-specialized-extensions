namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="ISet{T}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="ISet{T}"/> from
/// enumerable sources.
/// </remarks>
public static class ISetExtensions {
    /// <summary>
    /// Creates a new <see cref="ISet{T}"/> from an <see cref="IEnumerable{T}"/> source.
    /// </summary>
    /// <typeparam name="TSet">Concrete type of the ISet.</typeparam>
    /// <typeparam name="T">Type of elements in the source.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="ISet{T}"/> with the unique data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static TSet ToISet<TSet, T>(
        this IEnumerable<T> source
    )
    where TSet : ISet<T>, new() {

        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var set = new TSet();
        foreach (var item in source) {
            set.Add(item);
        }
        return set;
    }

    /// <summary>
    /// Creates a new <see cref="ISet{T}"/> from an <see cref="IEnumerable{T}"/> source
    /// using the factory to construct it. The factory can accept any IEqualityComparer{T}
    /// or other parameters as needed by the specific ISet implementation.
    /// </summary>
    /// <remarks>
    /// This overload allows the factory to handle any comparer/equality configuration.
    /// For example: new HashSet&lt;string&gt;(StringComparer.OrdinalIgnoreCase)
    /// </remarks>
    /// <typeparam name="TSet">Concrete type of the ISet.</typeparam>
    /// <typeparam name="T">Type of elements in the source.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="factory">The factory to create the set.</param>
    /// <returns>A new <see cref="ISet{T}"/> with the unique data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="factory"/> is null.</exception>
    public static TSet ToISet<TSet, T>(
        this IEnumerable<T> source,
        Func<TSet> factory
    )
    where TSet : ISet<T> {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(factory, nameof(factory));

        var set = factory();
        foreach (var item in source) {
            set.Add(item);
        }
        return set;
    }
}
