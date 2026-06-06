using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class SortedSetExtensionsTests
{
    [Fact]
    public void ToSortedSet_CreatesSet_WithAllElements()
    {
        var source = new List<int> { 1, 2, 3, 2, 1 };
        var result = source.ToSortedSet();
        
        result.Count.Should().Be(3);
        result.Contains(1).Should().BeTrue();
        result.Contains(2).Should().BeTrue();
        result.Contains(3).Should().BeTrue();
    }

    [Fact]
    public void ToSortedSet_NullSource_Throws()
    {
        IEnumerable<int>? source = null;
        Action act = () => source!.ToSortedSet();
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToSortedSet_WithCustomComparer_CreatesSet_WithAllUniqueElements()
    {
        var source = new List<string> { "c", "a", "b", "ca", "C" };
        var result = source.ToSortedSet();
        
        result.Count.Should().Be(5); // Case-sensitive by default
        result.Contains("C").Should().BeTrue();
        result.Contains("c").Should().BeTrue();
    }

    [Fact]
    public void ToSortedSet_NullComparer_Throws()
    {
        var source = new List<string> { "c", "a", "b" };
        Action act = () => source.ToSortedSet((IComparer<string>)null!);
        act.Should().Throw<ArgumentNullException>();
    }
}
