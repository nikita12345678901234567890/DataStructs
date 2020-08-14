using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace WD_Graphs
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
            if (Exist(a, b) && !Edges.Contains(new Edge<T>(a, b, distance)))
            {
                a.Neighbors.Add(b);
                b.Neighbors.Add(a);
                return true;
            }
            return false;
        }

        public bool AddEdge(T a, T b)
        {
            var one = Search(a);
            var two = Search(b);
            return AddEdge(one, two);
        }

        public bool RemoveEdge(Edge<T> edge)
        {
            if (Exist(a, b) && a.Neighbors.Contains(b) && b.Neighbors.Contains(a))
            {
                a.Neighbors.Remove(b);
                b.Neighbors.Remove(a);
                return true;
            }
            return false;
        }

        public Vertex<T> Search(T value)
        { 
            int thing = -1;
            for(int i = 0; i < Vertices.Count; i++)
            {
                if(vertices[i].value.Equals(value))
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

        //public List<Vertex<T>> DepthFirst(Vertex<T> start)
        //{
        //    Stack<Vertex<T>> stuck = new Stack<Vertex<T>>();
        //    List<Vertex<T>> list = new List<Vertex<T>>();
        //    foreach (Vertex<T> vertex in vertices)
        //    {
        //        vertex.visited = false;
        //    }
        //    stuck.Push(start);



        //    while (stuck.Count > 0)
        //    {
        //        var curent = stuck.Pop();
        //        curent.visited = true;
        //        foreach (Vertex<T> vertex in curent.Neighbors)
        //        {
        //            if (!vertex.visited)
        //            {
        //                stuck.Push(vertex);
        //            }
        //        }
        //        list.Add(curent);
        //    }

        //    return list;
        //}

        //public List<Vertex<T>> RecursiveDepthFirstSearch(Vertex<T> start)
        //{
        //    List<Vertex<T>> list = new List<Vertex<T>>();
        //    foreach (Vertex<T> vertex in Vertices)
        //    {
        //        vertex.visited = false;
        //    }
          
        //    yeet(start, list);

        //    return list;
        //}
        //private void yeet(Vertex<T> current, List<Vertex<T>> list)
        //{
        //    if (current.Neighbors.Count == 0) return;

        //    list.Add(current);
        //    current.visited = true;
        //    for(int i = 0; i < current.Neighbors.Count; i++)
        //    {
        //        if (current.Neighbors[i].visited) continue;

        //        yeet(current.Neighbors[i], list);
        //    }
        //}


        //public List<Vertex<T>> BreadthFirst(Vertex<T> start)
        //{
        //    Queue<Vertex<T>> q = new Queue<Vertex<T>>();
        //    List<Vertex<T>> list = new List<Vertex<T>>();
        //    foreach (Vertex<T> vertex in Vertices)
        //    {
        //        vertex.visited = false;
        //    }
        //    q.Enqueue(start);

        //    while (q.Count > 0)
        //    {
        //        var curent = q.Dequeue();
        //        curent.visited = true;
        //        foreach (Vertex<T> vertex in curent.Neighbors)
        //        {
        //            if (!vertex.visited)
        //            {
        //                q.Enqueue(vertex);
        //            }
        //        }
        //        list.Add(curent);
        //    }

        //    return list;
        //}

    }
}