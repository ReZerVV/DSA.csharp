namespace Custom.Structures.Collections.Deques
{
    public class Deque<T>
    {
        private Lists.LinkedList<T> items;

        public Deque()
        {
            this.items = new Lists.LinkedList<T>();
        }

        public Deque(IEnumerable<T> items)
            : this()
        {
            foreach (var item in items)
            {
                this.items.Add(item);
            }
        }

        public bool Empty()
        {
            return items.Empty();
        }

        public void Clear()
        {
            items.Clear();
        }

        public void PushBack(T value)
        {
            items.Add(value);
        }

        public void PushFront(T value)
        {
            items.Insert(0, value);
        }

        public T PopBack()
        {
            if (Empty())
            {
                throw new ArgumentOutOfRangeException();
            }
            T value = items[items.Length - 1];
            items.RemoveAt(items.Length - 1);
            return value;
        }

        public T PopFront()
        {
            if (Empty())
            {
                throw new ArgumentOutOfRangeException();
            }
            T value = items[0];
            items.RemoveAt(0);
            return value;
        }
    }
}
