using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzleV2
{
    class TextLabel
    {
        public string text;
        public SpriteFont font;
        public Vector2 position;

        public TextLabel(string text, SpriteFont font, Vector2 position)
        {
            this.text = text;
            this.font = font;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.Black);
        }
    }
}
