using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiffteenPuzzleGame
{
    class Tile : Sprite
    {
        public Point index;
        public bool empty;

        public override Vector2 Position => new Vector2(0 + (index.X * texture.Width * scale.X), 0 + (index.Y * texture.Height * scale.Y));

        public Tile(Texture2D texture, Vector2 position, Vector2 scale, Vector2 origin, Point index, Color color, bool empty)
            : base(texture, position, scale, origin, color)
        {
            this.index = index;
            this.empty = empty;
        }
    }
}
