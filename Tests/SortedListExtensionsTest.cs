using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class SortedListExtensionsTests
{
    [Fact]
    public void ToSortedList_WithDictionarySource_CreatesSortedCollection_WithAllElements()
    {
        var source = new List<KeyValuePair<string, int>> {
            new("c", 3),
            new("a", 1),
            new("b", 2),
            new("d", 4)
        };
        var result = source.ToSortedList();
        
        result.Count.Should().Be(4);
        result["a"].Should().Be(1);
        result["b"].Should().Be(2);
        result["c"].Should().Be(3);
        result["d"].Should().Be(4);
    }

    [Fact]
    public void ToSortedList_NullSource_Throws()
    {
        IEnumerable<KeyValuePair<string, int>>? source = null;
        Action act = () => source!.ToSortedList();
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToSortedList_NullComparer_Throws()
    {
        var source = new List<KeyValuePair<string, int>> {
            new("c", 3),
            new("a", 1),
            new("b", 2)
        };
        Action act = () => source!.ToSortedList((IComparer<string>)null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToSortedList_WithKeyAndValueSelectors_CreatesSortedCollection_WithMappedElements()
    {
        var source = new List<(int Id, string Name, int Value)> {
            new(3, "c", 30),
            new(1, "a", 10),
            new(2, "b", 20),
            new(4, "d", 40)
        };
        var result = source.ToSortedList(
            x => x.Name,
            x => x.Value
        );
        
        result.Count.Should().Be(4);
        result["a"].Should().Be(10);
        result["b"].Should().Be(20);
        result["c"].Should().Be(30);
        result["d"].Should().Be(40);
    }

    [Fact]
    public void ToSortedList_WithKeyAndValueSelectorsAndComparer_CreatesSortedCollection_WithMappedElements()
    {
        var source = new List<(int Id, string Name)> {
            new(3, "d"),
            new(1, "a"),
            new(2, "b"),
            new(4, "c")
        };
        IComparer<string> comparer = StringComparer.Ordinal;
        var result = source.ToSortedList(
            x => x.Name,
            x => x.Id,
            comparer
        );
        
        result.Count.Should().Be(4);
        result["a"].Should().Be(1);
        result["b"].Should().Be(2);
        result["c"].Should().Be(4);
        result["d"].Should().Be(3);
    }
}
