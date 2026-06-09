using System.Diagnostics.CodeAnalysis;

namespace CollectionsSpecializedExtensions.Tests.Model;

/// <summary>
/// Example custom IDictionary for testing purposes
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
[System.Runtime.InteropServices.ComVisible(false)]
public class CustomTestListDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue> {
    private readonly List<KeyValuePair<TKey, TValue>> _items = new();
    public int Count => _items.Count;
    public bool IsReadOnly => false;

    public ICollection<TKey> Keys => _items.Select(p => p.Key).ToList().AsReadOnly();

    public ICollection<TValue> Values => _items.Select(p => p.Value).ToList().AsReadOnly();

    public TValue this[TKey key] {
        get => _items.Single(p => Equals(p.Key, key)).Value;
        set {
            Remove(key);
            _items.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    }

    public void Add(KeyValuePair<TKey, TValue> item) => _items.Add(item);
    public void Clear() => _items.Clear();
    public bool Contains(KeyValuePair<TKey, TValue> item) => _items.Contains(item);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
    public bool Remove(KeyValuePair<TKey, TValue> item) => _items.Remove(item);
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _items.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _items.GetEnumerator();

    public void Add(TKey key, TValue value) {
        if (ContainsKey(key)) {
            throw new ArgumentException("Key already exists", nameof(key));
        } else {
            _items.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    }

    public bool ContainsKey(TKey key) => _items.Any(p => Equals(p.Key, key));

    public bool Remove(TKey key) {
        if (ContainsKey(key)) {
            _items.RemoveAll(p => Equals(p.Key, key));
            return true;
        } else {
            return false;
        }
    }

    public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) {
        if (ContainsKey(key)) {
            value = this[key];
            return true;
        } else {
            value = default;
            return false;
        }
    }
}
