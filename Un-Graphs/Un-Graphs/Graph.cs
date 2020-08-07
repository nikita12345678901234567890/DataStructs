using System;
using System.Collections.Generic;
using System.Text;

namespace Un_Graphs
{
    class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        void AddVertex(Vertex<T> vertex)
        {
            if (vertex != null && vertex.Neighbors.Count == 0 && !Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        bool RemoveVertex(Vertex<T> vertex)
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

        bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if (Exist(a, b))
            {
                a.Neighbors.Add(b);
                b.Neighbors.Add(a);
                return true;
            }
            return false;
        }

        bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (Exist(a, b) && a.Neighbors.Contains(b) && b.Neighbors.Contains(a))
            {
                a.Neighbors.Remove(b);
                b.Neighbors.Remove(a);
            }
        }

        Vertex<T> Search(T value)
        { 
            
        }

        int IndexOf(Vertex<T> vertex)
        { 
        
        }

        bool Exist(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null && Vertices.Contains(a) && Vertices.Contains(b))
            {
                return true;
            }
            return false;
        }

    }
}
