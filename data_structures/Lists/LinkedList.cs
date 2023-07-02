using System.Collections;

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

    public class LinkedList<T> : IList<T>
    {
        private LinkedListNode<T>? _first;

        public LinkedList()
        {
            
        }

        public LinkedList(LinkedList<T> other)
        {
            _first = other._first;
            Length = other.Length;
        }

        public int Length { get; private set; } = 0;

        public T this[int index]
        {
            get
            {
                var indexNode = 0;
                var currentNode = _first;
                while (currentNode != null)
                {
                    if (indexNode == index)
                    {
                        return currentNode.Value;
                    }
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                var indexNode = 0;
                var currentNode = _first;
                while (currentNode != null)
                {
                    if (indexNode == index)
                    {
                        currentNode.Value = value;
                    }
                }
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(T value)
        {
            if (_first == null)
            {
                _first = new LinkedListNode<T>(value);
                Length += 1;
            }
            else
            {
                var previousNode = _first;
                var currentNode = _first.Next;
                while (currentNode != null) 
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
                previousNode.Next = new LinkedListNode<T>(value);
                Length += 1;
            }
        }

        public void Clear()
        {
            _first = null;
            Length = 0;
        }

        public bool Contains(T value)
        {
            if (_first == null)
            {
                return false;
            }
            else
            {
                var currentNode = _first;
                while (currentNode != null) 
                {
                    if (currentNode.Value.Equals(value))
                    {
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        public int IndexOf(T value)
        {
            if (_first == null)
            {
                return -1;
            }
            else
            {
                var indexNode = 0;
                var currentNode = _first;
                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(value))
                    {
                        return indexNode;
                    }
                    indexNode += 1;
                    currentNode = currentNode.Next;
                }
                return -1;
            }
        }

        public void Insert(int index, T value)
        {
            var indexNode = 0;
            if (indexNode == index && _first == null) 
            {
                _first = new LinkedListNode<T>(value);
                Length += 1;
                return;
            }
            var currentNode = _first;
            while (currentNode != null)
            {
                if (indexNode == index)
                {
                    currentNode.Next = new LinkedListNode<T>(value, currentNode.Next);
                    Length += 1;
                    return;
                }
                currentNode = currentNode.Next;
            }
            throw new IndexOutOfRangeException();
        }

        public void Remove(T value)
        {
            if (_first == null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (_first.Value.Equals(value))
                {
                    _first = _first.Next;
                    Length -= 1;
                    return;
                }

                var prevoiusNode = _first;
                var currentNode = _first.Next;
                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(value))
                    {
                        prevoiusNode.Next = currentNode.Next;
                        Length -= 1;
                        return;
                    }
                    prevoiusNode = currentNode;
                    currentNode = currentNode.Next;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveAt(int index)
        {
            if (_first == null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                var indexNode = 0;
                if (indexNode == index)
                {
                    _first = _first.Next;
                    Length -= 1;
                    return;
                }

                var prevoiusNode = _first;
                var currentNode = _first.Next;
                while (currentNode != null)
                {
                    if (indexNode == index)
                    {
                        prevoiusNode.Next = currentNode.Next;
                        Length -= 1;
                        return;
                    }
                    prevoiusNode = currentNode;
                    currentNode = currentNode.Next;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public bool Empty()
        {
            return Length == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _first;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}