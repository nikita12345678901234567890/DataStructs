using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace FifteenPuzzleV2
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static string WindowText;

        Dictionary<ScreenStates, Screen> screens;
        ScreenStates currentScreen = ScreenStates.Menu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screens = new Dictionary<ScreenStates, Screen>();
            screens.Add(ScreenStates.Menu, new MenuScreen(Content, graphics));
            screens.Add(ScreenStates.Game, new GameScreen(Content, graphics));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Window.Title = WindowText;

            InputManager.KeyboardState = Keyboard.GetState();
            InputManager.MouseState = Mouse.GetState();

            screens[currentScreen].Update(gameTime);

            InputManager.LastKeyboardState = InputManager.KeyboardState;
            InputManager.LastMouseState = InputManager.MouseState;

            base.Update(gameTime);
        }

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            screens[currentScreen].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
