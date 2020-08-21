using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class Edge<T> where T : IComparable
    {
        public Vertex<T> StartingPoint;
        public Vertex<T> EndingPoint;
        public double Distance;

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, double distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;
        }
    }
}
