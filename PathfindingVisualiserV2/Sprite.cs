﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfindingVisualiserV2
{
    class Sprite
    {
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }
        public Vector2 origin { get; set; }
        public Vector2 scale { get; set; }
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)(texture.Width * scale.X), (int)(texture.Height * scale.Y));
            }
        }
        public float rotation { get; set; }
        public SpriteEffects effect { get; set; }
        public float layerDepth { get; set; }

        public Color color;

        public Sprite(Texture2D texture, Vector2 position, Vector2 scale, Vector2 origin, Color color)
        {
            this.texture = texture;
            this.origin = origin;

            this.position = position;
            this.scale = scale;
            this.color = color;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, origin, scale, effect, layerDepth);
        }
    }
}
