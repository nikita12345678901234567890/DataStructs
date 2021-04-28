using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzleV2
{
    public class Button : Sprite
    {
        Texture2D texture;
        bool isClicked = false;
        string text;

        public Button(string text, Texture2D texture, Vector2 position, Vector2 scale, Vector2 origin, Color color)
            :base(texture, position, scale, origin, color)
        {
            this.text = text;
        }
    }
}
