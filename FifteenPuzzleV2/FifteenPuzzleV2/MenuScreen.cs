using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzleV2
{
    public class MenuScreen : Screen
    {
        int gridX;
        int gridY;

        List<Button> XButtons;
        List<Button> YButtons;

        public MenuScreen(ContentManager content, GraphicsDeviceManager graphics) : base(content, graphics)
        {
            Texture2D ButtonTexture = content.Load<Texture2D>("button");
            XButtons.Add(new Button("text", ButtonTexture, new Vector2(100, 100), 1, ));
        }

        public override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button button in XButtons)
            {
                button.Draw(spriteBatch);
            }
            foreach (Button button in YButtons)
            {
                button.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }
    }
}
