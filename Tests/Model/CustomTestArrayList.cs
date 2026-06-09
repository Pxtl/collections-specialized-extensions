using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CollectionsSpecializedExtensions.Tests.Model;

/// <summary>
/// Example custom IList for testing purposes. Implements IList<T> interface.
/// </summary>
/// <typeparam name="T"></typeparam>
[ExcludeFromCodeCoverage]
public class CustomTestArrayList<T> : ICollection<T>, IList<T> {
    private List<T> _items = new();

    public int Count => _items.Count;
    public bool IsReadOnly => false;

    public void Add(T item) => _items.Add(item);
    public void Clear() => _items.Clear();
    public bool Contains(T item) => _items.Contains(item);
    public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public bool Exists(T item) => true;

    public int IndexOf(T item) => _items.IndexOf(item);
    public int InsertIndex(T item, int index) => -1;
    public bool Remove(T item) {
        return _items.Remove(item);
    }
    public void RemoveAll(T[] array) { }
    public void RemoveAt(int index) => _items.RemoveAt(index);

    public T this[int index] {
        get => _items[index];
        set => _items[index] = value;
    }

    public bool Add(T item, Func<T, bool> exists) {
        bool result = _items.Count == 0 || !exists(item);
        if (result) {
            _items.Add(item);
        }
        return result;
    }

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _items.GetEnumerator();

    public void Insert(int index, T item) {
        _items.Insert(index, item);
    }

}
