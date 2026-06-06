using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class OrderedDictExtensionsTests
{
    [Fact]
    public void ToOrderedDictionary_CreatesOrderedDictionary_WithAllElements()
    {
        var source = new List<int> { 1, 2, 3 };
        var result = source.ToOrderedDictionary(x => $"key{x}");
        
        result.Count.Should().Be(3);
        result["key1"].Should().Be(1);
        result["key2"].Should().Be(2);
        result["key3"].Should().Be(3);
    }

    [Fact]
    public void ToOrderedDictionary_NullSource_Throws()
    {
        IEnumerable<int>? source = null;
        Action act = () => source!.ToOrderedDictionary(x => $"key{x}");
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToOrderedDictionary_NullKeySelector_Throws()
    {
        var source = new List<int> { 1, 2, 3 };
        Func<int, string>? keySelector = null;
        Action act = () => source!.ToOrderedDictionary(keySelector!);
        act.Should().Throw<ArgumentNullException>();
    }
}
