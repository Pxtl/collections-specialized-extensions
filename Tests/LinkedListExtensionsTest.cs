using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class LinkedListExtensionsTests
{
    [Fact]
    public void ToLinkedList_CreatesList_WithAllElements()
    {
        var source = new List<int> { 1, 2, 3 };
        var result = source.ToLinkedList();
        
        result.Count.Should().Be(3);
        result.Contains(1).Should().BeTrue();
        result.Contains(3).Should().BeTrue();
    }

    [Fact]
    public void ToLinkedList_NullSource_Throws()
    {
        var source = (IEnumerable<int>?)null!;
        Action act = () => source!.ToLinkedList();
        act.Should().Throw<ArgumentNullException>();
    }
}
