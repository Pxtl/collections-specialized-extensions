using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class OrderedDictionaryExtensionsTests
{
    [Fact]
    public void ToOrderedDictionary_WithKeyValuePair_WithCorrectOrdering()
    {
        var source = new List<KeyValuePair<string, int>>
        {
            KeyValuePair.Create("c", 1),
            KeyValuePair.Create("b", 2),
            KeyValuePair.Create("a", 3)
        };

        var actual = source.ToOrderedDictionary();
        
        actual.Keys.ElementAt(0).Should().Be("c");
        actual.Values.ElementAt(0).Should().Be(1);
    }

    [Fact]
    public void ToOrderedDictionary_WithKeyAndValueSelector_CreatesDictionaryWithCorrectOrdering()
    {
        var source = new List<(string key, int value)>
        {
            ("c", 1),
            ("b", 2),
            ("a", 3)
        };

        var result = source.ToOrderedDictionary(
            x => x.key,
            x => x.value
        );

        result.Count.Should().Be(3);
        result.Keys.ElementAt(0).Should().Be("c");
        result["c"].Should().Be(1);
    }

    [Fact]
    public void ToOrderedDictionary_ValueTupleSource_CreatesDictionary()
    {
        var source = new List<(string, int)>
        {
            ("x", 10),
            ("y", 20)
        };

        var result = source.ToOrderedDictionary();
        result.Count.Should().Be(2);
        result["x"].Should().Be(10);
        result["y"].Should().Be(20);
        var act = () => {
            //check for case sensitivity
            result["X"].Should().Be(10);

        };
        act.Should().Throw<KeyNotFoundException>();
    }

    [Fact]
    public void ToOrderedDictionary_ValueTupleSourceAndCaseInsensitiveComparer_ComparesInsensitively()
    {
        var source = new List<(string, int)>
        {
            ("x", 10),
            ("y", 20)
        };

        var result = source.ToOrderedDictionary(StringComparer.OrdinalIgnoreCase);
        result.Count.Should().Be(2);
        result["X"].Should().Be(10);
        result["Y"].Should().Be(20);
    }

    [Fact]
    public void ToOrderedDictionary_NullSource_Throws()
    {
        var source = (IEnumerable<(string, int)>?)null!;
        Action act = () => source.ToOrderedDictionary();
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToOrderedDictionary_NullValueInKeySelector_Throws()
    {
        var source = new List<(string, int)> { ("a", 1) };
        Action act = () => source.ToOrderedDictionary(x => (string)null!, x => x.Item2);
        act.Should().Throw<ArgumentNullException>();
    }
}
