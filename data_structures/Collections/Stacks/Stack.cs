using System.Data;

namespace data_structures.Collections.Stacks
{
    public class Stack<T>
    {
        private T[] _array;
        private int _capacity;

        public int Length { get; private set; }

        public Stack()
        {
            _capacity = 10;
            Array.Resize(ref _array, _capacity);
            Length = 0;
        }

        public Stack(Stack<T> other)
        {
            _capacity = other._capacity;
            Length = other.Length;
            _array = other._array;

        }

        public Stack(IEnumerable<T> array)
        {
            _capacity = array.Count();
            Length = array.Count();
            _array = array.ToArray();
        }

        public bool Empty()
        {
            return Length == 0;
        }

        public void Clear()
        {
            _capacity = 10;
            Array.Resize(ref _array, _capacity);
            Length = 0;
        }

        public T Peek()
        {
            if (!Empty())
            {
                return _array[Length - 1];
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Push(T value)
        {
            if (Length + 1 < _capacity)
            {
                _array[Length] = value;
                Length += 1;
            }
            else
            {
                _capacity *= 2;
                Array.Resize(ref _array, _capacity);
                Push(value);
            }
        }

        public void Pop()
        {
            if (!Empty())
            {
                Length -= 1;
            }
            else
            { 
                throw new InvalidOperationException();
            }
        }
    }
}
