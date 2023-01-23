using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_proj.Model
{
    internal static class ClusterToNetwork
    {
        // List<int> list = new List<int>();
        static Dictionary<int, int>? list; // = new Dictionary<int, int>();


        // Finding end vertex
        public static int[,] DoNetwork(int[,] cluster)
        {
            list = new Dictionary<int, int>();

            bool flag;
            int sum;

            for (int i = 0; i < cluster.GetLength(0); ++i)
            {
                flag = true;
                sum = 0;

                for (int j = 0; j < cluster.GetLength(0); ++j)
                {
                    if (cluster[i, j] != 0)
                        flag = false;
                }

                if (flag)
                {
                    for (int k = 0; k < cluster.GetLength(0); ++k)
                    {
                        sum += cluster[k, i];
                    }

                    list.Add(i, sum);
                }
            }

            // Clone cluster in network, add "0" in last line & columan

            int[,] network = new int[cluster.GetLength(0) + 1, cluster.GetLength(0) + 1];

            // Array.Copy(cluster, network, cluster.Lenght);

            for (int i = 0; i < cluster.GetLength(0); ++i)
                for (int j = 0; j < cluster.GetLength(0); ++j)
                    network[i, j] = cluster[i, j];

            /*for (int i = 0; i < cluster.GetLength(0); ++i)
            {
                network[network.GetLength(0)-1, i] = 0;
                network[i, network.GetLength(0)-1] = 0;
            }*/

            // Add flow for last column (for sink)

            foreach (var i in list)
            {
                int foo = i.Key;
                int bar = network.GetLength(0) - 1;
                int baz = list[i.Key];
                network[i.Key, network.GetLength(0) - 1] = i.Value;
            }

            list = null;

            return network;
        }
    }
}
