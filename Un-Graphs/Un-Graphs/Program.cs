using System;

namespace Un_Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();
            for (int i = 1; i <= 10; i++)
            {
                graph.AddVertex(i);
            }

            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(1, 8);
            graph.AddEdge(8, 9);
            graph.AddEdge(9, 10);

            var yeet = graph.RecursiveDepthFirstSearch(graph.Search(1));

            foreach (var yoot in yeet)
            {
                Console.Write($"{yoot.value}->");
            }
        }
    }
}