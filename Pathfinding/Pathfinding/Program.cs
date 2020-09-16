using System;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dijkstras
            //string[] lines = File.ReadAllLines("GraphData.txt");

            //Graph<string> graph = new Graph<string>();
            //graph.AddVertex("PDX");
            //graph.AddVertex("SMF");
            //graph.AddVertex("SEA");
            //graph.AddVertex("MSP");
            //graph.AddVertex("DTW");
            //graph.AddVertex("MDW");
            //graph.AddVertex("IND");
            //graph.AddVertex("SFO");
            //graph.AddVertex("LAS");
            //graph.AddVertex("DEN");
            //graph.AddVertex("MKC");
            //graph.AddVertex("STL");
            //graph.AddVertex("CVG");
            //graph.AddVertex("LAX");
            //graph.AddVertex("PHX");
            //graph.AddVertex("ABQ");
            //graph.AddVertex("DFW");
            //graph.AddVertex("HOU");
            //graph.AddVertex("JFK");
            //graph.AddVertex("SAN");
            //graph.AddVertex("ELP");
            //graph.AddVertex("SAT");
            //graph.AddVertex("PHL");
            //graph.AddVertex("DCA");

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string[] line = lines[i].Split(',');
            //    graph.AddEdge(line[0], line[1], double.Parse(line[2]));
            //}
            //var yaat = graph.Dijkstras("PHL", "MDW");

            //foreach (var thing in yaat)
            //{
            //    Console.Write($"{thing}->");
            //}
            //Console.WriteLine();
            #endregion

            #region AStar
            //string[] mazeLines = System.IO.File.ReadAllLines("Maze.txt");

            ////4x2 loop
            //Graph<Point> aStarGraph = new Graph<Point>();
            //for(int i = 0; i <= 4; i++)
            //{
            //    for(int j = 0; j <= 2; j++)
            //    {
            //        aStarGraph.AddVertex(new Vertex<Point>(new Point(i, j)));
            //    }
            //}

            //foreach(var line in mazeLines)
            //{
            //    Point p1 = default;
            //    Point p2 = default;
            //    double weight = 0;
            //    int count = 0;
            //    List<int> vals = new List<int>();

            //    foreach(var character in line)
            //    {
            //        int value = (int)char.GetNumericValue(character);
            //        if (value == -1) continue;
            //        count++;
            //        vals.Add(value);

            //        if(count == 2)
            //        {
            //            p1 = new Point(vals[0], vals[1]);
            //        }
            //        else if(count == 4)
            //        {
            //            p2 = new Point(vals[2], vals[3]);
            //        }
            //        else if(count == 5)
            //        {
            //            weight = vals[4];
            //        }
            //    }
            //    aStarGraph.AddEdge(aStarGraph.Search(p1), aStarGraph.Search(p2), weight);
            //}

            //var yeet = AStar.aStar(new Point(2, 1), new Point(1, 1), aStarGraph);

            //foreach (var thing in yeet)
            //{
            //    Console.Write($"{thing}->");
            //}
            //Console.WriteLine();
            #endregion

            #region Bellman
            Graph<char> BellmanGraph = new Graph<char>();
            BellmanGraph.AddVertex('A');
            BellmanGraph.AddVertex('B');
            BellmanGraph.AddVertex('C');
            BellmanGraph.AddVertex('D');
            BellmanGraph.AddVertex('E');

            BellmanGraph.AddEdge('A', 'B', 2);
            BellmanGraph.AddEdge('B', 'D', 1);
            BellmanGraph.AddEdge('D', 'B', 1);
            BellmanGraph.AddEdge('B', 'C', 2);
            BellmanGraph.AddEdge('C', 'D', -4);
            BellmanGraph.AddEdge('D', 'E', 3);

            var yeet = BellmanGraph.Bellman('A', 'E');

            foreach (var thing in yeet)
            {
                Console.Write($"{thing}->");
            }
            Console.WriteLine();
            #endregion
            ;
        }
    }



    //Do Tuple Thingy next project         (int, bool) thing;

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
                            neighbor.EndingPoint.endDistance = tentative + Manhattan(neighbor.EndingPoint, end);
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

        public static IEnumerable<Point> aStarWithNewHeap(Point start, Point end, Graph<Point> graph)
        {
            return aStarWithNewHeap(graph.Search(start), graph.Search(end), graph);
        }

        public static IEnumerable<Point> aStarWithNewHeap(Vertex<Point> start, Vertex<Point> end, Graph<Point> graph)
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

           

            Comparison<Vertex<Point>> comparison = new Comparison<Vertex<Point>>((a, b) => a.UseEndDistance ? a.endDistance.CompareTo(b.endDistance) : a.startDistance.CompareTo(b.startDistance));
      
            Comparer<Vertex<Point>> comparer = Comparer<Vertex<Point>>.Create(comparison);

            Heap<Vertex<Point>> heap = new Heap<Vertex<Point>>(true, comparer);
            heap.Insert(start);
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
                            neighbor.EndingPoint.endDistance = tentative + Manhattan(neighbor.EndingPoint, end);
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