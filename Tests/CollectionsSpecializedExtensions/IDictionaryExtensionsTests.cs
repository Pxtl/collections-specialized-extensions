using System.Collections.Generic;
using System;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests.IDictionaryExtensionsTests;

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

    [Fact]
    public void ThrowsOnNullSource()
    {
        Assert.Throws<ArgumentNullException>(() =>
            ((IEnumerable<KeyValuePair<string, int>>?)null)
                .ToIDictionary(() => new Dictionary<string, int>()));
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
        var source = new[] {
            new { Key = "a", Value = 1 }
        };

        Assert.Throws<ArgumentNullException>(() =>
            source.ToIDictionary(
                () => new Dictionary<string, int>(),
                null!,
                x => x.Value));
    }

    [Fact]
    public void ThrowsOnNullValueSelector()
    {
        var source = new[] {
            new { Key = "a", Value = 1 }
        };

        Assert.Throws<ArgumentNullException>(() =>
            source.ToIDictionary(
                () => new Dictionary<string, int>(),
                x => x.Key,
                null!));
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

    [Fact]
    public void UsesFactoryFunction()
    {
        var collection = new[] { ("k1", "v1"), ("k2", "v2") }.ToIDictionary(() => new Dictionary<string, int>());
        Assert.Equal(2, collection.Count);
    }
}

public class ToIDictionary_PersistsFactoryInstance
{
    [Fact]
    public void ReturnsFactoryFunctionResult()
    {
        var actualInstance = new Dictionary<string, int>();
        Assert.Throws<ArgumentNullException>(() => new[] {
            new KeyValuePair<string, int>("a", 1)
        }.ToIDictionary(() => actualInstance));
    }
}

public class ToIDictionary_NullChecks
{
    [Fact]
    public void ThrowsOnNullSource_WithTupleSource()
    {
        Assert.Throws<ArgumentNullException>(() =>
            ((IEnumerable<(string, int)?>?)null).ToIDictionary(() => new Dictionary<string, int>()));
    }

    [Fact]
    public void ThrowsOnNullSource_WithKeyValuePairSource()
    {
        Assert.Throws<ArgumentNullException>(() =>
            ((IEnumerable<KeyValuePair<string, int>>?)null).ToIDictionary(() => new Dictionary<string, int>()));
    }

    [Fact]
    public void ThrowsOnNullFactory()
    {
        var source = new KeyValuePair<string, int>[] { new KeyValuePair<string, int>("a", 1) };
        Assert.Throws<ArgumentNullException>(() => source.ToIDictionary((Func<Dictionary<string, int>>)null));
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
