namespace algorithms.Sorting
{
    public partial class Sort<T>
        where T : IComparable
    {
        public static T[] Insertion(T[] array)
        {
            for (int i = 1; i < array.Length - 1; ++i) 
            {
                for (int j = i + 1; j > 0; --j)
                {
                    if (array[j-1].CompareTo(array[j]) > 0) 
                    {
                        T temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
    }
}
