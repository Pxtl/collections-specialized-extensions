using CollectionsSpecializedExtensions.Tests.Model;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class ISetExtensionsTests {
    [Fact]
    public void ToISet_CreatesHashSet_WithAllUniqueElements() {
        var source = new List<int> { 1, 2, 3, 2, 1 };
        var result = source.ToISet(() => new HashSet<int>());

        result.Should().BeOfType<HashSet<int>>();
        result.Count.Should().Be(3);
        result.Should().Contain(1);
        result.Should().Contain(2);
        result.Should().Contain(3);
    }

    [Fact]
    public void ToISet_CreatesSortedSet_WithAllElements() {
        var source = new[] { "c", "a", "b" };
        var result = source.ToISet(() => new SortedSet<string>());

        result.Should().BeOfType<SortedSet<string>>();
        result.Count.Should().Be(3);
        result.Should().Contain("a");
        result.Should().Contain("b");
    }

    [Fact]
    public void ToISet_CreatesCustomTestSet_WithAllElements() {
        var source = new[] { "cat", "dog", "bird" };
        var result = source.ToISet(() => new CustomTestListSet<string>());

        result.Should().BeOfType<CustomTestListSet<string>>();
        result.Count.Should().Be(3);
    }

    [Fact]
    public void ToISet_WithFactory_FunctionsAsExpected() {
        var factoryCalled = false;
        var actualHashSet = new HashSet<int>();
        var source = new[] { 1, 2, 3 };

        var collection = source.ToISet(() => {
            factoryCalled = true;
            return actualHashSet;
        });

        factoryCalled.Should().BeTrue();
        collection.Should().BeSameAs(actualHashSet);
        collection.Count.Should().Be(3);
    }

    [Fact]
    public void ToISet_WithHashSet_Type_ReturnsSameInstance() {
        var actualHashSet = new HashSet<string> { "a", "b" };
        var source = new[] { "a", "b", "c" };
        var result = source.ToISet(() => actualHashSet);

        result.Should().BeOfType<HashSet<string>>();
        result.Should().BeSameAs(actualHashSet);
    }

    [Fact]
    public void ToISet_WithHashSetAndComparer_CreatesSet_WithUniqueElementsByComparer() {
        var source = new List<string> { "A", "a", "B", "b" };
        var result = source.ToISet(() => new HashSet<string>(StringComparer.OrdinalIgnoreCase));

        // Case-insensitive: A/a and B/b collapse to unique items
        result.Count.Should().Be(2);
    }

    [Fact]
    public void ToISet_NullSource_Throws() {
        Action act = () => ((IEnumerable<int>?)null!).ToISet(() => new HashSet<int>());
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToISet_NullFactory_Throws() {
        var source = new List<string>();
        Action act = () => source.ToISet((Func<HashSet<string>>?)null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToISet_EmptySource_CreatesEmptySet() {
        var source = Enumerable.Empty<int>();
        var result = source.ToISet(() => new HashSet<int>());

        result.Count.Should().Be(0);
        result.Should().BeOfType<HashSet<int>>();
    }
}
