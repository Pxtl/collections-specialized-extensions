namespace CollectionsSpecializedExtensions.Tests;

public class ToIDictionary_FromKeyValuePair
{
    [Fact]
    public void CreatesDictionary_FromKeyValuePair()
    {
        var collection = new[] {
            new KeyValuePair<string, int>("a", 1),
            new KeyValuePair<string, int>("b", 2)
        }.ToIDictionary(() => new Dictionary<string, int>());

        Assert.Equal(2, collection.Count);
        Assert.Equal(1, collection["a"]);
    }
}

public class ToIDictionary_FromObjectGraph
{
    [Fact]
    public void CreatesDictionary_WithObjectGraph()
    {
        var collection = new[] {
            new { Name = "Alice", Score = 100 },
            new { Name = "Bob", Score = 200 }
        }.ToIDictionary(
            () => new Dictionary<string, int>(),
            x => x.Name,
            x => x.Score);

        Assert.Equal(2, collection.Count);
        Assert.Equal(100, collection["Alice"]);
    }

    [Fact]
    public void ThrowsOnNullKeySelector()
    {
        var source = new [] {
            new KeyValuePair<string, int>("a", 1)
        };

        Func<KeyValuePair<string, int>, string>? keySelector = null;

        Assert.Throws<ArgumentNullException>(() =>
            source.ToIDictionary(
                () => new Dictionary<string, int>(),
                keySelector!,
                x => x.Value));
    }

    [Fact]
    public void ThrowsOnNullValueSelector()
    {
        var source = new [] {
            new KeyValuePair<string, int>("a", 1)
        };

        Func<KeyValuePair<string, int>, int>? valueSelector = null;

        Assert.Throws<ArgumentNullException>(() =>
            source.ToIDictionary(
                () => new Dictionary<string, int>(),
                x => x.Key,
                valueSelector!));
    }
}

public class ToIDictionary_FromTupleSequence
{
    [Fact]
    public void CreatesDictionary_FromTupleSequence()
    {
        var collection = new[] { ("a", 1), ("b", 2) }.ToIDictionary(() => new Dictionary<string, int>());
        Assert.Equal(2, collection.Count);
    }
}

public class ToIDictionary_PersistsFactoryInstance
{
    [Fact]
    public void ReturnsFactoryFunctionResult()
    {
        var actualInstance = new Dictionary<string, int>();
        var collection = new[] {
            new KeyValuePair<string, int>("a", 1)
        }.ToIDictionary(() => actualInstance);
        Assert.Same(actualInstance, collection);
    }
}

public class ToIDictionary_NullChecks
{
    [Fact]
    public void ThrowsOnNullSource_WithTupleSource()
    {
        IEnumerable<(string, int)>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.ToIDictionary(() => new Dictionary<string, int>()));
    }

    [Fact]
    public void ThrowsOnNullSource_WithKeyValuePairSource()
    {
        IEnumerable<KeyValuePair<string, int>>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.ToIDictionary(() => new Dictionary<string, int>()));
    }

    [Fact]
    public void ThrowsOnNullFactory()
    {
        var source = new KeyValuePair<string, int>[] { new KeyValuePair<string, int>("a", 1) };
        Func<Dictionary<string, int>>? factory = null;
        Assert.Throws<ArgumentNullException>(() => source.ToIDictionary(factory!));
    }
}

[System.Runtime.InteropServices.ComVisible(false)]
public class CustomDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
{
    private readonly List<KeyValuePair<TKey, TValue>> _items = new();
    public int Count => _items.Count;
    public bool IsReadOnly => false;
    public void Add(KeyValuePair<TKey, TValue> item) => _items.Add(item);
    public void Clear() => _items.Clear();
    public bool Contains(KeyValuePair<TKey, TValue> item) => _items.Contains(item);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
    public bool Remove(KeyValuePair<TKey, TValue> item) => _items.Remove(item);
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _items.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _items.GetEnumerator();
}
