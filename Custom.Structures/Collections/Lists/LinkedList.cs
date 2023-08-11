using System.Collections;

namespace Custom.Structures.Collections.Lists
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value, Node next)
            {
                
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

        public LinkedList()
        {
            front = null;
            length = 0;
        }

        public LinkedList(IEnumerable<T> values)
            : this()
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public bool Empty()
        {
            return length == 0;
        }

        public int Count()
        {
            int count = 0;
            for (Node currentNode = front; currentNode != null; currentNode = currentNode.Next) 
            {
                count += 1;
            }
            return count;
        }

        public void Add(T value)
        {
            if (Empty())
            {
                front = new Node(value, null);
            }
            else
            {
                front.Next = new Node(value, null);
                length += 1;
            }
        }

        public T Find(int index)
        {
            int currentIndex = 0;
            for (Node currentNode = front; currentNode != null; currentNode = currentNode.Next, currentIndex++)
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
            for (Node currentNode = front; currentNode != null; currentNode = currentNode.Next, currentIndex++)
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
                front = front.Next;
                length -= 1;
                return;
            }
            int currentIndex = 0;
            for (Node currentNode = front.Next; currentNode != null; currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index - 1)
                {
                    currentNode.Next = currentNode.Next.Next;
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
                front = new Node(value, front);
                length += 1;
                return;
            }
            int currentIndex = 0;
            for (Node currentNode = front; currentNode != null; currentNode = currentNode.Next, currentIndex++)
            {
                if (currentIndex == index - 1)
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
            for (Node currentNode = front; currentNode != null; currentNode = currentNode.Next, currentIndex++)
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
            for (Node currentNode = front; currentNode != null; currentNode = currentNode.Next)
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
