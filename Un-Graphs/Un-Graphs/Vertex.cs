using System;
using System.Collections.Generic;
using System.Text;

namespace Un_Graphs
{
    class Vertex<T>
    {
        public T value;
        public List<Vertex<T>> Neighbors;

        public Vertex(T value)
        {
            this.value = value;
            Neighbors = new List<Vertex<T>>();
        }
    }
}
