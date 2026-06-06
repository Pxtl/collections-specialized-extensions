# Collections.Specialized.Extensions

Specialized collection extension methods for .NET 10.

[![NuGet](https://img.shields.io/nuget/v/Collections.Specialized.Extensions.svg)](https://www.nuget.org/packages/Collections.Specialized.Extensions)

## Installation

```bash
dotnet add package Collections.Specialized.Extensions
```

## Features

- **NameValueCollectionExtensions** - Convert any collection to a NameValueCollection
- **ToStringExtensions** - Add convenient ToString() overloads for specialized collections
- **ToOrderedDictionaryExtensions** - Create ordered dictionaries from various source types
- **ToSortedDictionaryExtensions** - Sort collections by key or value
- **ToSortedListExtensions** - Sort collections in various ways
- **ToSortedSetExtensions** - Sort collections into a SortedSet
- **ToKeyedCollectionExtensions** - Create keyed collections from any collection

## Usage

### NameValueCollection

```csharp
var collection = new[] { 
    new { Key = "id", Value = "name" },
    new { Key = "age", Value = "25" }
}.ToNameValueCollection(item => item.Key, item => item.Value);
```

### Sorted Collections

```csharp
var sorted = items.ToSortedDictionary(item => item.Key, item => item.Value);
var sorted2 = items.ToSortedList<T>(item => item.Score);
var sorted3 = items.ToSortedSet(item => item.SortKey);
```

## License

MIT License - See [LICENSE](../LICENSE)
