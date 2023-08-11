using System.Collections;

namespace Custom.Structures.Collections.Arrays
{
    public class Array<T> : ICollection<T>
    {
        private T[] items;
        private int count;

        public int Count => count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => GetItem(index);
            set => SetItem(index, value);
        }

        public Array()
        {
            items = new T[10];
        }

        public T GetItem(int index)
        {
            return items[index];
        }

        public void SetItem(int index, T item)
        {
            items[index] = item;
        }

        public bool Empty()
        {
            return count == 0;
        }

        public void Add(T item)
        {
            if (count < items.Length)
            {
                items[Count - 1] = item;
                count += 1;
            }
            else
            {
                Array.Resize(ref items, items.Length * 2);
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            for (int index = 0; index < Count; index++)
            {
                if (items[index].Equals(item))
                {
                    if (index < Count - 1)
                    {
                        for (int i = index; i < Count - 1; i++)
                        {
                            items[i] = items[i + 1];
                        }
                    }
                    count -= 1;
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            Array.Clear(items);
            count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T element in items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < Count; index++)
            {
                yield return items[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
