namespace TASKS.Connectivity
{
    public partial class Connectivity
    {
        public static void QuickFind(List<Tuple<int, int>> pairs)
        {
            const int N = 1000;
            int[] id = new int[N];
            for (int i = 0; i < N; ++i) 
            {
                id[i] = i;
            }

            foreach (var pair in pairs)
            {
                int t = id[pair.Item1];

                if (t == id[pair.Item2]) 
                {
                    continue;
                }

                for (int i = 0; i < N; ++i) 
                {
                    if (id[i] == t) 
                    {
                        id[i] = id[pair.Item2];
                    }
                }

                Console.WriteLine($"Pair: {pair.Item1}-{pair.Item2}");
            }
        }
    }
}
