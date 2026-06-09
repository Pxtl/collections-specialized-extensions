using CollectionsSpecializedExtensions.Tests.Model;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class IDictionaryExtensionsTests {
    [Fact]
    public void ToIDictionary_CreatesDictionary_FromKeyValuePair() {
        var collection = new[] {
            new KeyValuePair<string, int>("a", 1),
            new KeyValuePair<string, int>("b", 2)
        }.ToIDictionary(() => new CustomTestListDictionary<string, int>());

        collection.Should().BeOfType<CustomTestListDictionary<string, int>>();
        collection.Count.Should().Be(2);
        collection["a"].Should().Be(1);
    }

    [Fact]
    public void ToIDictionary_CreatesDictionary_FromTupleSequence() {
        var collection = new[] { ("a", 1), ("b", 2) }.ToIDictionary(() => new CustomTestListDictionary<string, int>());

        collection.Should().BeOfType<CustomTestListDictionary<string, int>>();
        collection.Count.Should().Be(2);
    }

    [Fact]
    public void ToIDictionary_ReturnsFactoryFunctionResult() {
        var actualInstance = new CustomTestListDictionary<string, int>();
        var collection = new[] {
            new KeyValuePair<string, int>("a", 1)
        }.ToIDictionary(() => actualInstance);

        collection.Should().BeOfType<CustomTestListDictionary<string, int>>();
        collection.Should().BeSameAs(actualInstance);
    }

    [Fact]
    public void ToIDictionary_CreatesDictionary_WithObjectGraph() {
        var collection = new[] {
            new { Name = "Alice", Score = 100 },
            new { Name = "Bob", Score = 200 }
        }.ToIDictionary(
            () => new CustomTestListDictionary<string, int>(),
            x => x.Name,
            x => x.Score);

        collection.Should().BeOfType<CustomTestListDictionary<string, int>>();
        collection.Count.Should().Be(2);
        collection["Alice"].Should().Be(100);
    }

    [Fact]
    public void ToIDictionary_ThrowsOnNullSource_WithTupleSource() {
        IEnumerable<(string, int)>? source = null;
        Action act = () => source!.ToIDictionary(() => new CustomTestListDictionary<string, int>());
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToIDictionary_ThrowsOnNullSource_WithKeyValuePairSource() {
        IEnumerable<KeyValuePair<string, int>>? source = null;
        Action act = () => source!.ToIDictionary(() => new CustomTestListDictionary<string, int>());
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToIDictionary_ThrowsOnNullFactory() {
        var source = new KeyValuePair<string, int>[] { new KeyValuePair<string, int>("a", 1) };
        Action act = () => source.ToIDictionary((Func<CustomTestListDictionary<string, int>>?)null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToIDictionary_ThrowsOnNullKeySelector() {
        var source = new[] {
            new KeyValuePair<string, int>("a", 1)
        };

        Func<KeyValuePair<string, int>, string>? keySelector = null;
        Action act = () =>
            source.ToIDictionary(
                () => new CustomTestListDictionary<string, int>(),
                keySelector!,
                x => x.Value);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToIDictionary_ThrowsOnNullValueSelector() {
        var source = new[] {
            new KeyValuePair<string, int>("a", 1)
        };

        Func<KeyValuePair<string, int>, int>? valueSelector = null;
        Action act = () =>
            source.ToIDictionary(
                () => new CustomTestListDictionary<string, int>(),
                x => x.Key,
                valueSelector!);

        act.Should().Throw<ArgumentNullException>();
    }
}
