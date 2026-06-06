using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class ObservableCollectionExtensionsTests
{
    [Fact]
    public void ToObservableCollection_CreatesCollection_WithAllElements()
    {
        var source = new List<int> { 1, 2, 3 };
        var result = source.ToObservableCollection();
        
        result.Count.Should().Be(3);
        result[0].Should().Be(1);
        result[1].Should().Be(2);
        result[2].Should().Be(3);
    }

    [Fact]
    public void ToObservableCollection_NullSource_Throws()
    {
        var source = (IEnumerable<int>?)null!;
        Action act = () => source!.ToObservableCollection();
        act.Should().Throw<ArgumentNullException>();
    }
}
