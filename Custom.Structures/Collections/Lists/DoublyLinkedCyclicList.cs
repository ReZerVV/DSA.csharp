using System.Collections;

namespace Custom.Structures.Collections.Lists
{
    public class DoublyLinkedCyclicList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value, DoublyLinkedCyclicList<T>.Node next, DoublyLinkedCyclicList<T>.Node previous)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }

        private Node front;
        private Node back;
        private int length;

        public int Length { get => length; }

        public T this[int index]
        {
            get => Find(index);
            set => Set(index, value);
        }

        public DoublyLinkedCyclicList()
        {
            front = null;
            back = null;
            length = 0;
        }

        public DoublyLinkedCyclicList(IEnumerable<T> values)
            : this()
        {
            foreach (T value in values)
            {
                Add(value);
            }
        }

        public bool Empty()
        {
            return Length == 0;
        }

        public void Add(T value)
        {
            if (Empty())
            {
                front = new Node(value, null, null);
                back = front;
                front.Next = back;
                front.Previous = back;
                back.Next = front;
                back.Previous = front;
                length += 1;
            }
            else
            {
                back.Next = new Node(value, front, back);
                back = back.Next;
                front.Previous = back;
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
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next, currentIndex++)
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
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            int currentIndex = 0;
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next, currentIndex++)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentIndex;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        public void RemoveAt(int index)
        {
            if (Empty())
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            if (index == 0)
            {
                front = front.Next;
                front.Previous = back;
                back.Next = front;
                length -= 1;
                return;
            }
            if (index == Length - 1)
            {
                back = back.Previous;
                back.Next = front;
                front.Previous = back;
                length -= 1;
                return;
            }
            int currentIndex = 0;
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index)
                {
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
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
                front = new Node(value, front, back);
                front.Next.Previous = front;
                back.Next = front;
                length += 1;
                return;
            }
            if (index == Length - 1)
            {
                back = new Node(value, front, back);
                back.Previous.Next = back;
                front.Previous = back;
                length += 1;
                return;
            }
            int currentIndex = 0;
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index)
                {
                    currentNode.Next = new Node(value, currentNode.Next, currentNode);
                    currentNode.Next.Next.Previous = currentNode.Next;
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
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next, currentIndex++)
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
            back = null;
            length = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next)
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
