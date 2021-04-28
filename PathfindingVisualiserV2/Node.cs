
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingVisualiserV2
{
    class Node : Sprite, IComparable<Node>
    {
        public bool Visited;
        public double Distance;
        public double FinalDistance;
        public Node Founder = null;
        public Point index;

        public bool Wall = false;

        public Node(Texture2D texture, Vector2 position, Vector2 scale, Vector2 origin, Point index, Color color)
            : base(texture, position, scale, origin, color)
        {
            this.index = index;
        }

        public int CompareTo(Node other)
        {
            return FinalDistance.CompareTo(other.FinalDistance);
        }

        public void Reset()
        {
            Visited = false;
            Distance = double.PositiveInfinity;
            Founder = null;
            FinalDistance = double.PositiveInfinity;
        }
    }
}
