using System.Collections;
using System.Collections.Generic;

namespace data_structures.Lists
{
    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T>? Next { get; set; }

        public LinkedListNode(T value, LinkedListNode<T>? next = null)
        {
            Value = value;
            Next = next;
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T>? Front { get; private set; } = null;

        public LinkedList()
        {
            
        }

        public LinkedList(LinkedList<T> other)
        {
            Front = other.Front;
            Length = other.Length;
        }

        public int Length { get; private set; } = 0;

        public T this[int index]
        {
            get
            {
                if (0 > index || index >= Length) 
                {
                    throw new IndexOutOfRangeException();
                }
                int indexList;
                LinkedListNode<T>? nodeList;
                for (nodeList = Front, indexList = 0; indexList != index; nodeList = nodeList.Next, indexList += 1) {}
                return nodeList.Value;
            }
            set
            {
                if (0 > index || index >= Length) 
                {
                    throw new IndexOutOfRangeException();
                }
                int indexList;
                LinkedListNode<T>? nodeList;
                for (nodeList = Front, indexList = 0; indexList != index; nodeList = nodeList.Next, indexList += 1) {}
                nodeList.Value = value;
            }
        }

        public void PushFront(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value, Front);
            Front = node;
            Length += 1;
        }

        public void PopFront()
        {
            Front = Front.Next;
            Length -= 1;
        }

        public void PushBack(T value)
        {
            if (Front == null) 
            {
                Front = new LinkedListNode<T>(value, null);
                Length += 1;
                return;
            }
            LinkedListNode<T>? node;
            for (node = Front; node.Next != null; node = node.Next) { }
            node.Next = new LinkedListNode<T>(value, null);
            Length += 1;
        }

        public void Insert(int index, T value)
        {
            if (0 > index || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            int indexList;
            LinkedListNode<T>? nodeList;
            for (nodeList = Front, indexList = 0; nodeList != null; nodeList = nodeList.Next, indexList += 1)
            {
                if (indexList == index)
                {
                    LinkedListNode<T> node = new LinkedListNode<T>(value, nodeList.Next);
                    nodeList.Next = node;
                    Length += 1;
                    return;
                }
            }
        }

        public void Remove(int index)
        {
            if (0 > index || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            int indexList;
            LinkedListNode<T>? nodeList;
            for (nodeList = Front, indexList = 0; nodeList != null; nodeList = nodeList.Next, indexList += 1)
            {
                if (indexList == index)
                {
                    nodeList.Next = nodeList.Next?.Next;
                    Length -= 1;
                    return;
                }
            }
        }

        public void Remove(T value)
        {
            LinkedListNode<T>? nodeList;
            for (nodeList = Front; nodeList != null; nodeList = nodeList.Next)
            {
                if (nodeList.Value.Equals(value))
                {
                    nodeList.Next = nodeList.Next?.Next;
                    Length -= 1;
                    return;
                }
            }
        }

        public bool Empty()
        {
            return Length == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Front;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
    }
}