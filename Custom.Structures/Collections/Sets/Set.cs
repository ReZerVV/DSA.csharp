using System.Collections;

namespace Custom.Structures.Collections.Sets
{
    public class Set<T> : IEnumerable<T>
    {
        private Lists.LinkedList<T> items;

        public T this[int index]
        {
            get => items[index];
            set => SetValue(index, value);
        }

        public Set()
        {
            items = new Lists.LinkedList<T>();
        }

        public Set(IEnumerable<T> items)
            : this()
        { 
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public void SetValue(int index, T value)
        {
            if (!Contains(value))
            {
                items[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public void Remove(T value)
        {
            items.Remove(value);
        }

        public void Add(T value)
        {
            if (!Contains(value))
            {
                items.Add(value);
            }
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(T value)
        {
            return items.Contains(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
