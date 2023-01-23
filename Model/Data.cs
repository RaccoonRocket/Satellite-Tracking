using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private static int[,]? StartCluster = null;
        private static int[,]? FlowNetwork = null;


        // Example 1
        public static readonly int maxExample1 = 7;
        public static int[,] example1Network
        {
            get { return Example1; }
        }

        /*private static int[,] Example1 =
        {
            { 0, 7, 0, 0, 9, 0, 0 },
            { 0, 0, 5, 0, 0, 0, 2 },
            { 0, 0, 0, 8, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 8, 0 },
            { 0, 0, 0, 3, 0, 0, 5 },
            { 0, 0, 0, 0, 0, 0, 0 }
        };*/

        private static int[,] Example1 =
        {
            { 0, 10, 0, 0, 12, 0, 0 },
            { 0, 0, 9, 0, 0, 0, 1 },
            { 0, 0, 0, 16, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 7, 0, 0, 5, 0 },
            { 0, 0, 0, 2, 0, 0, 2 },
            { 0, 0, 0, 0, 0, 0, 0 }
        };


        // Example 2
        public static readonly int maxExample2 = 10;
        public static int[,] example2Network
        {
            get { return Example2; }
        }

        private static int[,] Example2 =
        {
            { 0, 10, 0, 0, 9, 0, 0, 12, 0, 0 },
            { 0, 0, 10, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 10, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 9, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 9, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 12, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 12 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
    }
}
