using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class OrderedDictionaryExtensionsTests
{
    [Fact]
    public void ToOrderedDictionary_ReturnsDictionary_WithCorrectOrdering()
    {
        // source data has keys in descending order, values in ascending order.  Ordered dictionary should persist that.
        var source = new List<(string key, int value)>
        {
            ("c", 1),
            ("b", 2),
            ("a", 3)
        };

        var actual = source.ToOrderedDictionary(
            x => x.Item1,
            x => x.Item2
        );
                
        actual.Keys.Should().BeInDescendingOrder();
        actual.Values.Should().BeInAscendingOrder();
    }

    [Fact]
    public void ToOrderedDictionary_NullSource_Throws()
    {
        Action act = () => {
            var source = (IEnumerable<(string, int)>? ) null;
            source!.ToOrderedDictionary(
                x => x.Item1,
                x => x.Item2!
            );
        };
        
        act.Should().Throw<ArgumentNullException>();
    }
}
