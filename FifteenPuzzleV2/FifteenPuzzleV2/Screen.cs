using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzleV2
{
    public abstract class Screen
    {
        public ContentManager content;
        public GraphicsDeviceManager graphics;

        List<Sprite> Sprites;

        public Screen(ContentManager content, GraphicsDeviceManager graphics)
        {
            this.content = content;
            this.graphics = graphics;

            Sprites = new List<Sprite>();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Sprite sprite in Sprites)
            {
                sprite.Update();
            }
        }
         
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }
    }
}
