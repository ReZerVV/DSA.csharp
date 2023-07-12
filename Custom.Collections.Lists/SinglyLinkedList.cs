using System.Collections;

namespace Custom.Collections.Lists
{
    internal class SinglyLinkedList_Node<T>
    {
        public T Value;
        public SinglyLinkedList_Node<T> Next;
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

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => true;

        public SinglyLinkedList()
        {

        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}