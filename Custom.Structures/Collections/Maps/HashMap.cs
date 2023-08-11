namespace Custom.Structures.Collections.Maps
{
    public class HashMap<TKey, TValue>
    {
        public class KayValuePair
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        private Arrays.Array<KayValuePair> items;
        private int count;

        public HashMap()
        {
            items = new Arrays.Array<KayValuePair>();
        }

        public bool Empty()
        {
            return items.Empty();
        }

        public TValue GetItem(TKey key)
        {
            int index = key.GetHashCode() % items.Count;
            for (int counter = 0; counter < items.Count; index++, counter++) 
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
            int index = key.GetHashCode() % items.Count;
            for (int counter = 0; counter < items.Count; index++, counter++)
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
            
        }
    }
}
