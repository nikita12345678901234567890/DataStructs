using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class Vertex<T> : IComparable where T : IComparable
    {
        public T value;
        public List<Edge<T>> Neighbors;
        public bool visited;
        public double distance;
        public Vertex<T> founder;

        public Vertex(T Value)
        {
            Neighbors = new List<Edge<T>>();
            value = Value;
        }

        public int CompareTo(object obj)
        {
            var temp = (Vertex<T>)obj;
            return distance.CompareTo(temp.distance);
        }
    }
}