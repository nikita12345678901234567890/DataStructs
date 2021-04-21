using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

namespace FiffteenPuzzleGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
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

        Stack<Game25> solution;

        TimeSpan elapsedTime = TimeSpan.Zero;
        TimeSpan delayTime = TimeSpan.FromMilliseconds(500);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            font = Content.Load<SpriteFont>("SpriteFont");

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            tile = Content.Load<Texture2D>("tile");
            square = Content.Load<Texture2D>("Box");


            var start = new Game26();
            start.grid = setupGrid(start.gridSizeX, start.gridSizeY);
            start.randomizeGrid(500);

            //Maintan

            Stack<Game26> result = BStar.SolvePuzzle(start, setupGrid(start.gridSizeX, start.gridSizeY));

            ;
            //solution = new Stack<Game25>();

            //while (result.Count > 0)
            //{
            //    Game25 yeet = new Game25(graphics, StaticVariables.Random, square, tile, font);

            //    var yoot = result.Pop();


            //    for (int y = 0; y < yoot.gridSizeY; y++)
            //    {
            //        for (int x = 0; x < yoot.gridSizeX; x++)
            //        {
            //            yeet.grid[y, x].number = yoot.grid[y, x];
            //        }
            //    }

            //    solution.Push(yeet);
            //}

            ;

            //      game = new Game25(graphics, random, square, tile, font);

            //      game.randomizeGrid(100);


        }



        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            elapsedTime += gameTime.ElapsedGameTime;

            if (solution != null && solution.Count != 0)
            {
                if (elapsedTime >= delayTime)
                {
                    game = solution.Pop();

                    elapsedTime = TimeSpan.Zero;
                }
            }

            KeyboardState kb = Keyboard.GetState();
            MouseState ms = Mouse.GetState();

            /*
            if (kb.IsKeyDown(Keys.Space))
            {

                solution = AStar.SolvePuzzle(game, setupGrid(game.gridSizeX, game.gridSizeY));
            }
            */

            //   game.update(ms, lastMouseState);

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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
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
