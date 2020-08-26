using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace Pathfinding
{
    class Graph<T> where T : IComparable
    {
        private List<Vertex<T>> vertices;
        public IReadOnlyList<Vertex<T>> Vertices { get { return vertices; } }
        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
                List<Edge<T>> yeet = new List<Edge<T>>();
                for (int i = 0; i < vertices.Count; i++)
                {
                    foreach (var yoot in vertices[i].Neighbors)
                    {
                        yeet.Add(yoot);
                    }
                }
                return yeet;
            }
        }

        public Graph()
        {
            vertices = new List<Vertex<T>>();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex != null && vertex.Neighbors.Count == 0 && !vertices.Contains(vertex))
            {
                vertices.Add(vertex);
            }
        }

        public void AddVertex(T value)
            => AddVertex(new Vertex<T>(value));

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (Exist(vertex, vertex))
            {
                int yeet = vertex.Neighbors.Count;
                for (int i = 0; i < yeet; i++)
                {
                    RemoveEdge(vertex.Neighbors[0]);
                }
                for (int i = 0; i < Edges.Count; i++)
                {
                    if (Edges[i].EndingPoint == vertex)
                    {
                        RemoveEdge(Edges[i]);
                        i--;
                    }
                }
                return true;
            }
            return false;

        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b, double distance)
        {
            bool thing = false;
            foreach (var edge in Edges)
            {
                if (edge.StartingPoint == a && edge.EndingPoint == b && edge.Distance == distance)
                {
                    thing = true;
                }
            }
            if (Exist(a, b) && !thing)
            {
                a.Neighbors.Add(new Edge<T>(a, b, distance));
                return true;
            }
            return false;
        }

        public bool AddEdge(T a, T b, double distance)
        {
            var one = Search(a);
            var two = Search(b);
            return AddEdge(one, two, distance);
        }

        public void TwoWayEdge(Vertex<T> a, Vertex<T> b, double distance)
        {
            AddEdge(a, b, distance);
            AddEdge(b, a, distance);
        }

        public void TwoWayEdge(T a, T b, double distance)
        {
            TwoWayEdge(Search(a), Search(b), distance);
        }

        public bool RemoveEdge(Edge<T> edge)
        {
            var a = edge.StartingPoint;
            var b = edge.EndingPoint;
            if (Exist(a, b) && a.Neighbors.Contains(edge) && b.Neighbors.Contains(edge))
            {
                a.Neighbors.Remove(edge);
                b.Neighbors.Remove(edge);
                return true;
            }
            return false;
        }

        public Vertex<T> Search(T value)
        {
            int thing = -1;
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (vertices[i].value.Equals(value))
                {
                    thing = i;
                    break;
                }
            }

            return thing == -1 ? null : Vertices[thing];
        }

        public int IndexOf(Vertex<T> vertex)
        {
            int thing = -1;
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].Equals(vertex))
                {
                    thing = i;
                }
            }

            return thing;
        }

        public bool Exist(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null && vertices.Contains(a) && vertices.Contains(b))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<T> DepthFirst(Vertex<T> start, Vertex<T> end)
        {
            List<T> items = new List<T>();

            if (!Exist(start, end))
            {
                return items;
            }

            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                visited.Add(node);
                items.Add(node.value);

                if (node == end)
                {
                    break;
                }

                foreach (var neighbor in node.Neighbors)
                {
                    if (!visited.Contains(neighbor.EndingPoint))
                    {
                        stack.Push(neighbor.EndingPoint);
                    }
                }

            }



            return items;
        }

        public IEnumerable<T> DepthFirst(T start, T end)
        {
            return DepthFirst(Search(start), Search(end));
        }
        public IEnumerable<T> BreathFirst(T start, T end)
        {
            return BreathFirst(Search(start), Search(end));
        }

        public IEnumerable<T> BreathFirst(Vertex<T> start, Vertex<T> end)
        {
            List<T> items = new List<T>();

            if (!Exist(start, end))
            {
                return items;
            }

            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                visited.Add(node);
                items.Add(node.value);

                if (node == end)
                {
                    break;
                }

                foreach (var neighbor in node.Neighbors)
                {
                    if (!visited.Contains(neighbor.EndingPoint))
                    {
                        queue.Enqueue(neighbor.EndingPoint);
                    }
                }

            }
            return items;
        }

        public IEnumerable<T> Dijkstras(T start, T end)
        {
            return Dijkstras(Search(start), Search(end));
        }

        public IEnumerable<T> Dijkstras(Vertex<T> start, Vertex<T> end)
        {
            //1.
            foreach (Vertex<T> vertex in Vertices)
            {
                vertex.visited = false;
                vertex.distance = double.PositiveInfinity;
                vertex.founder = null;
            }

            //2.
            start.distance = 0;//!
            TreeHeap<Vertex<T>> heap = new TreeHeap<Vertex<T>>(true);
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
                    double tentative = yeet.distance + neighbor.Distance;
                    if (tentative < neighbor.EndingPoint.distance)
                    {
                        neighbor.EndingPoint.distance = tentative;
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

            //7.
            Stack<T> yuut = new Stack<T>();
            var yoot = end;
            while (yoot != start)
            {
                yuut.Push(yoot.value);
                yoot = yoot.founder;
            }
            yuut.Push(start.value);
            return yuut;
        }
    }
}