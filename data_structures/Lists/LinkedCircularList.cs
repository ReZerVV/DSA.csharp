using System.Collections;

namespace data_structures.Lists
{
    class LinkedCircularList<T> : IList<T>
    {
        public int Length { get; private set; }

        private LinkedListNode<T> _first;

        private LinkedListNode<T> _end => FindEnd();

        private LinkedListNode<T> FindNodeByIndex(int index)
        {
            if (_first == null)
            {
                throw new KeyNotFoundException();
            }
            if (Math.Abs(index) >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index < 0)
            {
                index = Length - index;
            }
            uint currentIndex = 0;
            LinkedListNode<T> currentNode = _first;
            while (currentIndex != index)
            {
                currentIndex += 1;
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        private LinkedListNode<T> FindEnd()
        {
            if (First == null)
            {
                throw new KeyNotFoundException();
            }
            LinkedListNode<T> currentNode = First;
            while (ReferenceEquals(First, currentNode.Next))
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        public LinkedCircularList()
        {
            First = null;
            Length = 0;
        }

        public LinkedCircularList(LinkedCircularList<T> other)
        {
            First = other.First;
            Length = other.Length;
        }

        public T this[int index]
        {
            get
            {
                return FindNodeByIndex(index).Value;
            }
            set
            {
                FindNodeByIndex(index).Value = value;
            }
        }

        public void Add(T value)
        {
            if (_first == null)
            {
                _first = new LinkedListNode<T>(value);
                _first.Next = _first;
            }
            else
            {
                LinkedListNode<T> endNode = _end;
                LinkedListNode<T> node = new LinkedListNode<T>(value, _first);
                endNode.Next = node;
            }
            Length += 1;
        }

        public void RemoveAt(int index)
        {
            LinkedListNode<T> currentNode = FindNodeByIndex(index - 1);
            if (Length == 1)
            {
                _first = null;
            }
            else
            {
                currentNode.Next = currentNode.Next.Next;
            }
            Length -= 1;
        }

        public void Remove(T value)
        {
            if (_first == null)
            {
                throw new KeyNotFoundException();
            }
            if (Length == 1)
            {
                _first = null;
            }
            else
            {
                int currentIndex = 0;
                LinkedListNode<T> currentNode = _first;
                do
                {
                    if (currentNode.Next.Value.Equals(value))
                    {
                        break;
                    }
                    currentNode = currentNode.Next;
                    currentIndex += 1;
                } while (currentIndex < Length);
                currentNode.Next = currentNode.Next.Next;
            }
            Length -= 1;
        }

        public void Clear() 
        {
            First = null;
            Length = 0;
        }

        public bool Contains(T value)
        {
            int currentIndex = 0;
            LinkedListNode<T> currentNode = _first;
            do
            {
                if (currentNode.Next.Value.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
                currentIndex += 1;
            } while (currentIndex < Length);
            return false;
        }

        public int IndexOf(T value)
        {
            int currentIndex = 0;
            LinkedListNode<T> currentNode = _first;
            do
            {
                if (currentNode.Next.Value.Equals(value))
                {
                    return currentIndex;
                }
                currentNode = currentNode.Next;
                currentIndex += 1;
            } while (currentIndex < Length);
            throw new KeyNotFoundException();
        }

        public void Insert(int index, T value)
        {
            LinkedListNode<T> currentNode = FindNodeByIndex(index);
            LinkedListNode<T> node = new LinkedListNode<T>(value, currentNode.Next);
            currentNode.Next = node;
        }

        public bool Empty()
        {
            return Length == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentIndex = 0;
            LinkedListNode<T> currentNode = _first;
            while (currentIndex < Length)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
                currentIndex += 1;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
