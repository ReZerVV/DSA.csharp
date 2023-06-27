using System.Collections;

namespace data_structures.Lists
{
    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T>? Next { get; set; }
        public DoublyLinkedListNode<T>? Prev { get; set; }

        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T>? prev = null, DoublyLinkedListNode<T>? next = null)
        {
            Value = value;
            Prev = prev;
            Next = next;
        }
    }

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyLinkedListNode<T>? Front { get; private set; } = null;
        public DoublyLinkedListNode<T>? Back { get; private set; } = null;

        public DoublyLinkedList()
        {
            
        }

        public DoublyLinkedList(DoublyLinkedList<T> other)
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
                DoublyLinkedListNode<T>? nodeList;
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
                DoublyLinkedListNode<T>? nodeList;
                for (nodeList = Front, indexList = 0; indexList != index; nodeList = nodeList.Next, indexList += 1) {}
                nodeList.Value = value;
            }
        }

        public void PushFront(T value)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(value, null, Front);
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
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(value, Back, null);
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
            DoublyLinkedListNode<T>? nodeList;
            for (nodeList = Front, indexList = 0; nodeList != null; nodeList = nodeList.Next, indexList += 1)
            {
                if (indexList == index)
                {
                    DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(value, nodeList, nodeList.Next);
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
            DoublyLinkedListNode<T>? nodeList;
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
            DoublyLinkedListNode<T>? nodeList;
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
            DoublyLinkedListNode<T> current = Front;
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