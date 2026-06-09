using CollectionsSpecializedExtensions.Tests.Model;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class IListExtensionsTests {
    [Fact]
    public void ToIList_CreatesList_WithAllElements() {
        var source = new List<int> { 1, 2, 3 };
        var result = source.ToIList(() => new CustomTestArrayList<int>());

        result.Should().BeOfType<CustomTestArrayList<int>>();
        result.Count.Should().Be(3);
        result[0].Should().Be(1);
        result[2].Should().Be(3);
    }

    [Fact]
    public void ToIList_WithListType_CreatesList_WithAllElements() {
        var source = new[] { "a", "b", "c" };
        var result = source.ToIList(() => new CustomTestArrayList<string>());

        result.Should().BeOfType<CustomTestArrayList<string>>();
        result.Count.Should().Be(3);
        result[0].Should().Be("a");
    }

    [Fact]
    public void ToIList_WithFactory_FunctionsAsExpected() {
        var factoryCalled = false;
        var actualInstance = new CustomTestArrayList<int>();
        var source = new[] { 1, 2 };
        var collection = source.ToIList(() => {
            factoryCalled = true;
            return actualInstance;
        });

        factoryCalled.Should().BeTrue();
        collection.Should().BeSameAs(actualInstance);
    }

    [Fact]
    public void ToIList_NullSource_Throws() {
        Action act = () => ((IEnumerable<int>?)null!).ToIList(() => new CustomTestArrayList<int>());
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToIList_NullFactory_Throws() {
        var source = new List<string>();
        Action act = () => source.ToIList((Func<CustomTestArrayList<string>>?)null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToIList_EmptySource_CreatesEmptyList() {
        var source = Enumerable.Empty<int>();
        var result = source.ToIList(() => new CustomTestArrayList<int>());

        result.Count.Should().Be(0);
        result.Should().BeOfType<CustomTestArrayList<int>>();
    }
}
