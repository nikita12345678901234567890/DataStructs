using System;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("GraphData.txt");

            Graph<int> graph = new Graph<int>();
            for (int i = 1; i <= 10; i++)
            {
                graph.AddVertex(i);
            }

            graph.TwoWayEdge(1, 2, 1);
            graph.TwoWayEdge(2, 3, 1);
            graph.TwoWayEdge(3, 4, 1);
            graph.TwoWayEdge(1, 5, 1);
            graph.TwoWayEdge(5, 6, 1);
            graph.TwoWayEdge(6, 7, 1);
            graph.TwoWayEdge(1, 8, 1);
            graph.TwoWayEdge(8, 9, 1);
            graph.TwoWayEdge(9, 10, 1);
            graph.TwoWayEdge(2, 5, 2);
            graph.TwoWayEdge(5, 8, 2);
            graph.TwoWayEdge(3, 6, 2);
            graph.TwoWayEdge(6, 9, 2);
            graph.TwoWayEdge(4, 7, 2);
            graph.TwoWayEdge(7, 10, 2);
            graph.TwoWayEdge(2, 6, 3);
            graph.TwoWayEdge(3, 5, 3);
            graph.TwoWayEdge(5, 9, 3);
            graph.TwoWayEdge(6, 8, 3);
            graph.TwoWayEdge(3, 7, 3);
            graph.TwoWayEdge(4, 6, 3);
            graph.TwoWayEdge(6, 10, 3);
            graph.TwoWayEdge(7, 9, 3);

            var yeet = graph.Dijkstras(2, 7);

            foreach (var yoot in yeet)
            {
                Console.Write($"{yoot}->");
            }
            ;
        }
    }
}