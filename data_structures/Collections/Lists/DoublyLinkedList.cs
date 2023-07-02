using System.Collections;

namespace data_structures.Collections.Lists
{
    public class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T>? Next { get; set; }
        public DoublyLinkedListNode<T>? Previous { get; set; }

        public DoublyLinkedListNode()
        {
            Next = null;
            Previous = null;
        }

        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T>? prev = null, DoublyLinkedListNode<T>? next = null)
        {
            Value = value;
            Previous = prev;
            Next = next;
        }
    }

    public class DoublyLinkedList<T> : IList<T>
    {
        private DoublyLinkedListNode<T> _first;

        private DoublyLinkedListNode<T> _end;

        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (_first != null && index == 0)
                {
                    return _first.Value;
                }

                var indexCurrentNode = 0;
                var currentNode = _first;

                var indexReverseNode = Length - 1;
                var reverseNode = _end;

                while (!ReferenceEquals(currentNode, reverseNode))
                {
                    if (indexCurrentNode == index)
                    {
                        return currentNode.Value;
                    }
                    if (indexReverseNode == index)
                    {
                        return reverseNode.Value;
                    }
                    if (!ReferenceEquals(currentNode.Next, reverseNode))
                    {
                        indexCurrentNode += 1;
                        currentNode = currentNode.Next;
                    }
                    indexReverseNode -= 1;
                    reverseNode = reverseNode.Previous;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (_first != null && index == 0)
                {
                    _first.Value = value;
                }

                var indexCurrentNode = 0;
                var currentNode = _first;

                var indexReverseNode = Length - 1;
                var reverseNode = _end;

                while (!ReferenceEquals(currentNode, reverseNode))
                {
                    if (indexCurrentNode == index)
                    {
                        currentNode.Value = value;
                    }
                    if (indexReverseNode == index)
                    {
                        reverseNode.Value = value;
                    }
                    if (!ReferenceEquals(currentNode.Next, reverseNode))
                    {
                        indexCurrentNode += 1;
                        currentNode = currentNode.Next;
                    }
                    indexReverseNode -= 1;
                    reverseNode = reverseNode.Previous;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public DoublyLinkedList()
        {
            _first = null;
            _end = null;
            Length = 0;
        }

        public DoublyLinkedList(DoublyLinkedList<T> other)
        {
            _first = other._first;
            _end = other._end;
            Length = other.Length;
        }

        public void Add(T value)
        {
            if (_first == null)
            {
                _first = _end = new DoublyLinkedListNode<T>(value: value);
            }
            else
            {
                _end.Next = new DoublyLinkedListNode<T>(value: value, prev: _end);
                _end = _end.Next;
            }
            Length += 1;
        }

        public void Clear()
        {
            _first = null;
            _end = null;
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

        public int IndexOf(T value)
        {
            if (_first == null)
            {
                return -1;
            }
            else
            {
                var indexCurrentNode = 0;
                var currentNode = _first;

                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(value))
                    {
                        return indexCurrentNode;
                    }
                    indexCurrentNode += 1;
                    currentNode = currentNode.Next;
                }
                return -1;
            }
        }

        public void Insert(int index, T value)
        {
            var indexCurrentNode = 0;
            var currentNode = _first;
            while (currentNode != null)
            {
                if (indexCurrentNode == index)
                {
                    var insertNode = new DoublyLinkedListNode<T>(value: value, prev: currentNode, next: currentNode.Next);
                    if (currentNode.Next != null)
                    {
                        currentNode.Next.Previous = insertNode;
                    }
                    currentNode.Next = insertNode;
                    Length += 1;
                    return;
                }
                indexCurrentNode += 1;
                currentNode = currentNode.Next;
            }
        }

        public void Remove(T value)
        {
            var currentNode = _first;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    if (currentNode.Previous != null)
                    {
                        currentNode.Previous.Next = currentNode.Next;
                    }
                    if (currentNode.Next != null)
                    {
                        currentNode.Next.Previous = currentNode.Previous;
                    }
                    Length -= 1;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        public void RemoveAt(int index)
        {
            var indexCurrentNode = 0;
            var currentNode = _first;
            while (currentNode != null)
            {
                if (indexCurrentNode == index)
                {
                    if (currentNode.Previous != null)
                    {
                        currentNode.Previous.Next = currentNode.Next;
                    }
                    if (currentNode.Next != null)
                    {
                        currentNode.Next.Previous = currentNode.Previous;
                    }
                    Length -= 1;
                    return;
                }
                indexCurrentNode += 1;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}