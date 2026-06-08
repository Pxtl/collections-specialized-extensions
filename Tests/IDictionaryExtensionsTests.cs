using CollectionsSpecializedExtensions.Tests.Model;
namespace CollectionsSpecializedExtensions.Tests;

public class IDictionaryExtensionsTests
{
    [Fact]
    public void CreatesDictionary_FromKeyValuePair()
    {
        var collection = new[] {
            new KeyValuePair<string, int>("a", 1),
            new KeyValuePair<string, int>("b", 2)
        }.ToIDictionary(() => new CustomTestListDictionary<string, int>());

        Assert.IsType<CustomTestListDictionary<string, int>>(collection);
        Assert.Equal(2, collection.Count);
        Assert.Equal(1, collection["a"]);
    }

    [Fact]
    public void CreatesDictionary_FromTupleSequence()
    {
        var collection = new[] { ("a", 1), ("b", 2) }.ToIDictionary(() => new CustomTestListDictionary<string, int>());
        Assert.IsType<CustomTestListDictionary<string, int>>(collection);
        Assert.Equal(2, collection.Count);
    }

    [Fact]
    public void ReturnsFactoryFunctionResult()
    {
        var actualInstance = new CustomTestListDictionary<string, int>();
        var collection = new[] {
            new KeyValuePair<string, int>("a", 1)
        }.ToIDictionary(() => actualInstance);

        Assert.IsType<CustomTestListDictionary<string, int>>(collection);
        Assert.Same(actualInstance, collection);
    }

    [Fact]
    public void CreatesDictionary_WithObjectGraph()
    {
        var collection = new[] {
            new { Name = "Alice", Score = 100 },
            new { Name = "Bob", Score = 200 }
        }.ToIDictionary(
            () => new CustomTestListDictionary<string, int>(),
            x => x.Name,
            x => x.Score);

        Assert.IsType<CustomTestListDictionary<string, int>>(collection);
        Assert.Equal(2, collection.Count);
        Assert.Equal(100, collection["Alice"]);
    }

    [Fact]
    public void ThrowsOnNullSource_WithTupleSource()
    {
        IEnumerable<(string, int)>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.ToIDictionary(() => new CustomTestListDictionary<string, int>()));
    }

    [Fact]
    public void ThrowsOnNullSource_WithKeyValuePairSource()
    {
        IEnumerable<KeyValuePair<string, int>>? source = null;
        Assert.Throws<ArgumentNullException>(() => source!.ToIDictionary(() => new CustomTestListDictionary<string, int>()));
    }

    [Fact]
    public void ThrowsOnNullFactory()
    {
        var source = new KeyValuePair<string, int>[] { new KeyValuePair<string, int>("a", 1) };
        Func<CustomTestListDictionary<string, int>>? factory = null;
        Assert.Throws<ArgumentNullException>(() => source.ToIDictionary(factory!));
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
                () => new CustomTestListDictionary<string, int>(),
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
                () => new CustomTestListDictionary<string, int>(),
                x => x.Key,
                valueSelector!));
    }
}

