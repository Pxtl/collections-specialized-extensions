using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class NameValueCollectionExtensionsTests {
    [Fact]
    public void ToNameValueCollection_WithSelector_CreatesCollection() {
        var source = new List<(string key, int value)>
        {
            ("a", 1),
            ("b", 2)
        };

        var result = source.ToNameValueCollection(
            (x) => x.key,
            (x) => x.value.ToString()
        );

        result.Count.Should().Be(2);
        result["a"].Should().Be("1");
        result["b"].Should().Be("2");
    }

    [Fact]
    public void ToNameValueCollection_WithTupleSource_CreatesCollection() {
        var source = new List<(string, string)>
        {
            ("test1", "val1"),
            ("test2", "val2")
        };

        var result = source.ToNameValueCollection();
        result.Count.Should().Be(2);
        result["test1"].Should().Be("val1");
        result["test2"].Should().Be("val2");
    }

    [Fact]
    public void ToNameValueCollection_NullSource_Throws() {
        Action act = () => {
            var source = (IEnumerable<(string, string)>?)null!;
            source!.ToNameValueCollection();
        };

        act.Should().Throw<ArgumentNullException>();
    }
}
