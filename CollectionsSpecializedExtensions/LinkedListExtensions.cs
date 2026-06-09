namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="LinkedList{T}"/>.
/// </summary>
/// <remarks>
/// Provides LINQ-like extension methods to create <see cref="LinkedList{T}"/> from
/// enumerable sources.
/// </remarks>
public static class LinkedListExtensions {
    /// <summary>
    /// Creates a new <see cref="LinkedList{T}"/> from an <see
    /// cref="IEnumerable{T}"/> source.
    /// </summary>
    /// <typeparam name="T">Type of elements in the linked list.</typeparam>
    /// <param name="source">The enumerable source.</param>
    /// <returns>A new <see cref="LinkedList{T}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static LinkedList<T> ToLinkedList<T>(
        this IEnumerable<T> source) {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var list = new LinkedList<T>();
        foreach (var item in source) {
            list.AddLast(item);
        }
        return list;
    }
}
