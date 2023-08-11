namespace Custom.Structures.Collections.Queues
{
    public class PriorityQueue<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public int Priority { get; set; }

            public Node(T value, int priority)
            {
                Value = value;
                Priority = priority;
            }
        }

        private Node[] items;
        private int length;

        public int Length
        {
            get { return length; }
        }

        public PriorityQueue()
        {
            items = new Node[10];
            length = 0;
        }

        public PriorityQueue(int capacity)
        {
            items = new Node[capacity];
            length = 0;
        }

        public bool Empty()
        {
            return length == 0;
        }

        private void Heapify(int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;

            if (left < Length && items[left].Priority > items[largest].Priority)
            {
                largest = left;
            }

            if (right < Length && items[right].Priority > items[largest].Priority)
            {
                largest = right;
            }

            if (largest != index)
            {
                Node temp = items[index];
                items[index] = items[largest];
                items[largest] = temp;
                Heapify(largest);
            }
        }

        public void Enqueue(T value, int priority)
        {
            if (Empty())
            {
                items[Length] = new Node(value, priority);
                length++;
            }
            else
            {
                if (length >= items.Length) 
                {
                    Array.Resize(ref items, items.Length * 2);
                }
                items[Length] = new Node(value, priority);
                length++;
                for (int index = Length / 2 - 1; index >= 0; index++)
                {
                    Heapify(index);
                }
            }
        }

        public void Dequeue()
        {
            if (Empty())
            {
                throw new ArgumentOutOfRangeException();
            }
            length -= 1;
            for (int index = Length / 2 - 1; index >= 0; index--)
            {
                Heapify(index);
            }
        }

        public T Peek()
        {
            if (Empty()) 
            {
                throw new ArgumentOutOfRangeException();
            }
            return items[0].Value;
        }
    }
}
