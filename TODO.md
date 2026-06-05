# TODO

## Startup

Create a new .NET 10 solution with project CollectionsSpecializedExtensions, and
a corresponding Test project.

Create extension classes for `HybridDictionary`, `ListDictionary`,
`NameValueCollection`, `OrderedDictionary`, `StringCollection`,
`StringDictionary`, where 

- each IDictionary class extension will have appropriate counterparts to
  Enumerable.ToDictionary such as ToHybridDictionary, ToListDictionary,
  ToOrderedDictionary, etc.
  - (see https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.todictionary?view=net-10.0) (for IDictionary classes)

- each IList class extension will have appropriate counterparts to Enumerable.ToList such as ToStringCollection
  - (see https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolist?view=net-10.0)

Create unit tests for each extension method.