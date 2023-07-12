using System.Collections;

namespace Custom.Collections.Queues
{
    public class SinglyQueue<T>
    {
        private T[] m_array;

        private int m_size;

        public SinglyQueue()
        {
            m_array = new T[10];
            m_size = 0;
        }

        public int Count 
        { 
            get
            {
                return m_array.Length;
            } 
        }

        public T Peek()
        {
            return m_array[0];
        }

        public void Enqueue(T item)
        {
            if (m_size < m_array.Length)
            {
                m_array[m_size] = item;
                m_size += 1;
            }
            else
            {
                Array.Resize(ref m_array, m_array.Length * 2);
                Enqueue(item);
            }

        }

        public T Dequeue()
        {
            if (m_size <= 0) 
            {
                throw new NullReferenceException();
            }
            T temp = m_array[0];
            for (int i = 0; i < m_size - 1; i++)
            {
                m_array[i] = m_array[i + 1];
            }
            return temp;
        }

        public bool Empty()
        {
            return m_size == 0;
        }
    }
}
