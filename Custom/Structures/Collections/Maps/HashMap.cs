namespace Custom.Structures.Collections.Maps
{
    public class HashMap<TKey, TValue>
    {
        public class KeyValuePair
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        private KeyValuePair[] items;
        private int count;

        public int Count { get { return count; } }

        public HashMap()
        {
            items = new KeyValuePair[10];
        }

        public bool Empty()
        {
            return count == 0;
        }

        public TValue GetItem(TKey key)
        {
            int index = key.GetHashCode() % items.Length;
            for (int counter = 0; counter < items.Length; index++, counter++)
            {
                if (items[index] == null)
                {
                    throw new KeyNotFoundException(nameof(key));
                }
                if (items[index].Key.Equals(key))
                {
                    return items[index].Value;
                }
            }
            throw new KeyNotFoundException(nameof(key));
        }

        public void SetItem(TKey key, TValue value)
        {
            int index = key.GetHashCode() % items.Length;
            for (int counter = 0; counter < items.Length; index++, counter++)
            {
                if (items[index] == null)
                {
                    throw new KeyNotFoundException(nameof(key));
                }
                if (items[index].Key.Equals(key))
                {
                    items[index].Value = value;
                }
            }
            throw new KeyNotFoundException(nameof(key));
        }

        public void Add(TKey key, TValue value)
        {
            if (count < items.Length)
            {
                int index = key.GetHashCode() % items.Length;
                for (int counter = 0; counter < items.Length; index++, counter++)
                {
                    if (items[index] == null)
                    {
                        items[index] = new KeyValuePair { Key = key, Value = value };
                        count++;
                        return;
                    }
                }
                throw new ArgumentOutOfRangeException(nameof(key));
            }
            else
            {
                KeyValuePair[] buffer = new KeyValuePair[items.Length];
                Array.Copy(items, buffer, items.Length);
                items = new KeyValuePair[items.Length * 2];
                foreach (KeyValuePair item in buffer)
                {
                    if (item != null)
                    {
                        Add(item.Key, item.Value);
                    }
                }
                Add(key, value);
            }
        }

        public void Remove(TKey key)
        {
            int index = key.GetHashCode() % items.Length;
            for (int counter = 0; counter < items.Length; index++, counter++)
            {
                if (items[index] == null)
                {
                    throw new KeyNotFoundException(nameof(key));
                }
                if (items[index].Key.Equals(key))
                {
                    items[index] = null;
                    count--;
                    return;
                }
            }
            throw new KeyNotFoundException(nameof(key));
        }

        public bool ContainsKey(TKey key)
        {
            int index = key.GetHashCode() % items.Length;
            for (int counter = 0; counter < items.Length; index++, counter++)
            {
                if (items[index] == null)
                {
                    return false;
                }
                if (items[index].Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        private void Rehash()
        {
            KeyValuePair[] buffer = new KeyValuePair[items.Length];
            Array.Copy(items, buffer, items.Length);
            items = new KeyValuePair[items.Length];
            foreach (KeyValuePair item in buffer)
            {
                if (item != null)
                {
                    Add(item.Key, item.Value);
                }
            }
        }
    }
}
