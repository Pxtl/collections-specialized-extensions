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

## Test File Organization

| Test File | Tests Description |
|--|--|
| OrderedDictionaryExtensionsTest.cs | Tests for ToOrderedDictionary overloads |
| NameValueCollectionExtensionsTests.cs | Tests for ToNameValueCollection overloads |
| LinkedListExtensionsTest.cs | Tests for ToLinkedList |
| ObservableCollectionExtensionsTest.cs | Tests for ToObservableCollection |

## License

MIT License
