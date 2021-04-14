using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiffteenPuzzleGame
{
    public class Tile : Sprite
    {
        public Point index;
        public bool empty;

        public int number;

        public SpriteFont font;

        public override Vector2 Position => new Vector2(0 + (index.X * texture.Width * scale.X), 0 + (index.Y * texture.Height * scale.Y));

        public Tile(Texture2D texture, Vector2 scale, Vector2 origin, Point index, Color color, bool empty, int number, SpriteFont font)
            : base(texture, Vector2.Zero, scale, origin, color)
        {
            this.index = index;
            this.empty = empty;
            this.number = number;
            this.font = font;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (empty) return;

            var text = number.ToString();
            var textSize = font.MeasureString(text);

            //logic for drawing number:
            Vector2 pos = (Position + ((texture.Width * scale) / 2)) - (textSize / 2);

            spriteBatch.DrawString(font, text, pos, Color.Black);

        }
    }
}
