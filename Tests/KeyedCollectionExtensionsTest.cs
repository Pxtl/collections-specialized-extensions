using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CollectionsSpecializedExtensions.Tests;

public class KeyedCollectionExtensionsTests
{
    [Fact]
    public void ToKeyedCollection_CreatesCollection_WithAllElements()
    {
        var source = new List<Person> {
            new() { Name = "Charlie", Age = 30 },
            new() { Name = "Alice", Age = 25 },
            new() { Name = "Bob", Age = 35 }
        };
        var result = source.ToKeyedCollection(p => p.Name);
        
        result.Count.Should().Be(3);
        result["Charlie"].Name.Should().Be("Charlie");
        result["Alice"].Name.Should().Be("Alice");
        result["Bob"].Name.Should().Be("Bob");
    }

    [Fact]
    public void ToKeyedCollection_NullSource_Throws()
    {
        IEnumerable<Person>? source = null;
        Action act = () => source!.ToKeyedCollection(p => p.Name);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToKeyedCollection_NullKeySelector_Throws()
    {
        var source = new List<Person> { new() { Name = "Charlie" } };
        Action act = () => source!.ToKeyedCollection((Func<Person, string>)null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ToKeyedCollection_WithComparer_CreatesCollection_WithAllElements()
    {
        var source = new List<Person> {
            new() { Name = "Charlie", Age = 30 },
            new() { Name = "Alice", Age = 25 },
            new() { Name = "Bob", Age = 35 }
        };
        IEqualityComparer<string> comparer = new CaseInsensitiveStringComparer();
        var result = source.ToKeyedCollection(p => p.Name, comparer);
        
        result.Count.Should().Be(3);
        result["Charlie"].Name.Should().Be("Charlie");
    }

    [Fact]
    public void ToKeyedCollection_NullComparer_Throws()
    {
        var source = new List<Person> { new() { Name = "Charlie" } };
        Action act = () => source!.ToKeyedCollection(p => p.Name, (IEqualityComparer<string>)null!);
        act.Should().Throw<ArgumentNullException>();
    }
}

public class Person
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}

public class CaseInsensitiveStringComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
    public int GetHashCode(string obj) => StringComparer.OrdinalIgnoreCase.GetHashCode(obj);
}
