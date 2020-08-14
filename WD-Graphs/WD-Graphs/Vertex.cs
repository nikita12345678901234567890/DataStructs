using System;
using System.Collections.Generic;
using System.Text;

namespace WD_Graphs
{
    class Vertex<T> where T : IComparable
    {
        public T value;
        public List<Edge<T>> Neighbors;

        public Vertex(T Value)
        {
            Neighbors = new List<Edge<T>>();
            value = Value;
        }
    }
}