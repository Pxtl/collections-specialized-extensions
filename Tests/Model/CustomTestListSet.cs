using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CollectionsSpecializedExtensions.Tests.Model;

/// <summary>
/// Example custom ISet for testing purposes. Implements ISet<T> interface.
/// </summary>
/// <typeparam name="T"></typeparam>
[ExcludeFromCodeCoverage]
public class CustomTestListSet<T> : ICollection<T>, ISet<T> {
    private List<T> _items = new();

    #region CRUD operations
    public int Count => _items.Count;
    public bool IsReadOnly => false;
    public bool Contains(T item) => _items.Contains(item);
    public void Clear() => _items.Clear();
    public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public bool Equals(T? other, T? item) => Equals(item, other);
    public bool Exists(T item) => _items.Contains(item);
    public bool Remove(T item, Action<T> removed) => _items.Remove(item);
    public bool IsEmpty => _items.Count == 0;
    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

    public bool Add(T item) {
        if (_items.Contains(item)) {
            return false;
        } else {
            _items.Add(item);
            return true;
        }
    }

    void ICollection<T>.Add(T item) {
        _ = Add(item);
    }

    public bool Remove(T item) => _items.Remove(item);
    #endregion

    #region set theory predicates
    public bool IsProperSubsetOf(IEnumerable<T> other)
        => new HashSet<T>(_items).IsProperSubsetOf(other);
    public bool IsProperSupersetOf(IEnumerable<T> other)
        => new HashSet<T>(_items).IsProperSupersetOf(other);
    public bool IsSubsetOf(IEnumerable<T> other)
        => new HashSet<T>(_items).IsSubsetOf(other);
    public bool IsSupersetOf(IEnumerable<T> other)
        => new HashSet<T>(_items).IsSupersetOf(other);
    public bool Overlaps(IEnumerable<T> other)
        => new HashSet<T>(_items).Overlaps(other);
    public bool SetEquals(IEnumerable<T> other)
        => new HashSet<T>(_items).SetEquals(other);
    public void ExceptWith(IEnumerable<T> other)
        => new HashSet<T>(_items).ExceptWith(other);
    # endregion set theory predicates

    #region set theory mutations
    public void IntersectWith(IEnumerable<T> other) {
        var exceptedItems = this.Except(other);
        foreach (var item in exceptedItems) {
            Remove(item);
        }
    }

    public void SymmetricExceptWith(IEnumerable<T> other) {
        var intersection = this.Intersect(other);
        foreach (var item in intersection) {
            Remove(item);
        }
    }

    public void UnionWith(IEnumerable<T> other) {
        foreach (var item in other) {
            Add(item);
        }
    }
    #endregion
}
