using Custom.Collections.List;

namespace Custom.Collections.Queue
{
    public class Queue<T>
    {
        private SinglyLinkedList<T> m_list;

        public Queue()
        {
            m_list = new SinglyLinkedList<T>();
        }

        public int Count
        {
            get
            {
                return m_list.Count;
            }
        }

        public T Peek()
        {
            return m_list[0];
        }

        public void Push(T item)
        {
            m_list.Add(item);
        }

        public void Pop()
        {
            m_list.RemoveAt(0);
        }

        public bool Empty()
        {
            return m_list.Count == 0;
        }
    }
}
