namespace Custom.Structures.Collections.Arrays
{
    public class Array<T>
    {
        private T[] items;
        private int length;

        public Array()
        {
            items = new T[10];
            length = 0;
        }

        public Array(int capacity)
        {
            items = new T[capacity];
            length = 0;
        }

        public bool Empty()
        {
            return length == 0;
        }

        public void Clear()
        {
            length = 0;
        }

        public void Add(T value)
        {
            
        }

        public void Insert(T value, int index)
        {
            
        }
    }
}
