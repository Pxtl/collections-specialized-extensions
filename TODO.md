# TODO

## Enhance NameValueCollectionExtensions and OrderedDictionaryCollectionExtensions
- Add `.ToOrderedDictionary()` and `.ToNameValueCollection` overloads for
  IEqualityComparer parameters as seen in the Enumerable.ToOrderedDictionary
  methods.
- Add `.ToOrderedDictionary()` and `.ToNameValueCollection` overloads for
  `IEnumerable<ValueTuple<TKey, TValue>>` sources.
- More test coverage on NameValueCollectionExtensions and
  OrderedDictionaryCollectionExtensions

## Create more Extension classes for constructing full IDictionary and IList collections
These will require the full gamut of overloads for the extension method.

- In `ObservableCollectionExtensions`: `ToObservableCollection<T>`
- In `LinkedListExtensions`: `ToLinkedList<T>`

These 3 will need overloads that take `IComparer<T>` parameters:

- `ToSortedDictionary<TKey, TValue>`
- `ToSortedList<T>`
- `ToSortedSet<T>`

- each `IDictionary` class extension will have appropriate counterparts to
  Enumerable.ToDictionary such as ToSortedDictionary, etc.
  - (see https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.todictionary?view=net-10.0) (for IDictionary classes)

- each IList class extension will have appropriate counterparts to Enumerable.ToList such as ToSortedList, ToLinkedList, etc.
  - (see https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolist?view=net-10.0)

Create unit tests for each extension method.

## LambdaKeyedCollection
A new subclass of KeyCollection that takes a `keySelector` delegate as a
constructor parameter.  Create `ToKeyedCollection<TKey, TElement>` as another
extension method to construct this LambdaKeyedCollection.

## Create more Extensions classes for simple ObjectModel wrapper collections
These ones do not require the usual selectors and comparators since they're
simple wrappers.

- In `ReadOnlyObservableCollectionExtensions`: `ReadOnlyObservableCollection<T> AsReadOnly<T>(this ObservableCollection<T> source)`.