using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class Vertex<T> : IComparable<Vertex<T>>
    {
        public T value;
        public List<Edge<T>> Neighbors;
        public bool visited;
        public double startDistance;
        public double endDistance;
        public bool open = true;
        public Vertex<T> founder;

        public Vertex(T Value)
        {
            Neighbors = new List<Edge<T>>();
            value = Value;
        }

        public int CompareTo(Vertex<T> other)
        {
            return startDistance.CompareTo(other.startDistance);
        }
    }
}