using Custom.Collections.List;

namespace Custom.Collections
{
    public class Stack<T>
    {
        private SinglyLinkedList<T> m_list;

        public Stack()
        {
            m_list = new SinglyLinkedList<T>();
        }

        public bool Empty()
        {
            return m_list.Count == 0;
        }

        public void Push(T item)
        {
            m_list.Add(item);
        }

        public void Pop()
        {
            m_list.RemoveAt(m_list.Count - 1);
        }

        public T Peek()
        {
            return m_list[m_list.Count - 1];
        }
    }
}
