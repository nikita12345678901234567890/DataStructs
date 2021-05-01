using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzleV2
{
    public class GameScreen : Screen
    {
        Point mousecell;

        Texture2D pixel;

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

        public GameScreen(ContentManager content, GraphicsDeviceManager graphics) : base(content, graphics)
        {
            font = content.Load<SpriteFont>("SpriteFont");

            pixel = new Texture2D(graphics.GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            tile = content.Load<Texture2D>("tile");
            square = content.Load<Texture2D>("Box");

            start = new Game26();
            start.grid = setupGrid(StaticVariables.gridSizeX, StaticVariables.gridSizeY);

            int sizex = (graphics.PreferredBackBufferWidth / start.grid.GetLength(1));
            int sizey = (graphics.PreferredBackBufferHeight / start.grid.GetLength(0));
            scale = new Vector2(sizex / (float)square.Width, sizey / (float)square.Height);

            game = new Game25(graphics, StaticVariables.Random, square, tile, font, start.grid, scale);
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

        public override int Update(GameTime gameTime)
        {
            Game1.WindowText = "Press R to randomize, press space to solve";

            elapsedTime += gameTime.ElapsedGameTime;

            //Visualizing solve:
            if (solution != null && solution.Count != 0)
            {
                Game1.WindowText = "Solving";

                if (elapsedTime >= delayTime)
                {
                    game = solution.Dequeue();

                    elapsedTime = TimeSpan.Zero;
                }
            }

            //Randomizing:
            if ((solution == null || solution.Count == 0) && (InputManager.KeyboardState.IsKeyDown(Keys.R) && InputManager.LastKeyboardState.IsKeyUp(Keys.R)))
            {
                start.MatchGrid(game);
                start.randomizeGrid(25);
                game.matchGrid(start.grid);
            }

            //Solving:
            if (InputManager.KeyboardState.IsKeyDown(Keys.Space) && (solution == null || solution.Count == 0))
            {
                Game1.WindowText = "Loading";

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

                Game1.WindowText = "";
            }

            if ((solution == null || solution.Count == 0))
            {
                game?.update(InputManager.MouseState, InputManager.LastMouseState);
            }

            InputManager.LastKeyboardState = InputManager.KeyboardState;
            InputManager.LastMouseState = InputManager.MouseState;

            base.Update(gameTime);

            return 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            game?.draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
