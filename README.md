# Collections.Specialized.Extensions

Specialized collection extension methods for .NET 10.

## Installation

```bash
dotnet add package Collections.Specialized.Extensions
```

## Features

- **IDictionaryExtensions** - Convert any collection to any class implementing IDictionary with ToIDictionary
- **IListExtensions** - Convert any collection to any class implementing IList with ToIList
- **ISetExtensions** - Convert any collection to any class implementing ISet with ISet
- **KeyedCollectionExtensions** - Convert any collection to KeyedCollection with ToKeyedCollection
- **LinkedListExtensionsExtensions** - Convert any collection to LinkedList with ToLinkedList
- **NameValueCollectionExtensions** - Convert any collection to NameValueCollection with ToNameValueCollection
- **ObservableCollectionExtensions** - Convert any collection to ObservableCollection with ToObservableCollection
- **OrderedDictionaryExtensions** - Convert any collection to OrderedDictionary with ToOrderedDictionary
- **SortedDictionaryExtensions** - Convert any collection to SortedDictionary with ToSortedDictionary
- **SortedListExtensions** - Convert any collection to SortedList with ToSortedList
- **SortedSetExtensions** - Convert any collection to SortedSet with ToSortedSet

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
var sorted2 = items.ToSortedList(item => item.Key, item => item.Value);
var sorted3 = items.ToSortedSet();
```

## License

MIT License - See [LICENSE](LICENSE)
