namespace Custom.Structures.Collections.Maps
{
    public class HashMap<TKey, TValue>
    {
        public class KayValuePair
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        private Lists.LinkedList<KayValuePair> items;

        public HashMap()
        {
            items = new Lists.LinkedList<KayValuePair>();
        }

        public void Add(TKey key, TValue value)
        {
            items.Add(new KayValuePair { Key = key, Value = value });
        }
    }
}
