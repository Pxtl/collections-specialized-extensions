# Plan

- Publish as nuget package. CollectionsSpecializedExtensions.

- Support System.Collections.ObjectModel, System.Collections.Specialized, System.Collections.Concurrent, System.ComponentModel collections.

- Support arbitrary IDictionary, ISet, IList colections. ICollectionWithAdd?
  Uses reflection but is a common .net idiom.  Some kind of constructor-piping?

  - `ToIDictionary<TDict, TKey, TValue> where TDict : new(), IDictionary<TKey,TValue>()`
  - `ToIList<TList, TItem> where TList : new(), IList<TItem>()`
  - `ToISet<TSet> : new(), TSet<TItem>()`

- For each one also allow a constructor lambda that returns an I* *without* the new();
- Also a pure I one that doesn't take the type parameter and just returns the raw interface, but still takes the `Func<T>`.