using System.Collections;

namespace data_structures.Lists
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
                _first = _end = new DoublyLinkedListNode<T>(value:value);
                Length += 1;
                return;
            }
            else
            {
                _end.Next = new DoublyLinkedListNode<T>(value:value, prev:_end);
                Length += 1;
                return;
            }
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
                if (ReferenceEquals(_first, _end) && _first.Value.Equals(value))
                {
                    return true;
                }

                var currentNode = _first;
                var reverseNode = _end;
                while (!ReferenceEquals(currentNode, reverseNode)) 
                {
                    if (currentNode.Value.Equals(value) || reverseNode.Value.Equals(value)) 
                    {
                        return true;
                    }
                    if (!ReferenceEquals(currentNode.Next, reverseNode))
                    {
                        currentNode = currentNode.Next;
                    }
                    reverseNode = reverseNode.Previous;
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
                if (ReferenceEquals(_first, _end) && _first.Value.Equals(value))
                {
                    return 0;
                }

                var indexCurrentNode = 0;
                var currentNode = _first;

                var indexReverseNode = Length -= 1;
                var reverseNode = _end;
                
                while (!ReferenceEquals(currentNode, reverseNode))
                {
                    if (currentNode.Value.Equals(value))
                    {
                        return indexCurrentNode;
                    }
                    if (reverseNode.Value.Equals(value))
                    {
                        return indexReverseNode;
                    }
                    if (!ReferenceEquals(currentNode.Next, reverseNode))
                    {
                        indexCurrentNode += 1;
                        currentNode = currentNode.Next;
                    }
                    indexReverseNode -= 1;
                    reverseNode = reverseNode.Previous;
                }
                return -1;
            }
        }

        public void Insert(int index, T value)
        {
            if (_first == null && index == 0)
            {
                _first = _end = new DoublyLinkedListNode<T>(value:value);
                Length += 1;
                return;
            }
            else
            {
                var indexCurrentNode = 0;
                var currentNode = _first;

                var indexReverseNode = Length - 1;
                var reverseNode = _end;
                while (!ReferenceEquals(currentNode, reverseNode))
                {
                    if (indexCurrentNode == index)
                    {
                        var insertNode = new DoublyLinkedListNode<T>(value:value, prev:currentNode, next:currentNode.Next);
                        currentNode.Next.Previous = insertNode;
                        currentNode.Next = insertNode;
                        Length += 1;
                        return;
                    }
                    if (indexReverseNode == index)
                    {
                        var insertNode = new DoublyLinkedListNode<T>(value: value, prev: reverseNode, next: reverseNode.Next);
                        reverseNode.Next.Previous = insertNode;
                        reverseNode.Next = insertNode;
                        Length += 1;
                        return;
                    }
                    if (!ReferenceEquals(currentNode.Next, reverseNode))
                    {
                        indexCurrentNode += 1;
                        currentNode = currentNode.Next;
                    }
                    indexReverseNode -= 1;
                    reverseNode = reverseNode.Previous;
                }
            }
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
                    _first.Previous = null;
                    Length -= 1;
                    return;
                }

                if (_end.Value.Equals(value))
                {
                    _end = _end.Previous;
                    _end.Next = null;
                    Length -= 1;
                    return;
                }

                var currentNode = _first.Next;
                var reverseNode = _end.Previous;
                while (!ReferenceEquals(currentNode, reverseNode))
                {
                    if (currentNode.Value.Equals(value))
                    {
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                        Length -= 1;
                        return;
                    }
                    if (reverseNode.Value.Equals(value))
                    {
                        reverseNode.Previous.Next = reverseNode.Next;
                        reverseNode.Next.Previous = reverseNode.Previous;
                        Length -= 1;
                        return;
                    }
                    if (!ReferenceEquals(currentNode.Next, reverseNode))
                    {
                        currentNode = currentNode.Next;
                    }
                    reverseNode = reverseNode.Previous;
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
                var indexCurrentNode = 0;
                var previousCurrentNode = _first.Previous;
                var currentNode = _first;

                var indexReverseNode = Length - 1;
                var previousReverseNode = _end.Next;
                var reverseNode = _end;

                while (!ReferenceEquals(currentNode, reverseNode))
                {
                    if (indexCurrentNode == index)
                    {
                        previousCurrentNode.Next = currentNode.Next;
                        currentNode.Next.Previous = previousCurrentNode;
                        Length -= 1;
                        return;
                    }
                    if (indexReverseNode == index)
                    {
                        previousReverseNode.Next = reverseNode.Next;
                        reverseNode.Next.Previous = previousReverseNode;
                        Length -= 1;
                        return;
                    }
                    if (!ReferenceEquals(currentNode.Next, reverseNode))
                    {
                        indexCurrentNode += 1;
                        previousCurrentNode = currentNode;
                        currentNode = currentNode.Next;
                    }
                    indexReverseNode -= 1;
                    previousReverseNode = reverseNode;
                    reverseNode = reverseNode.Previous;
                }
                throw new IndexOutOfRangeException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}