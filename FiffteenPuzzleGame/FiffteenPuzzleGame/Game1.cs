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

        Random random = new Random();

        int gridSize = 4;
        Tile[,] grid;

        Point mousecell;

        Texture2D pixel;

        KeyboardState lastKeyboardState;

        MouseState lastMouseState;
        Point lastMouseCell;

        Texture2D square;
        Texture2D tile;

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

            grid = new Tile[gridSize, gridSize];

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            tile = Content.Load<Texture2D>("tile");
            square = Content.Load<Texture2D>("Box");

            int size = (graphics.PreferredBackBufferWidth / grid.GetLength(1));
            Vector2 scale = new Vector2(size / (float)square.Width, size / (float)square.Height);

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    if (y == gridSize - 1 && x == gridSize - 1)
                    {
                        grid[y, x] = new Tile(square, Vector2.Zero, scale, Vector2.Zero, new Point(x, y), Color.CornflowerBlue, true);
                    }
                    else
                    {
                        grid[y, x] = new Tile(tile, Vector2.Zero, scale, Vector2.Zero, new Point(x, y), Color.CornflowerBlue, false);
                    }
                }
            }
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

            var ms = Mouse.GetState();
            var kb = Keyboard.GetState();

            //Get the grid index the mouse is in:
            int indexX = (ms.X / grid[0, 0].HitBox.Width);
            int indexY = (ms.Y / grid[0, 0].HitBox.Height);
            Vector2 mouseIndex = new Vector2(indexX, indexY);


            if (ms.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
            {
                Tile currentTile = null;
                for (int y = 0; y < gridSize; y++)
                {
                    for (int x = 0; x < gridSize; x++)
                    {
                        if (x == mouseIndex.X && y == mouseIndex.Y)
                        {
                            currentTile = grid[y, x];

                            y = gridSize;
                            break;
                        }
                    }
                }

                if (currentTile == null) return;

                Tile neighbor = GetEmptyCell(currentTile);

                if (neighbor == null) return;

                var temp = currentTile.index;
                currentTile.index = neighbor.index;
                neighbor.index = temp;

                var temp2 = grid[currentTile.index.Y, currentTile.index.X];
                grid[currentTile.index.Y, currentTile.index.X] = grid[neighbor.index.Y, neighbor.index.X];
                grid[neighbor.index.Y, neighbor.index.X] = temp2;
            }



            lastKeyboardState = kb;
            lastMouseState = ms;
            lastMouseCell = new Point(indexX, indexY);

            base.Update(gameTime);
        }

        bool inBounds(int x, int y)
        {
            return x >= 0 && x < grid.GetLength(1) && y >= 0 && y < grid.GetLength(0);
        }
        Tile GetEmptyCell(Tile node)
        {
            for (int y = node.index.Y - 1; y <= node.index.Y + 1; y++)
            {
                for (int x = node.index.X - 1; x <= node.index.X + 1; x++)
                {
                    if ((node.index.X != x && node.index.Y != y)) continue;

                    if ((node.index.X == x && node.index.Y == y) || !inBounds(x, y))
                    {
                        continue;
                    }

                    if (grid[y, x].empty)
                    {
                        return grid[y, x];
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Draw grid:
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    grid[y, x].Draw(spriteBatch);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
