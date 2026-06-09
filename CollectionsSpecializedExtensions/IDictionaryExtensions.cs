namespace CollectionsSpecializedExtensions;

/// <summary>
/// Extension methods for <see cref="IDictionary{TKey,TValue}"/>.
/// </summary>
public static class IDictionaryExtensions {
    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/>
    /// of <see cref="KeyValuePair{TKey, TValue}"/>.
    /// </summary>
    /// <param name="source">The enumerable source of key-value pairs.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values in the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TValue>, new() {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        var dictionary = new TDictionary();
        foreach (var item in source) {
            dictionary[item.Key] = item.Value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/>
    /// of <see cref="KeyValuePair{TKey, TValue}"/> source using the factory to construct it.
    /// </summary>
    /// <param name="source">The enumerable source of key-value pairs.</param>
    /// <param name="factory">The factory to create the dictionary.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values in the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="factory"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        Func<TDictionary> factory
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TValue> {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(factory, nameof(factory));
        var dictionary = factory();
        foreach (var item in source) {
            dictionary[item.Key] = item.Value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TSource}"/> from an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <param name="source">The enumerable source of elements.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TSource}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TSource>, new() {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        var dictionary = new TDictionary();
        foreach (var element in source) {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TSource}"/> from an <see cref="IEnumerable{TSource}"/>
    /// using the factory to construct it.
    /// </summary>
    /// <param name="source">The enumerable source of elements.</param>
    /// <param name="factory">The factory to create the dictionary.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TSource}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="factory"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TSource>(
        this IEnumerable<TSource> source,
        Func<TDictionary> factory,
        Func<TSource, TKey> keySelector
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TSource> {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(factory, nameof(factory));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));

        var dictionary = factory();
        foreach (var element in source) {
            dictionary[keySelector(element)] = element;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> with key and value selectors.
    /// </summary>
    /// <param name="source">The enumerable source of elements.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values of the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, <paramref name="valueSelector"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TValue>, new() {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var dictionary = new TDictionary();
        foreach (var element in source) {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }


    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> with key and value selectors
    /// using the factory to construct it.
    /// </summary>
    /// <param name="source">The enumerable source of elements.</param>
    /// <param name="factory">The factory to create the dictionary.</param>
    /// <param name="keySelector">A selector for keys.</param>
    /// <param name="valueSelector">A selector for values.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TSource">Type of elements in the source.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values of the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/>, <paramref name="keySelector"/>, <paramref name="valueSelector"/>, or <paramref name="factory"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TDictionary> factory,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TValue> {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(factory, nameof(factory));
        ArgumentNullException.ThrowIfNull(keySelector, nameof(keySelector));
        ArgumentNullException.ThrowIfNull(valueSelector, nameof(valueSelector));

        var dictionary = factory();
        foreach (var element in source) {
            var key = keySelector(element);
            var value = valueSelector(element);
            dictionary[key] = value;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/> source.
    /// </summary>
    /// <param name="source">The enumerable source of tups.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values in the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TValue>, new() {

        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var dictionary = new TDictionary();
        foreach (var item in source) {
            dictionary[item.Item1] = item.Item2;
        }
        return dictionary;
    }

    /// <summary>
    /// Creates a new <see cref="IDictionary{TKey, TValue}"/> from an <see cref="IEnumerable{T}"/> of <see cref="ValueTuple{TKey, TValue}"/> source
    /// using the factory to construct it.
    /// </summary>
    /// <param name="source">The enumerable source of tups.</param>
    /// <param name="factory">The factory to create the dictionary.</param>
    /// <typeparam name="TDictionary">Concrete type of the IDictionary.</typeparam>
    /// <typeparam name="TKey">Type of keys of the IDictionary.</typeparam>
    /// <typeparam name="TValue">Type of values in the IDictionary.</typeparam>
    /// <returns>A new <see cref="IDictionary{TKey, TValue}"/> with the mapped data.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="factory"/> is null.</exception>
    public static TDictionary ToIDictionary<TDictionary, TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source,
        Func<TDictionary> factory
    )
    where TKey : notnull
    where TDictionary : IDictionary<TKey, TValue> {

        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(factory, nameof(factory));

        var dictionary = factory();
        foreach (var item in source) {
            dictionary[item.Item1] = item.Item2;
        }
        return dictionary;
    }
}
