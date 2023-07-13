namespace Custom.Collections
{
    internal class Hashtable_Node<TKey, TValue>
    {
        public TKey Key;
        
        public TValue Value;

        public Hashtable_Node()
        {
        }

        public Hashtable_Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public class Hashtable<TKey, TValue>
    {
        private Hashtable_Node<TKey, TValue>[] m_array;

        private int m_size;

        public Hashtable()
        {
            m_array = new Hashtable_Node<TKey, TValue>[10];
        }

        public TValue this[TKey key]
        {
            get
            {
                var currentIndex = 0;
                var index = key.GetHashCode() % m_array.Length;
                while (currentIndex < m_array.Length)
                {
                    if (m_array[index] == null)
                    {
                        break;
                    }
                    if (m_array[index].Key.Equals(key))
                    {
                        return m_array[index].Value;
                    }
                    index = (index + 1) % m_array.Length;
                    currentIndex += 1;
                }
                throw new KeyNotFoundException(nameof(key));
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (m_size < m_array.Length)
            {
                var currentIndex = 0;
                var index = key.GetHashCode() % m_array.Length;
                while (currentIndex < m_array.Length)
                {
                    if (m_array[index] == null)
                    {
                        m_array[index] = new Hashtable_Node<TKey, TValue>(key, value);
                        m_size += 1;
                        return;
                    }
                    index = (index + 1) % m_array.Length;
                    currentIndex += 1;
                }
                throw new KeyNotFoundException(nameof(key));
            }
            else
            {
                Array.Resize(ref m_array, m_array.Length * 2);
                Add(key, value);
            }
        }

        public void Remove(TKey key)
        {
            if (m_size == 0) 
            {
                throw new KeyNotFoundException(nameof(key));
            }
            var currentIndex = 0;
            var index = key.GetHashCode() % m_array.Length;
            while (currentIndex < m_array.Length)
            {
                if (m_array[index] == null) 
                {
                    break;
                }
                if (m_array[index].Key.Equals(key)) 
                {
                    m_array[index] = null;
                    m_size -= 1;
                    return;
                }
                index = (index + 1) % m_array.Length;
                currentIndex += 1;
            }
            throw new KeyNotFoundException(nameof(key));
        }

        public bool Contains(TKey key)
        {
            var currentIndex = 0;
            var index = key.GetHashCode() % m_array.Length;
            while (currentIndex < m_array.Length)
            {
                if (m_array[index] == null)
                {
                    return false;
                }
                if (m_array[index].Key.Equals(key))
                {
                    return true;
                }
                index = (index + 1) % m_array.Length;
                currentIndex += 1;
            }
            return false;
        }
    }
}
