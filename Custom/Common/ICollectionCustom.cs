using System;

namespace Custom.Common
{
	public interface ICollectionCustom<T>
	{
		int Count { get; }

		void Add(T item);

		void Clear();

        bool Contains(T item);

        void CopyTo(T[] array, int arrayIndex);

        void Remove(T item);
	}
}