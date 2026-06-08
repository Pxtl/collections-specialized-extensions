# TODO

- Support arbitrary IDictionary, ISet, IList colections.

  - `ToIDictionary<TDictionary, TKey, TValue> where TDict : new(), IDictionary<TKey,TValue>()`
  - `ToIList<TList, TItem> where TList : new(), IList<TItem>()`
  - `ToISet<TSet> : new(), TSet<TItem>()`

- For each one also allow a factory lambda that returns an I* *without* the new() where-clause;
- Full unit tests for all 3 classes IDictionaryExtensions, IListExtensions, ISetExtensions.