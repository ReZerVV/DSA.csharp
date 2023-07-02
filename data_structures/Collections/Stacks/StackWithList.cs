using Lists = data_structures.Collections.Lists;

namespace data_structures.Collections.Stacks
{
    public class StackWithList<T>
    {
        private Lists.LinkedList<T> _list;

        public int Length => _list.Length;

        public StackWithList()
        {
            _list = new Lists.LinkedList<T>();
        }

        public StackWithList(StackWithList<T> other)
        {
            _list = other._list;
        }

        public StackWithList(IEnumerable<T> array)
        {
            _list = new Lists.LinkedList<T>(array);
        }

        public bool Empty()
        {
            return Length == 0;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public T Peek()
        {
            if (!Empty())
            {
                return _list[Length - 1];
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Push(T value)
        {
            _list.Add(value);
        }

        public void Pop()
        {
            if (!Empty())
            {
                _list.RemoveAt(_list.Length - 1);
            }
            else
            { 
                throw new InvalidOperationException();
            }
        }
    }
}
