namespace Custom.Structures.Collections.Queues
{
    public class Queue<T>
    {
        private Lists.LinkedList<T> items;

        public Queue()
        {
            items = new Lists.LinkedList<T>();
        }

        public Queue(IEnumerable<T> items)
            : this()
        {
            foreach (T item in items)
            {
                Enqueue(item);
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

        public void Enqueue(T value)
        {
            items.Add(value);
        }

        public T Dequeue()
        {
            if (Empty())
            {
                throw new ArgumentOutOfRangeException();
            }
            T value = items[0];
            items.RemoveAt(0);
            return value;
        }

        public T Peek()
        {
            if (Empty())
            {
                throw new ArgumentOutOfRangeException();
            }
            return items[0];
        }
    }
}
