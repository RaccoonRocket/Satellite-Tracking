using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_proj.Model
{
    internal static class Data
    {
        public static int nMax = 30;
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
                return StreamingNetwork;
            }
            set
            {
                StreamingNetwork = value;
            }
        }

        private static int[,] StartCluster = null; /*new int[nMax, nMax];*/
        private static int[,] StreamingNetwork = null; /* new int[nMax + 1, nMax + 1];*/
    }
}
