namespace Custom.Structures.Collections.Maps
{
    public class Map<TKey, TValue>
    {
        public class KayValuePair
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        private Lists.LinkedList<KayValuePair> items;

        public int Length
        {
            get
            {
                return items.Length;
            }
        }

        public TValue this[TKey key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        public Map()
        {
            items = new Lists.LinkedList<KayValuePair>();
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Empty()
        {
            return items.Empty();
        }

        public void Add(TKey key, TValue value)
        {
            items.Add(new KayValuePair { Key = key, Value = value });
        }

        public TValue GetValue(TKey key)
        {
            foreach (Map<TKey, TValue>.KayValuePair item in items)
            {
                if (key.Equals(item.Key))
                {
                    return item.Value;
                }
            }
            throw new KeyNotFoundException(nameof(key));
        }

        public void SetValue(TKey key, TValue value)
        {
            foreach (Map<TKey, TValue>.KayValuePair item in items)
            {
                if (key.Equals(item.Key))
                {
                    item.Value = value;
                }
            }
            throw new KeyNotFoundException(nameof(key));
        }
    }
}
