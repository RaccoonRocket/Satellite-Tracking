using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_proj.Model
{
    internal static class Data
    {
        public static readonly int nMax = 30;
        public static int sizeOfGrid { get; set; }
        public static int mainVertex { get; set; }

        public static int[,] cluster
        {
            get
            {
                return StartCluster;
            }
            set
            {
                StartCluster = value;
            }
        }
        public static int[,] network
        {
            get
            {
                return FlowNetwork;
            }
            set
            {
                FlowNetwork = value;
            }
        }

        private static int[,] StartCluster = null;
        private static int[,] FlowNetwork = null;


        // Example:
        public static readonly int maxExample = 7;
        public static int[,] exampleNetwork
        {
            get { return Example; }
        }

        private static int[,] Example =
        {
            { 0, 9, 3, 0, 0, 5, 0 },
            { 0, 0, 0, 10, 0, 0, 0 },
            { 0, 0, 0, 0, 10, 0, 0 },
            { 0, 0, 0, 0, 0, 3, 8 },
            { 0, 0, 0, 0, 0, 0, 4 },
            { 0, 0, 0, 0, 4, 0, 6 },
            { 0, 0, 0, 0, 0, 0, 0 }
        };
    }
}
