using Course_proj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_proj.Controller
{
    public static class ControllerTransform
    {
        public static void Transformation()
        {
            Data.network = ClusterToNetwork.DoNetwork(Data.cluster);
        }
    }

    public static class ControllerMaxFlow
    {
        public static int getMaxFlow()
        {
            return MaxFlow.fordFulkerson(Data.network, Data.mainVertex, Data.sizeOfGrid);
        }
    }

    public static class ControllerCut
    {
        public static int getCut()
        {
            int sum = 0;
            for (int i = 0; i < Data.network.GetLength(0); ++i)
            {
                sum += Data.network[Data.mainVertex, i];
            }
            return sum;
        }
    }

    public static class ControllerDisplay
    {
        public static void FlowNetwork(int[,] mtx)
        {

        }
    }
}
