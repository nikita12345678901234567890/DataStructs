using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingVisualizer
{
    public static class Extensions
    {
        public static void DrawLine(this SpriteBatch spriteBatch, Texture2D pixel, Line line, int thickness, Color color)
        {
            Vector2 scale = new Vector2(line.Length, thickness);

            spriteBatch.Draw(pixel, line.Start, null, color, line.Angle, Vector2.Zero, scale, SpriteEffects.None, 0f);       
        }
    }
}
