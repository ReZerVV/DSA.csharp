using System.Collections;

namespace Custom.Collections.List
{
    internal class DoublyLinkedList_Node<T>
    {
        public T Value;

        public DoublyLinkedList_Node<T> Previous;

        public DoublyLinkedList_Node<T> Next;

        public DoublyLinkedList_Node(T value, DoublyLinkedList_Node<T> previous = null, DoublyLinkedList_Node<T> next = null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }

    public class DoublyLinkedList<T> : IList<T>
    {
        private DoublyLinkedList_Node<T> m_first;

        private DoublyLinkedList_Node<T> m_last;

        public DoublyLinkedList()
        {
            m_first = null;
            m_last = null;
        }

        public DoublyLinkedList(DoublyLinkedList<T> other)
        {
            m_first = other.m_first;
            m_last = other.m_last;
        }

        public T this[int index] 
        {
            get
            {
                var currentIndex = 0;
                var currentNode = m_first;
                while (currentNode != m_last.Next)
                {
                    if (currentIndex == index)
                    {
                        return currentNode.Value;
                    }
                }
                throw new IndexOutOfRangeException(nameof(index));
            }
            set
            {
                var currentIndex = 0;
                var currentNode = m_first;
                while (currentNode != m_last.Next)
                {
                    if (currentIndex == index)
                    {
                        currentNode.Value = value;
                    }
                }
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        public int Count 
        {
            get
            {
                var currentIndex = 0;
                var currentNode = m_first;
                while (currentNode != m_last?.Next)
                {
                    currentNode = currentNode.Next;
                    currentIndex += 1;
                }
                return currentIndex;
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (m_first == null) 
            {
                m_first = m_last = new DoublyLinkedList_Node<T>(item);
                return;
            }
            m_last.Next = new DoublyLinkedList_Node<T>(item, m_last);
            m_last = m_last.Next;
        }

        public void Clear()
        {
            m_first = m_last = null;
        }

        public bool Contains(T item)
        {
            var currentNode = m_first;
            while (currentNode != m_last.Next)
            {
                if (currentNode.Value.Equals(item)) 
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length > Count + arrayIndex)
            {
                throw new OverflowException(nameof(array));
            }
            var currentIndex = arrayIndex;
            var currentNode = m_first;
            while (currentNode != m_last.Next)
            {
                array[currentIndex] = currentNode.Value;
                currentNode = currentNode.Next;
                currentIndex += 1;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = m_first;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        public int IndexOf(T item)
        {
            var currentIndex = 0;
            var currentNode = m_first;
            while (currentNode != m_last.Next) 
            {
                if (currentNode.Value.Equals(item))
                {
                    return currentIndex;
                }
                currentNode = currentNode.Next;
                currentIndex += 1;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (m_first == null)
            {
                throw new NullReferenceException(nameof(DoublyLinkedList<T>));
            }
            var currentIndex = 0;
            var currentNode = m_first;
            while (currentNode != m_last.Next) 
            {
                if (currentIndex == index)
                {
                    currentNode.Next = new DoublyLinkedList_Node<T>(item, currentNode, currentNode.Next);
                    return;
                }
                currentNode = currentNode.Next;
                currentIndex += 1;
            }
            throw new IndexOutOfRangeException(nameof(index));
        }

        public bool Remove(T item)
        {
            var currentNode = m_first;
            while (currentNode != m_last?.Next)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (currentNode == m_first)
                    {
                        m_first = m_first.Next;
                        return true;
                    }
                    if (currentNode == m_last)
                    {
                        m_last = m_last.Previous;
                        return true;
                    }
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            var currentIndex = 0;
            var currentNode = m_first;
            while (currentNode != m_last?.Next)
            {
                if (currentIndex == index)
                {
                    if (currentNode == m_first)
                    {
                        m_first = m_first.Next;
                        return;
                    }
                    if (currentNode == m_last)
                    {
                        m_last = m_last.Previous;
                        return;
                    }
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return;
                }
                currentNode = currentNode.Next;
                currentIndex += 1;
            }
            throw new IndexOutOfRangeException(nameof(index));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
