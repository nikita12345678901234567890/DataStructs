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
        int gridX = 0;
        int gridY = 0;

        TextLabel XLabel;
        TextLabel YLabel;

        List<Button> XButtons;
        List<Button> YButtons;
        SpriteFont font;

        Texture2D box;

        Button startButton;

        public MenuScreen(ContentManager content, GraphicsDeviceManager graphics) : base(content, graphics)
        {
            font = content.Load<SpriteFont>("SpriteFont");
            Texture2D ButtonTexture = content.Load<Texture2D>("Button");
            box = content.Load<Texture2D>("box");

            XButtons = new List<Button>();
            YButtons = new List<Button>();

            //logic for drawing labels:
            var textSizeX = font.MeasureString("X");
            var textSizeY = font.MeasureString("Y");

            Vector2 posX = new Vector2(100 + (ButtonTexture.Width * 2), 60);
            Vector2 posY = new Vector2(300 + (ButtonTexture.Width * 2), 60);

            XLabel = new TextLabel("X", font, posX);
            YLabel = new TextLabel("Y", font, posY);


            int spacing = 10;

            //Buttons for X:
            XButtons.Add(new Button("2", ButtonTexture, new Vector2(100, 100), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            XButtons.Add(new Button("3", ButtonTexture, new Vector2(XButtons[0].Position.X, XButtons[0].Position.Y + ((XButtons[0].HitBox.Height + spacing) * XButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            XButtons.Add(new Button("4", ButtonTexture, new Vector2(XButtons[0].Position.X, XButtons[0].Position.Y + ((XButtons[0].HitBox.Height + spacing) * XButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            XButtons.Add(new Button("5", ButtonTexture, new Vector2(XButtons[0].Position.X, XButtons[0].Position.Y + ((XButtons[0].HitBox.Height + spacing) * XButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            XButtons.Add(new Button("6", ButtonTexture, new Vector2(XButtons[0].Position.X, XButtons[0].Position.Y + ((XButtons[0].HitBox.Height + spacing) * XButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));

            //Buttons for Y:
            YButtons.Add(new Button("2", ButtonTexture, new Vector2(300, 100), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            YButtons.Add(new Button("3", ButtonTexture, new Vector2(YButtons[0].Position.X, YButtons[0].Position.Y + ((YButtons[0].HitBox.Height + spacing) * YButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            YButtons.Add(new Button("4", ButtonTexture, new Vector2(YButtons[0].Position.X, YButtons[0].Position.Y + ((YButtons[0].HitBox.Height + spacing) * YButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            YButtons.Add(new Button("5", ButtonTexture, new Vector2(YButtons[0].Position.X, YButtons[0].Position.Y + ((YButtons[0].HitBox.Height + spacing) * YButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));
            YButtons.Add(new Button("6", ButtonTexture, new Vector2(YButtons[0].Position.X, YButtons[0].Position.Y + ((YButtons[0].HitBox.Height + spacing) * YButtons.Count)), new Vector2(5, 5), new Vector2(0, 0), Color.White, font));

            startButton = new Button("Start", ButtonTexture, new Vector2(600, 25), new Vector2(7, 7), Vector2.Zero, Color.PaleVioletRed, font);
        }

        public override int Update(GameTime gameTime)
        {
            //Checking XButtons:
            foreach (Button button in XButtons)
            {
                if (button.isClicked(InputManager.MouseState, InputManager.LastMouseState) && int.Parse(button.text) * gridY < 20)
                {
                    if (gridX > 1)
                    {
                        XButtons[gridX - 2].color = Color.White;
                    }
                    gridX = int.Parse(button.text);
                    button.color = Color.SkyBlue;
                }
            }

            //Checking YButtons:
            foreach (Button button in YButtons)
            {
                if (button.isClicked(InputManager.MouseState, InputManager.LastMouseState) && int.Parse(button.text) * gridX < 20)
                {
                    if (gridY > 1)
                    {
                        YButtons[gridY - 2].color = Color.White;
                    }
                    gridY = int.Parse(button.text);
                    button.color = Color.SkyBlue;
                }
            }

            if (startButton.isClicked(InputManager.MouseState) && gridX > 0 && gridY > 0)
            {
                StaticVariables.gridSizeX = gridX;
                StaticVariables.gridSizeY = gridY;

                return 1;
            }

            base.Update(gameTime);

            return 0;
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

            XLabel.Draw(spriteBatch);
            YLabel.Draw(spriteBatch);

            //Drawing grid:
            Vector2 start = new Vector2(450, 450);
            float scale = (float)0.5;

            for (int x = 0; x < gridX; x++)
            {
                for (int y = 0; y < gridY; y++)
                {
                    Vector2 pos = new Vector2(start.X + (x * box.Width * scale), start.Y + (y * box.Height * scale));
                    spriteBatch.Draw(box, pos, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
                }
            }

            startButton.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
