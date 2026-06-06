# TODO

## DONE

### Create Sorted Extension Methods

These 3 have overloads that take `IComparer<T>` parameters:

- `ToSortedDictionary<TKey, TValue>` ✓
- `ToSortedList<TKey, TValue>` ✓
- `ToSortedSet<T>` ✓

### LambdaKeyedCollection

New subclass of KeyedCollection that takes a `keySelector` delegate as a
constructor parameter. Created class `KeyedCollectionExtensions` method
`ToKeyedCollection<TKey, TElement>` as another extension method to construct
this LambdaKeyedCollection. ✓

### Test Coverage

Created unit tests for each extension method using FluentAssertions. ✓

## Done

All sorted collection extension methods complete:
- ToSortedDictionary<TKey, TValue> with IComparer<T> overloads
- ToSortedList<TKey, TValue> with IComparer<T> overloads  
- ToSortedSet<T> with IComparer<T> overloads
- ToKeyedCollection<TKey, TElement>

All unit tests passing (24 tests).