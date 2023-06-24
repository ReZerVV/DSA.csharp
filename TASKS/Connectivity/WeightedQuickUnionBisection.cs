﻿namespace TASKS.Connectivity
{
    public partial class Connectivity
    {
        public static void WeightedQuickUnionBisection(List<Tuple<int, int>> pairs)
        {
            const int N = 1000;
            int[] id = new int[N];
            int[] sz = new int[N];
            for (int k = 0; k < N; ++k)
            {
                id[k] = k;
                sz[k] = k;
            }

            int i, j;
            foreach (var pair in pairs)
            {
                for (i = pair.Item1; i != id[i]; i = id[i])
                {
                    id[i] = id[id[i]];
                }
                for (j = pair.Item2; j != id[j]; j = id[j]) 
                {
                    id[j] = id[id[j]];
                }
                if (i == j)
                {
                    continue;
                }

                if (sz[i] < sz[j])
                {
                    id[i] = j;
                    sz[i] += sz[j];
                }
                else
                {
                    id[j] = i;
                    sz[j] += sz[i];
                }

                Console.WriteLine($"Pair: {pair.Item1}-{pair.Item2}");
            }
        }
    }
}