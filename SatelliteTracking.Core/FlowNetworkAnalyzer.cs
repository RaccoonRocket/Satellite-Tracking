namespace SatelliteTracking.Core;

public sealed record FlowAnalysisResult(int[,] Cluster, int[,] Network, int MaxFlow, int Cut);

public static class FlowNetworkAnalyzer
{
    public const int MaxGridSize = 30;

    public static FlowAnalysisResult Analyze(int[,] cluster, int sourceVertex)
    {
        ValidateCluster(cluster, sourceVertex);

        var clusterCopy = Clone(cluster);
        var network = ClusterToNetwork(clusterCopy);
        var sinkVertex = clusterCopy.GetLength(0);
        var maxFlow = FordFulkerson(network, sourceVertex, sinkVertex);
        var cut = GetCut(network, sourceVertex);

        return new FlowAnalysisResult(clusterCopy, network, maxFlow, cut);
    }

    public static int[,] ClusterToNetwork(int[,] cluster)
    {
        var size = cluster.GetLength(0);
        var sinks = new Dictionary<int, int>();

        for (var i = 0; i < size; i++)
        {
            var hasOutgoingEdge = false;

            for (var j = 0; j < size; j++)
            {
                if (cluster[i, j] != 0)
                {
                    hasOutgoingEdge = true;
                    break;
                }
            }

            if (hasOutgoingEdge)
            {
                continue;
            }

            var incomingSum = 0;
            for (var k = 0; k < size; k++)
            {
                incomingSum += cluster[k, i];
            }

            sinks.Add(i, incomingSum);
        }

        var network = new int[size + 1, size + 1];

        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                network[i, j] = cluster[i, j];
            }
        }

        foreach (var sink in sinks)
        {
            network[sink.Key, size] = sink.Value;
        }

        return network;
    }

    public static int GetCut(int[,] network, int sourceVertex)
    {
        var sum = 0;

        for (var i = 0; i < network.GetLength(0); i++)
        {
            sum += network[sourceVertex, i];
        }

        return sum;
    }

    public static int FordFulkerson(int[,] graph, int sourceVertex, int sinkVertex)
    {
        var vertexCount = graph.GetLength(0);
        var residualGraph = new int[vertexCount, vertexCount];

        for (var u = 0; u < vertexCount; u++)
        {
            for (var v = 0; v < vertexCount; v++)
            {
                residualGraph[u, v] = graph[u, v];
            }
        }

        var parent = new int[vertexCount];
        var maxFlow = 0;

        while (BreadthFirstSearch(residualGraph, sourceVertex, sinkVertex, parent))
        {
            var pathFlow = int.MaxValue;

            for (var v = sinkVertex; v != sourceVertex; v = parent[v])
            {
                var u = parent[v];
                pathFlow = Math.Min(pathFlow, residualGraph[u, v]);
            }

            for (var v = sinkVertex; v != sourceVertex; v = parent[v])
            {
                var u = parent[v];
                residualGraph[u, v] -= pathFlow;
                residualGraph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
        }

        return maxFlow;
    }

    private static bool BreadthFirstSearch(int[,] residualGraph, int sourceVertex, int sinkVertex, int[] parent)
    {
        var vertexCount = residualGraph.GetLength(0);
        var visited = new bool[vertexCount];
        var queue = new Queue<int>();

        queue.Enqueue(sourceVertex);
        visited[sourceVertex] = true;
        parent[sourceVertex] = -1;

        while (queue.Count != 0)
        {
            var u = queue.Dequeue();

            for (var v = 0; v < vertexCount; v++)
            {
                if (visited[v] || residualGraph[u, v] <= 0)
                {
                    continue;
                }

                parent[v] = u;

                if (v == sinkVertex)
                {
                    return true;
                }

                queue.Enqueue(v);
                visited[v] = true;
            }
        }

        return false;
    }

    private static void ValidateCluster(int[,] cluster, int sourceVertex)
    {
        if (cluster.GetLength(0) != cluster.GetLength(1))
        {
            throw new ArgumentException("Cluster matrix must be square.", nameof(cluster));
        }

        if (cluster.GetLength(0) < 1 || cluster.GetLength(0) > MaxGridSize)
        {
            throw new ArgumentOutOfRangeException(nameof(cluster), $"Cluster size must be between 1 and {MaxGridSize}.");
        }

        if (sourceVertex < 0 || sourceVertex >= cluster.GetLength(0))
        {
            throw new ArgumentOutOfRangeException(nameof(sourceVertex), "Source vertex is outside the cluster.");
        }

        foreach (var capacity in cluster)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacities must be zero or positive.", nameof(cluster));
            }
        }
    }

    private static int[,] Clone(int[,] matrix)
    {
        var copy = new int[matrix.GetLength(0), matrix.GetLength(1)];

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                copy[i, j] = matrix[i, j];
            }
        }

        return copy;
    }
}
