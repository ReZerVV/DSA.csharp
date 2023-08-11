using System.Collections;

namespace Custom.Structures.Collections.Lists
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value, DoublyLinkedList<T>.Node next, DoublyLinkedList<T>.Node previous)
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

        public DoublyLinkedList()
        {
            front = null;
            back = null;
            length = 0;
        }

        public DoublyLinkedList(IEnumerable<T> values)
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

        public int Count()
        {
            int count = 0;
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next)
            {
                count += 1;
            }
            return count;
        }

        public void Add(T value)
        {
            if (Empty())
            {
                front = new Node(value, null, null);
                back = front;
                length += 1;
            }
            else
            {
                back.Next = new Node(value, null, back);
                back = back.Next;
                length += 1;
            }
        }

        public T Find(int index)
        {
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
                length -= 1;
                return;
            }
            if (index == Length - 1)
            {
                front = front.Next;
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
                front = new Node(value, front, null);
                length += 1;
                return;
            }
            if (index == Length - 1)
            {
                back = new Node(value, null, back);
                length += 1;
                return;
            }
            int currentIndex = 0;
            for (Node currentNode = front; !ReferenceEquals(currentNode, back.Next); currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index - 1)
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
