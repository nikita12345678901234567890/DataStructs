using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

namespace FifteenPuzzleV2
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Point mousecell;

        Texture2D pixel;

        KeyboardState lastKeyboardState;

        MouseState lastMouseState;
        Point lastMouseCell;

        Texture2D square;
        Texture2D tile;


        SpriteFont font;

        Game25 game;
        Game26 start;

        Queue<Game25> solution;

        Vector2 scale;

        TimeSpan elapsedTime = TimeSpan.Zero;
        TimeSpan delayTime = TimeSpan.FromMilliseconds(500);

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


            font = Content.Load<SpriteFont>("SpriteFont");

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            tile = Content.Load<Texture2D>("tile");
            square = Content.Load<Texture2D>("Box");

            start = new Game26();
            start.grid = setupGrid(start.gridSizeX, start.gridSizeY);

            int sizex = (graphics.PreferredBackBufferWidth / start.grid.GetLength(1));
            int sizey = (graphics.PreferredBackBufferHeight / start.grid.GetLength(0));
            scale = new Vector2(sizex / (float)square.Width, sizey / (float)square.Height);

            game = new Game25(graphics, StaticVariables.Random, square, tile, font, start.grid, scale);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            elapsedTime += gameTime.ElapsedGameTime;

            if (solution != null && solution.Count != 0)
            {
                if (elapsedTime >= delayTime)
                {
                    game = solution.Dequeue();

                    elapsedTime = TimeSpan.Zero;
                }
            }

            KeyboardState kb = Keyboard.GetState();
            MouseState ms = Mouse.GetState();

            if ((solution == null || solution.Count == 0) && (kb.IsKeyDown(Keys.R) && lastKeyboardState.IsKeyUp(Keys.R)))
            {
                start.MatchGrid(game);
                start.randomizeGrid(25);
                game.matchGrid(start.grid);
            }

            if (kb.IsKeyDown(Keys.Space) && (solution == null || solution.Count == 0))
            {
                Window.Title = "Loading";
                start.MatchGrid(game);
                Stack<Game26> result = BStar.SolvePuzzle(start, setupGrid(start.gridSizeX, start.gridSizeY));

                solution = new Queue<Game25>();

                Game25 last = null;

                while (result.Count > 0)
                {
                    var yoot = result.Pop();

                    Game25 yeet = new Game25(graphics, StaticVariables.Random, square, tile, font, yoot.grid, scale);

                    solution.Enqueue(yeet);
                    last = yeet;
                }

                start.MatchGrid(last);

                Window.Title = "";
            }

            if ((solution == null || solution.Count == 0))
            {
                game?.update(ms, lastMouseState);
            }

            lastKeyboardState = kb;
            lastMouseState = ms;

            base.Update(gameTime);
        }

        int[,] setupGrid(int gridSizeX, int gridSizeY)
        {
            int counter = 1;
            int[,] array = new int[gridSizeY, gridSizeX];

            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    array[y, x] = counter;
                    counter++;
                }
            }

            return array;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            game?.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
