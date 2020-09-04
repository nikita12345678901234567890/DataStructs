using System;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Collections.Generic;

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

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(',');
                graph.AddEdge(line[0], line[1], double.Parse(line[2]));
            }

            var yaat = graph.Dijkstras("STL", "LAX");

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
            Graph<Point> graph2 = new Graph<Point>();

            graph2.AddVertex(new Point(1, 1));
            ;
        }
    }



    //Do TUple THingy nect project;

    class AStar
    {
        public static readonly (double, double) test;

        public static double Manhattan(Vertex<Point> node, Vertex<Point> goal)
        {
            double dx = Math.Abs(node.value.X - goal.value.X);
            double dy = Math.Abs(node.value.Y - goal.value.Y);
            return dx + dy;
        }

        public static double Euclidean(Vertex<Point> node, Vertex<Point> goal)
        {
            double dx = Math.Abs(node.value.X - goal.value.X);
            double dy = Math.Abs(node.value.Y - goal.value.Y);
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static IEnumerable<Point> aStar(Point start, Point end, Graph<Point> graph)
        {
            return aStar(graph.Search(start), graph.Search(end), graph);
        }

        public static IEnumerable<Point> aStar(Vertex<Point> start, Vertex<Point> end, Graph<Point> graph)
        {
            //1.
            foreach (Vertex<Point> vertex in graph.Vertices)
            {
                vertex.visited = false;
                vertex.startDistance = double.PositiveInfinity;
                vertex.endDistance = double.PositiveInfinity;
                vertex.founder = null;
                vertex.UseEndDistance = true;
            }

            //2.
            start.startDistance = 0;
            start.endDistance = Manhattan(start, end);
            TreeHeap<Vertex<Point>> heap = new TreeHeap<Vertex<Point>>(true);
            heap.Insert(start);
            ///////////////////////////////////////////////////////resume with step 3;
            //6.
            while (heap.Count > 0)
            {
                //3.
                var yeet = heap.Pop();
                yeet.visited = true;

                //4.
                foreach (var neighbor in yeet.Neighbors)
                {
                    if (neighbor.EndingPoint.open)
                    {
                        double tentative = yeet.startDistance + neighbor.Distance;
                        if (tentative < neighbor.EndingPoint.startDistance)
                        {
                            neighbor.EndingPoint.startDistance = tentative;
                            neighbor.EndingPoint.founder = yeet;
                            neighbor.EndingPoint.visited = false;
                        }

                        //5.
                        if (neighbor.EndingPoint.visited == false && !heap.Contains(neighbor.EndingPoint))
                        {
                            heap.Insert(neighbor.EndingPoint);
                        }
                    }
                }
            }

            //7.
            Stack<Point> yuut = new Stack<Point>();
            var yoot = end;
            while (yoot != start)
            {
                yuut.Push(yoot.value);
                yoot = yoot.founder;
            }
            yuut.Push(start.value);
            foreach (Vertex<Point> vertex in graph.Vertices)
            {
                vertex.UseEndDistance = false;
            }
            return yuut;
        }
    }
}