using System;
using System.Collections.Generic;
using System.Text;

namespace Un_Graphs
{
    class Graph<T> where T : IComparable
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex != null && vertex.Neighbors.Count == 0 && !Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        public void AddVertex(T value)
            => AddVertex(new Vertex<T>(value));

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (Exist(vertex, vertex))
            {
                foreach (var c in vertex.Neighbors)
                {
                    RemoveEdge(vertex, c);
                }
                Vertices.Remove(vertex);
                return true;
            }
            return false;
        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if (Exist(a, b))
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
        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
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
                if(Vertices[i].value.Equals(value))
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
            if (a != null && b != null && Vertices.Contains(a) && Vertices.Contains(b))
            {
                return true;
            }
            return false;
        }

        public List<Vertex<T>> DepthFirst(Vertex<T> start)
        {
            Stack<Vertex<T>> stuck = new Stack<Vertex<T>>();
            List<Vertex<T>> list = new List<Vertex<T>>();
            foreach (Vertex<T> vertex in Vertices)
            {
                vertex.visited = false;
            }
            stuck.Push(start);



            while (stuck.Count > 0)
            {
                var curent = stuck.Pop();
                curent.visited = true;
                foreach (Vertex<T> vertex in curent.Neighbors)
                {
                    if (!vertex.visited)
                    {
                        stuck.Push(vertex);
                    }
                }
                list.Add(curent);
            }

            return list;
        }

        public List<Vertex<T>> RecursiveDepthFirstSearch(Vertex<T> start)
        {
            List<Vertex<T>> list = new List<Vertex<T>>();
            foreach (Vertex<T> vertex in Vertices)
            {
                vertex.visited = false;
            }
          
            yeet(start, list);

            return list;
        }
        private void yeet(Vertex<T> current, List<Vertex<T>> list)
        {
            if (current.Neighbors.Count == 0) return;

            list.Add(current);
            current.visited = true;
            for(int i = 0; i < current.Neighbors.Count; i++)
            {
                if (current.Neighbors[i].visited) continue;

                yeet(current.Neighbors[i], list);
            }
        }


        public List<Vertex<T>> BreadthFirst(Vertex<T> start)
        {
            Queue<Vertex<T>> q = new Queue<Vertex<T>>();
            List<Vertex<T>> list = new List<Vertex<T>>();
            foreach (Vertex<T> vertex in Vertices)
            {
                vertex.visited = false;
            }
            q.Enqueue(start);

            while (q.Count > 0)
            {
                var curent = q.Dequeue();
                curent.visited = true;
                foreach (Vertex<T> vertex in curent.Neighbors)
                {
                    if (!vertex.visited)
                    {
                        q.Enqueue(vertex);
                    }
                }
                list.Add(curent);
            }

            return list;
        }

    }
}