using System.Collections;

namespace Custom.Structures.Collections.Lists
{
    public class LinkedCyclicList<T> : IEnumerable<T>
    {
        public class Node 
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        private Node front;
        private int length;

        public int Length { get => length; }

        public T this[int index]
        {
            get => Find(index);
            set => Set(index, value);
        }

        public LinkedCyclicList()
        {
            front = null;
            length = 0;
        }

        public LinkedCyclicList(IEnumerable<T> values)
            : this()
        {
            foreach (var value in values)
            {

            }
        }

        public bool Empty()
        {
            return length == 0;
        }

        public void Add(T value)
        {
            if (Empty())
            {
                front = new Node(value, null);
                front.Next = front;
            }
            else
            {
                Node newNode = new Node(value, front.Next);
                front.Next = newNode;
                length += 1;
            }
        }

        public T Find(int index)
        {
            if (Empty())
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            int currentIndex = 0;
            for (Node currentNode = front; currentIndex < Length; currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index)
                {
                    return currentNode.Value;
                }
            }
            throw new IndexOutOfRangeException(nameof(index));
        }

        public int IndexOf(T value)
        {
            if (Empty())
            {
                throw new KeyNotFoundException(nameof(value));
            }
            int currentIndex = 0;
            for (Node currentNode = front; currentIndex < Length; currentNode = currentNode.Next, currentIndex++)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentIndex;
                }
            }
            throw new KeyNotFoundException(nameof(value));
        }

        public void RemoveAt(int index)
        {
            if (Empty())
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            if (index == 0)
            {
                if (Length == 1)
                    front.Next = null;
                front = front.Next;
                return;
            }
            int currentIndex = 0;
            Node previousNode = front;
            for (Node currentNode = front.Next; currentIndex < Length; currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index)
                {
                    previousNode.Next = currentNode.Next;
                    length -= 1;
                    return;
                }
            }
            throw new IndexOutOfRangeException(nameof(index));
        }

        public void Remove(T value)
        {
            RemoveAt(IndexOf(value));
        }

        public void Insert(int index, T value)
        {
            if (Empty())
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            if (index == 0)
            {
                front = new Node(value, null);
                front.Next = front;
                return;
            }
            int currentIndex = 0;
            for (Node currentNode = front; currentIndex < Length; currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index)
                {
                    currentNode.Next = new Node(value, currentNode.Next);
                    length += 1;
                    return;
                }
            }
            throw new IndexOutOfRangeException(nameof(index));
        }

        public void Set(int index, T value)
        {
            if (Empty())
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            int currentIndex = 0;
            for (Node currentNode = front; currentIndex < Length; currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index)
                {
                    currentNode.Value = value;
                    return;
                }
            }
            throw new IndexOutOfRangeException(nameof(index));
        }

        public void Clear()
        {
            front = null;
            length = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentIndex = 0;
            for (Node currentNode = front; currentIndex < Length && front != null; currentNode = currentNode.Next, currentIndex++)
            {
                yield return currentNode.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
