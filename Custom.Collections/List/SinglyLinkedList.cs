using System;
using System.Collections;

namespace Custom.Collections.List
{
    internal class SinglyLinkedList_Node<T>
    {
        public T Value;
         
        public SinglyLinkedList_Node<T> Next;

        public SinglyLinkedList_Node(T value, SinglyLinkedList_Node<T> next = null)
        {
            Value = value;
            Next = next;
        }
    }

	public class SinglyLinkedList<T> : IList<T>
	{
        private SinglyLinkedList_Node<T> m_first;

        public T this[int index]
        {
            get
            {
                var currentIndex = 0;
                var currentNode = m_first;
                while (currentNode != null)
                {
                    if (currentIndex == index)
                    {
                        return currentNode.Value;
                    }
                    currentNode = currentNode.Next;
                    currentIndex += 1;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                var currentIndex = 0;
                var currentNode = m_first;
                while (currentNode != null)
                {
                    if (currentIndex == index)
                    {
                        currentNode.Value = value;
                    }
                    currentNode = currentNode.Next;
                    currentIndex += 1;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public int Count 
        {
            get
            {
                var currentIndex = 0;
                var currentNode = m_first;
                while (currentNode != null)
                {
                    currentNode = currentNode.Next;
                    currentIndex += 1;
                }
                return currentIndex;
            }
        }

        public bool IsReadOnly => false;

        public SinglyLinkedList()
        {
            m_first = null;
        }

        public SinglyLinkedList(SinglyLinkedList<T> other)
        {
            m_first = other.m_first;
        }

        public void Add(T item)
        {
            if (m_first == null) 
            {
                m_first = new SinglyLinkedList_Node<T>(item);
                return;
            }
            var currentNode = m_first;
            while (currentNode.Next != null) 
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = new SinglyLinkedList_Node<T>(item);
        }

        public void Clear()
        {
            m_first = null;
        }

        public bool Contains(T item)
        {
            var currentNode = m_first;
            while (currentNode != null)
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
            while (currentNode != null)
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
            while (currentNode != null)
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
            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    currentNode.Next = new SinglyLinkedList_Node<T>(item, currentNode.Next);
                    return;
                }
                currentNode = currentNode.Next;
                currentIndex += 1;
            }
            throw new IndexOutOfRangeException();
        }

        public bool Remove(T item)
        {
            SinglyLinkedList_Node<T> previousNode = null;
            var currentNode = m_first;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (currentNode == m_first)
                    {
                        m_first = m_first.Next;
                        return true;
                    }
                    previousNode.Next = currentNode.Next;
                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            var currentIndex = 0;
            SinglyLinkedList_Node<T> previousNode = null;
            var currentNode = m_first;
            while (currentNode != null)
            {
                if (currentIndex == index) 
                {
                    if (currentNode == m_first)
                    {
                        m_first = m_first.Next;
                        return;
                    }
                    previousNode.Next = currentNode.Next;
                    return;
                }
                previousNode = currentNode;
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