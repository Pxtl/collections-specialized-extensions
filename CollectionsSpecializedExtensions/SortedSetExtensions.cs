namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="SortedSet{T}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="SortedSet{T}"/> from
/// enumerable sources with custom sorting comparers.
/// </remarks>
public static class SortedSetExtensions
{
    /// <summary>
    /// Creates a new <see cref="SortedSet{T}"/> from an <see cref="IEnumerable{T}"/> source.
    /// </summary>
    /// <returns>A new <see cref="SortedSet{T}"/> with the unique data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static SortedSet<T> ToSortedSet<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        return new SortedSet<T>(source);
    }

    /// <summary>
    /// Creates a new <see cref="SortedSet{T}"/> from an <see cref="IEnumerable{T}"/> source with a custom comparer.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="comparer">The IComparer{T} for sorting.</param>
    /// <returns>A new <see cref="SortedSet{T}"/> with the unique data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="comparer"/> is null.</exception>
    public static SortedSet<T> ToSortedSet<T>(
        this IEnumerable<T> source,
        IComparer<T> comparer)
        where T : notnull
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(comparer, nameof(comparer));

        var set = new SortedSet<T>(comparer);
        foreach (var item in source)
        {
            set.Add(item);
        }
        return set;
    }
}
