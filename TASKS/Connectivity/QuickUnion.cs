namespace TASKS.Connectivity
{
    public partial class Connectivity
    {
        public static void QuickUnion(List<Tuple<int, int>> pairs)
        {
            const int N = 1000;
            int[] id = new int[N];
            for (int k = 0; k < N; ++k)
            {
                id[k] = k;
            }

            int i, j;
            foreach (var pair in pairs)
            {
                for (i = pair.Item1; i != id[i]; i = id[i]) {}
                for (j = pair.Item2; j != id[j]; j = id[j]) { }
                if (i == j)
                {
                    continue;
                }

                id[i] = j;

                Console.WriteLine($"Pair: {pair.Item1}-{pair.Item2}");
            }
        }
    }
}
