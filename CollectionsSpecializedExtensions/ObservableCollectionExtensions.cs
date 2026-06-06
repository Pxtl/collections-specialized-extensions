namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="ObservableCollection{T}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="ObservableCollection{T}"/> from
/// enumerable sources.
/// </remarks>
public static class ObservableCollectionExtensions
{
    /// <summary>
    /// Creates a new <see cref="ObservableCollection{T}"/> from an <see
    /// cref="IEnumerable{T}"/> source.
    /// </summary>
    /// <typeparam name="T">Type of elements in the collection.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="ObservableCollection{T}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static ObservableCollection<T> ToObservableCollection<T>(
        this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var collection = new ObservableCollection<T>();
        foreach (var item in source)
        {
            collection.Add(item);
        }
        return collection;
    }
}
