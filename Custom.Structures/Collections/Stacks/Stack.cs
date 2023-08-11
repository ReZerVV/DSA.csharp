namespace Custom.Structures.Collections.Stacks
{
    public class Stack<T>
    {
        private Lists.LinkedList<T> items;

        public Stack()
        {
            this.items = new Lists.LinkedList<T>();
        }

        public Stack(IEnumerable<T> items)
            : this()
        {
            foreach (var item in items)
            {
                this.items.Add(item);
            }
        }

        public bool Empty()
        {
            return items.Empty();
        }

        public T Peek()
        {
            return items[items.Length - 1];
        }

        public void Pop()
        {
            items.RemoveAt(items.Length - 1);
        }

        public void Push(T value)
        {
            items.Add(value);
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
