namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="IDictionary{TKey,TValue}"/>.
/// </summary>
public static class IDictionaryExtensions
{
    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> 
    /// of <see cref="KeyValuePair{TKey, TValue}"/> source using the dictionaryFactoryFunction to 
    /// construct it.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="dictionaryFactoryFunction">The equality comparer.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values in the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="dictionaryFactoryFunction"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TDictionary> dictionaryFactoryFunction)
        where TKey : notnull
        where TDictionary: IDictionary<TKey, TValue>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(dictionaryFactoryFunction, nameof(dictionaryFactoryFunction));
        return dictionaryFactoryFunction();
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TSource}"/> from an <see cref="IEnumerable{TSource}"/>
    /// using the dictionaryFactoryFunction to construct it.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="dictionaryFactoryFunction">The equality comparer.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TSource}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="dictionaryFactoryFunction"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TDictionary> dictionaryFactoryFunction)
        where TKey : notnull 
        where TDictionary: IDictionary<TKey, TSource>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(dictionaryFactoryFunction, nameof(dictionaryFactoryFunction));

        var dictionary = dictionaryFactoryFunction();
        foreach (var element in source)
        {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> with key and value selectors.
    /// using the dictionaryFactoryFunction to construct it.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    /// <param name="dictionaryFactoryFunction">The equality comparer.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values in the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, <paramref name="valueSelector"/>, or <paramref name="dictionaryFactoryFunction"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        Func<TDictionary> dictionaryFactoryFunction)
        where TKey : notnull
        where TDictionary: IDictionary<TKey, TValue>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));
        ArgumentNullException.ThrowIfNull(dictionaryFactoryFunction, nameof(dictionaryFactoryFunction));

        var dictionary = dictionaryFactoryFunction();
        foreach (var element in source)
        {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/> source
    /// using the dictionaryFactoryFunction to construct it.
    /// </summary>
    /// <param name="source">The enumerable source.</param>
    /// <param name="dictionaryFactoryFunction">The equality comparer.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values in the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="dictionaryFactoryFunction"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source,
        Func<TDictionary> dictionaryFactoryFunction)
        where TKey : notnull
        where TDictionary: IDictionary<TKey, TValue>
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(dictionaryFactoryFunction, nameof(dictionaryFactoryFunction));

        var dictionary = dictionaryFactoryFunction();
        foreach (var item in source)
        {
            dictionary[item.Item1] = item.Item2;
        }
        return dictionary;
    }
}
