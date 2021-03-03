using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingVisualizer
{
    class Node : Sprite, IComparable<Node>
    {
        public bool Visited;
        public double Distance;
        public double FinalDistance;
        public Node Founder = null;
        public Point index;

        public Node(Texture2D texture, Vector2 position, Vector2 scale, Vector2 origin, Point index)
            : base(texture, position, scale, origin)
        {
            this.index = index;
        }

        public int CompareTo(Node other)
        {
            return Distance.CompareTo(other.Distance);
        }

        public void Reset()
        {
            Visited = false;
            Distance = double.PositiveInfinity;
            Founder = null;
        }
    }
}
