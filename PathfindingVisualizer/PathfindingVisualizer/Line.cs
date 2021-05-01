using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingVisualizer
{
    public class Line
    {
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        public float Angle { get; }
        public float Length { get; }

        public Line(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;

            float deltaX = end.X - start.X;
            float deltaY = end.Y - start.Y;

            Angle = (float)Math.Atan2(deltaY, deltaX);
            Length = (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }
    }
}
