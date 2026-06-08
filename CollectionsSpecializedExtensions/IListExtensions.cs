namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="IList{T}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="IList{T}"/> from
/// enumerable sources.
/// </remarks>
public static class IListExtensions
{
    /// <summary>
    /// Creates a new <see cref="IList{T}"/> from an <see cref="IEnumerable{T}"/> source.
    /// </summary>
    /// <typeparam name="TList">Concrete type of the IList.</typeparam>
    /// <typeparam name="T">Type of elements in the source.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="IList{T}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static TList ToIList<TList, T>(
        this IEnumerable<T> source)
        where TList: IList<T>, new()
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var list = new TList();
        foreach (var item in source)
        {
            list.Add(item);
        }
        return list;
    }

    /// <summary>
    /// Creates a new <see cref="IList{T}"/> from an <see cref="IEnumerable{T}"/> source
    /// using the factory to construct it.
    /// </summary>
    /// <typeparam name="TList">Concrete type of the IList.</typeparam>
    /// <typeparam name="T">Type of elements in the source.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <param name="factory">The factory to create the list.</param>
    /// <returns>A new <see cref="IList{T}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="factory"/> is null.</exception>
    public static TList ToIList<TList, T>(
        this IEnumerable<T> source,
        Func<TList> factory)
        where TList: IList<T>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(factory, nameof(factory));

        var list = factory();
        foreach (var item in source)
        {
            list.Add(item);
        }
        return list;
    }
}
