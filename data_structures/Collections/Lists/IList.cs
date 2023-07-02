using System.Collections;

namespace data_structures.Collections.Lists
{
    public interface IList<T> : IEnumerable<T>
    {
        int Length { get; }

        void Add(T value);

        void Clear();

        bool Contains(T value);

        int IndexOf(T value);

        void Insert(int index, T value);

        void Remove(T value);

        void RemoveAt(int index);

        bool Empty();
    }
}
