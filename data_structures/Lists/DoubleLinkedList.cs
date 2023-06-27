using System.Collections;

namespace data_structures.Lists
{
    public class DoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T>? Next { get; set; }
        public DoubleLinkedListNode<T>? Prev { get; set; }

        public DoubleLinkedListNode(T value, DoubleLinkedListNode<T>? prev = null, DoubleLinkedListNode<T>? next = null)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }
    }

    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        public DoubleLinkedListNode<T>? Front { get; private set; } = null;
        public DoubleLinkedListNode<T>? Back { get; private set; } = null;

        public DoubleLinkedList()
        {
            
        }

        public DoubleLinkedList(DoubleLinkedList<T> other)
        {
            Front = other.Front;
            Back = other.Back;
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
                DoubleLinkedListNode<T>? nodeList;
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
                DoubleLinkedListNode<T>? nodeList;
                for (nodeList = Front, indexList = 0; indexList != index; nodeList = nodeList.Next, indexList += 1) {}
                nodeList.Value = value;
            }
        }

        public void PushFront(T value)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value, null, Front);
            if (Front == null) 
            {
                Back = node;
            }
            Front = node;
            Length += 1;
        }

        public void PopFront()
        {
            Front = Front.Next;
            if (Front == null) 
            {
                Back = null;
            }
            Length -= 1;
        }

        public void PushBack(T value)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value, Back, null);
            if (Back == null) 
            {
                Front = node;
            }
            Back = node;
            Length += 1;
        }

        public void Insert(int index, T value)
        {
            if (0 > index || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            int indexList;
            DoubleLinkedListNode<T>? nodeList;
            for (nodeList = Front, indexList = 0; nodeList != null; nodeList = nodeList.Next, indexList += 1)
            {
                if (indexList == index)
                {
                    DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value, nodeList, nodeList.Next);
                    nodeList.Next = node;
                    node.Next.Prev = node;
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
            DoubleLinkedListNode<T>? nodeList;
            for (nodeList = Front, indexList = 0; nodeList != null; nodeList = nodeList.Next, indexList += 1)
            {
                if (indexList == index)
                {
                    nodeList.Next = nodeList.Next?.Next;
                    nodeList.Next.Prev = nodeList;
                    Length -= 1;
                    return;
                }
            }
        }

        public void Remove(T value)
        {
            DoubleLinkedListNode<T>? nodeList;
            for (nodeList = Front; nodeList != null; nodeList = nodeList.Next)
            {
                if (nodeList.Value.Equals(value))
                {
                    nodeList.Next = nodeList.Next?.Next;
                    nodeList.Next.Prev = nodeList;
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
            DoubleLinkedListNode<T> current = Front;
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