using System;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("GraphData.txt");

            Graph<string> graph = new Graph<string>();
            graph.AddVertex("PDX");
            graph.AddVertex("SMF");
            graph.AddVertex("SEA");
            graph.AddVertex("MSP");
            graph.AddVertex("DTW");
            graph.AddVertex("MDW");
            graph.AddVertex("IND");
            graph.AddVertex("SFO");
            graph.AddVertex("LAS");
            graph.AddVertex("DEN");
            graph.AddVertex("MKC");
            graph.AddVertex("STL");
            graph.AddVertex("CVG");
            graph.AddVertex("LAX");
            graph.AddVertex("PHX");
            graph.AddVertex("ABQ");
            graph.AddVertex("DFW");
            graph.AddVertex("HOU");
            graph.AddVertex("JFK");
            graph.AddVertex("SAN");
            graph.AddVertex("ELP");
            graph.AddVertex("SAT");
            graph.AddVertex("PHL");
            graph.AddVertex("DCA");

            graph.Close("SAT");
            graph.Close("ELP");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(',');
                graph.AddEdge(line[0], line[1], double.Parse(line[2]));
            }

            var yaat = graph.Dijkstras("STL", "LAX");
            var yeet = graph.Dijkstras("PDX", "DCA");
            var yiit = graph.Dijkstras("CVG", "DTW");
            var yoot = graph.Dijkstras("PHL", "IND");
            var yuut = graph.Dijkstras("MDW", "SMF");

            foreach (var thing in yaat)
            {
                Console.Write($"{thing}->");
            }
            Console.WriteLine();
            foreach (var thing in yeet)
            {
                Console.Write($"{thing}->");
            }
            Console.WriteLine();
            foreach (var thing in yiit)
            {
                Console.Write($"{thing}->");
            }
            Console.WriteLine();
            foreach (var thing in yoot)
            {
                Console.Write($"{thing}->");
            }
            Console.WriteLine();
            foreach (var thing in yuut)
            {
                Console.Write($"{thing}->");
            }
            Console.WriteLine();
            ;
        }
    }
}