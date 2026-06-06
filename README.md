# Collections Specialized Extensions (.NET 10)

This library provides extension methods to work with lesser-known ObjectModel
and Specialized collection-types with the same convenience that is provided for
more common collection-types.

## Build & Run

```bash
cd /workspace/collections-specialized-extensions
dotnet build CollectionsSpecializedExtensions.slnx
```

## Running Tests

```bash
dotnet run --project Tests
```

## API Reference

### NameValueCollectionExtensions

#### Selector Parameters

```csharp
var collection = items.ToNameValueCollection(
    item => item.Id,
    item => item.Name
);
```

#### Tuple Selector

```csharp
var collection = pairs.ToNameValueCollection(
    pair => pair.Key,
    pair => pair.Value
);
```

#### Pattern Tuple Overload

```csharp
var collection = new[] { ("a", "hello"), ("b", "world") }
    .ToNameValueCollection();
```

**API:**

```csharp
public static class NameValueCollectionExtensions
{
    /// <summary>
    /// Creates NameValueCollection from IEnumerable with selector params
    /// </summary>
    public static NameValueCollection ToNameValueCollection<TElement>(
        this IEnumerable<TElement> source,
        Func<TElement, string> keySelector,
        Func<TElement, string> valueSelector);

    /// <summary>
    /// Creates NameValueCollection from IEnumerable<(string, string)>
    /// </summary>
    public static NameValueCollection ToNameValueCollection<T>(
        this IEnumerable<(string, string)> source);
}
```

### OrderedDictionaryExtensions

#### Keyword Selector

```csharp
var dictionary = items.ToOrderedDictionary(
    item => item.Key,
    item => item.Value
);
```

#### Pattern Tuple Overload

```csharp
var dictionary = new[] { ("a", "hello"), ("b", "world") }
    .ToOrderedDictionary();
```

**API:**

```csharp
public static class OrderedDictionaryExtensions
{
    /// <summary>
    /// Creates OrderedDictionary from IEnumerable&lt;(TKey, TValue)&gt;
    /// </summary>
    /// <param name="source">IEnumerable&lt;(TKey, TValue)&gt; source</param>
    /// <returns>OrderedDictionary</returns>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TKey, TValue>(
        this IEnumerable<(TKey, TValue)> source)
        where TKey : notnull;

    /// <summary>
    /// Creates OrderedDictionary from IEnumerable with selector params
    /// </summary>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector)
        where TKey : notnull;

    /// <summary>
    /// Creates OrderedDictionary with custom equality comparer
    /// </summary>
    public static OrderedDictionary<TKey, TValue> ToOrderedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IEqualityComparer<TKey> comparer)
        where TKey : notnull;
}
```

### ObservableCollectionExtensions

```csharp
var collection = items.ToObservableCollection();
```

**API:**

```csharp
public static class ObservableCollectionExtensions
{
    /// <summary>
    /// Creates ObservableCollection from IEnumerable
    /// </summary>
    public static ObservableCollection<T> ToObservableCollection<T>(
        this IEnumerable<T> source);
}
```

### LinkedListExtensions

```csharp
var list = items.ToLinkedList();
```

**API:**

```csharp
public static class LinkedListExtensions
{
    /// <summary>
    /// Creates LinkedList from IEnumerable
    /// </summary>
    public static LinkedList<T> ToLinkedList<T>(
        this IEnumerable<T> source);
}
```

### SortedListExtensions

#### Dictionary Source

```csharp
var dictionary = new[] { 
    new("c", 3), 
    new("a", 1), 
    new("b", 2), 
    new("d", 4) 
}.ToSortedList();
```

#### With Key and Value Selectors

```csharp
var list = items.ToSortedList(
    item => item.Name,
    item => item.Value
);
```

#### With Comparer

```csharp
var list = items.ToSortedList(
    item => item.Name,
    item => item.Id,
    StringComparer.Ordinal
);
```

**API:**

```csharp
public static class SortedListExtensions
{
    /// <summary>
    /// Creates SortedList from IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;
    /// </summary>
    /// <param name="source">IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; source</param>
    /// <returns>SortedList</returns>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull;

    /// <summary>
    /// Creates SortedList from IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; with custom comparer
    /// </summary>
    /// <param name="source">IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; source</param>
    /// <param name="comparer">IComparer&lt;TKey&gt; for sorting keys</param>
    /// <returns>SortedList</returns>
    public static SortedList<TKey, TValue> ToSortedList<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IComparer<TKey> comparer)
        where TKey : notnull;

    /// <summary>
    /// Creates SortedList from IEnumerable with selector params
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <param name="keySelector">Key selector function</param>
    /// <param name="valueSelector">Value selector function</param>
    /// <returns>SortedList</returns>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector)
        where TKey : notnull;

    /// <summary>
    /// Creates SortedList from IEnumerable with selector params and custom comparer
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <param name="keySelector">Key selector function</param>
    /// <param name="valueSelector">Value selector function</param>
    /// <param name="comparer">IComparer&lt;TKey&gt; for sorting keys</param>
    /// <returns>SortedList</returns>
    public static SortedList<TKey, TValue> ToSortedList<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IComparer<TKey> comparer)
        where TKey : notnull;
}
```

### SortedSetExtensions

#### Basic

```csharp
var set = items.ToSortedSet();
```

#### With Comparer

```csharp
var set = items.ToSortedSet(
    new IntComparer()
);
```

**API:**

```csharp
public static class SortedSetExtensions
{
    /// <summary>
    /// Creates SortedSet from IEnumerable
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <returns>SortedSet</returns>
    public static SortedSet<T> ToSortedSet<T>(
        this IEnumerable<T> source);

    /// <summary>
    /// Creates SortedSet from IEnumerable with custom comparer
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <param name="comparer">IComparer&lt;T&gt; for sorting</param>
    /// <returns>SortedSet</returns>
    public static SortedSet<T> ToSortedSet<T>(
        this IEnumerable<T> source,
        IComparer<T> comparer)
        where T : notnull;
}
```

### SortedDictionaryExtensions

#### Dictionary Source

```csharp
var dictionary = new[] { 
    new("c", 3), 
    new("a", 1), 
    new("b", 2) 
}.ToSortedDictionary();
```

#### With Selector

```csharp
var dictionary = items.ToSortedDictionary(
    item => item.Id
);
```

#### With Selector and Comparer

```csharp
var dictionary = items.ToSortedDictionary(
    item => item.Id,
    item => item.Value,
    StringComparer.Ordinal
);
```

**API:**

```csharp
public static class SortedDictionaryExtensions
{
    /// <summary>
    /// Creates SortedDictionary from IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt;
    /// </summary>
    /// <param name="source">IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; source</param>
    /// <returns>SortedDictionary</returns>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source)
        where TKey : notnull, IEquatable<TKey>;

    /// <summary>
    /// Creates SortedDictionary from IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; with custom comparer
    /// </summary>
    /// <param name="source">IEnumerable&lt;KeyValuePair&lt;TKey, TValue&gt;&gt; source</param>
    /// <param name="comparer">IComparer&lt;TKey&gt; for sorting keys</param>
    /// <returns>SortedDictionary</returns>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source,
        IComparer<TKey> comparer)
        where TKey : notnull, IEquatable<TKey>;

    /// <summary>
    /// Creates SortedDictionary from IEnumerable with key selector
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <param name="keySelector">Key selector function</param>
    /// <returns>SortedDictionary</returns>
    public static SortedDictionary<TKey, TSource> ToSortedDictionary<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector)
        where TKey : notnull, IEquatable<TKey>;

    /// <summary>
    /// Creates SortedDictionary from IEnumerable with key and value selectors and custom comparer
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <param name="keySelector">Key selector function</param>
    /// <param name="valueSelector">Value selector function</param>
    /// <param name="comparer">IComparer&lt;TKey&gt; for sorting keys</param>
    /// <returns>SortedDictionary</returns>
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TSource, TKey, TValue>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        Func<TSource, TValue> valueSelector,
        IComparer<TKey> comparer)
        where TKey : notnull, IEquatable<TKey>;
}
```

### KeyedCollectionExtensions

#### Basic Selector

```csharp
var collection = items.ToKeyedCollection(item => item.Name);
```

#### With Comparer

```csharp
var collection = items.ToKeyedCollection(
    item => item.Name,
    new CaseInsensitiveStringComparer()
);
```

**API:**

```csharp
public static class KeyedCollectionExtensions
{
    /// <summary>
    /// Creates KeyedCollection from IEnumerable with selector
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <param name="keySelector">Key selector function</param>
    /// <returns>KeyedCollection</returns>
    public static KeyedCollection<TKey, T> ToKeyedCollection<T, TKey>(
        this IEnumerable<T> source,
        Func<T, TKey> keySelector)
        where TKey : notnull;

    /// <summary>
    /// Creates KeyedCollection from IEnumerable with selector and comparer
    /// </summary>
    /// <param name="source">IEnumerable source</param>
    /// <param name="keySelector">Key selector function</param>
    /// <param name="comparer">IEqualityComparer&lt;TKey&gt; for comparing keys</param>
    /// <returns>KeyedCollection</returns>
    public static KeyedCollection<TKey, T> ToKeyedCollection<T, TKey>(
        this IEnumerable<T> source,
        Func<T, TKey> keySelector,
        IEqualityComparer<TKey> comparer)
        where TKey : notnull;
}
```

## Test File Organization

| Test File | Tests Description |
|--|--|
| OrderedDictionaryExtensionsTest.cs | Tests for ToOrderedDictionary overloads |
| NameValueCollectionExtensionsTests.cs | Tests for ToNameValueCollection overloads |
| LinkedListExtensionsTest.cs | Tests for ToLinkedList |
| ObservableCollectionExtensionsTest.cs | Tests for ToObservableCollection |
| SortedListExtensionsTest.cs | Tests for ToSortedList overloads |
| SortedSetExtensionsTest.cs | Tests for ToSortedSet overloads |
| KeyedCollectionExtensionsTest.cs | Tests for ToKeyedCollection |

## License

MIT License
