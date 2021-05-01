using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PathfindingVisualizer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Random random = new Random();

        Node[,] grid = new Node[20, 20];

        Point mousecell;

        Texture2D pixel;

        Vector2 end;
        Vector2 start;

        List<Sprite> highlightedSquares = new List<Sprite>();
        List<Line> lines = new List<Line>();

        KeyboardState lastKeyboardState;
      
        MouseState lastMouseState;
        Point lastMouseCell;

        bool startFollow = false;
        bool endFollow = false;
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
            // TODO: Add your initialization logic here

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

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            var square = Content.Load<Texture2D>("square");

            int size = (graphics.PreferredBackBufferWidth / grid.GetLength(1));
            Vector2 scale = new Vector2(size / (float)square.Width, size / (float)square.Height);

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    grid[y, x] = new Node(square, new Vector2(0 + (x * size), 0 + (y * size)), scale, Vector2.Zero, new Point(x, y), Color.CornflowerBlue);
                }
            }

            start = new Vector2(4, 2);
            end = new Vector2(15, 10);


            // TODO: use this.Content to load your game content here
        }

        //Make an A* function that returns a Stack<Point> which will represent the INDICIES to take to get to the end point
        //The A* function will take in a Point for start and a Point for ending representing the INDICIES
        public Stack<Point> Astar(Point start, Point end, bool includeDiagonals)
        {
            //Step 1:
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    grid[y, x].Reset();
                }
            }


            //Step 2:
            grid[start.Y, start.X].Distance = 0;
            grid[start.Y, start.X].FinalDistance = Manhattan(grid[start.Y, start.X], grid[end.Y, end.X]);
            HeapTree<Node> heapTree = new HeapTree<Node>(true);
            heapTree.Insert(grid[start.Y, start.X]);


            //Step 3:
            while (heapTree.Count > 0)
            {
                Node temp = heapTree.Pop();

                var Neighbors = neighbors(temp, includeDiagonals);
                for (int i = 0; i < Neighbors.Count; i++)
                {
                    if (Neighbors[i].Wall) continue;

                    double tentative = temp.Distance + Weight(temp, Neighbors[i]);

                    if (tentative < Neighbors[i].Distance)
                    {
                        Neighbors[i].Distance = tentative;
                        Neighbors[i].FinalDistance = tentative + Manhattan(Neighbors[i], grid[end.Y, end.X]);
                        Neighbors[i].Founder = temp;
                        Neighbors[i].Visited = false;
                    }

                    if (Neighbors[i].Visited == false && !heapTree.Contains(Neighbors[i]))
                    {
                        heapTree.Insert(Neighbors[i]);
                    }
                }
                temp.Visited = true;

                if (grid[end.Y, end.X].Visited)
                {
                    break;
                }


                //WE DO NOT NEED AN ACTUAL GRAPH CLASS
                //THE WAY WE WILL GET NEIGHBORS IS DYNAMICALLY

                //EVERYTIME U POP, YOU WILL HAVE A FUNCTION THAT TAKES IN A NODE
                //AND RETURNS A List<Node> which are its neighbors
            }

            //make a stack following from the end's founder back to the start
            Stack<Point> stack = new Stack<Point>();

            while (end != start)
            {
                stack.Push(new Point(end.X, end.Y));
                end = grid[end.Y, end.X].Founder.index;
            }

            stack.Push(start);

            return stack;
        }

        //Create a function that takes in two nodes and determines their relationship in terms of our NeighborType enum
        double Weight(Node node, Node neighbor)
        {
            if (node.index.X == neighbor.index.X || node.index.Y == neighbor.index.Y)
            {
                return 1;
            }
            return Math.Sqrt(2);
        }

        //HighlightSqures(List<Point> points)
        void HighlightSquares(List<Point> points)
        {
            for (int i = 1; i < points.Count - 1; i++)
            {
                var pos = convertToScreen(points[i].X, points[i].Y).ToVector2();
                highlightedSquares.Add(new Sprite(pixel, pos, new Vector2(grid[0, 0].HitBox.Width - 3), Vector2.Zero, Color.Yellow));
            }
        }

        int Manhattan(Node node, Node goal)
        {
            int dx = Math.Abs(node.index.X - goal.index.X);
            int dy = Math.Abs(node.index.Y - goal.index.Y);
            return (dx + dy);
        } //only for mo diagonals

        List<Node> neighbors(Node node, bool includeDiagonals)
        {
            List<Node> list = new List<Node>();
            for (int y = node.index.Y - 1; y <= node.index.Y + 1; y++)
            {
                for (int x = node.index.X - 1; x <= node.index.X + 1; x++)
                {
                    if ((node.index.X != x && node.index.Y != y) && includeDiagonals == false) continue;

                    if ((node.index.X == x && node.index.Y == y) || !inBounds(x, y))
                    {
                        continue;
                    }

                    list.Add(grid[y, x]);
                }
            }

            return list;
        }

        //write a function that takes in a location in the 2d array
        //return a boolean stating whether that position is in bounds or not
        bool inBounds(int x, int y)
        {
            return x >= 0 && x < grid.GetLength(1) && y >= 0 && y < grid.GetLength(0);
        }

        //takes in list of grid based points and gemerate lines between each pair of points:
        void GenerateLines(List<Point> points)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                var pos = convertToScreen(points[i].X, points[i].Y);
                var posOfNext = convertToScreen(points[i + 1].X, points[i + 1].Y);

                lines.Add(MakeLine(pos, posOfNext));
            }
        }

        //function that takes in to points on the grid and returns a line:
        Line MakeLine(Point start, Point end)
        {
            int offsetX = grid[0, 0].HitBox.Width / 2;
            int offsetY = grid[0, 0].HitBox.Height / 2;

            Vector2 Start = new Vector2(start.X + offsetX, start.Y + offsetY);
            Vector2 End = new Vector2(end.X + offsetX, end.Y + offsetY);

            return new Line(Start, End);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var ms = Mouse.GetState();

            if (ms.X < 0 || ms.X > GraphicsDevice.Viewport.Width || ms.Y < 0 || ms.Y > GraphicsDevice.Viewport.Height) return;
            
            
            var kb = Keyboard.GetState();

            //pathfind if space pressed:
            if(kb.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Up))
            {
                lines.Clear();
                var path = Astar(start.ToPoint(), end.ToPoint(), true);
                //HighlightSquares(path.ToList());
                GenerateLines(path.ToList());
            }
            
            //Get the grid index the mouse is in:
            int indexX = (ms.X / grid[0, 0].HitBox.Width);
            int indexY = (ms.Y / grid[0, 0].HitBox.Height);

            Vector2 mouseIndex = new Vector2(indexX, indexY);

            mousecell = convertToScreen(indexX, indexY);

            lastKeyboardState = kb;



            //move start:
            if (ms.LeftButton == ButtonState.Pressed && indexX == start.X && indexY == start.Y)
            {
                if (!endFollow)
                {
                    startFollow = true;
                }
            }

            if (startFollow && ms.X > 0 && ms.X < GraphicsDevice.Viewport.Width - grid[0, 0].HitBox.Width && ms.Y > 0 && ms.Y < GraphicsDevice.Viewport.Height - grid[0, 0].HitBox.Height)
            {
                start.X = indexX;
                start.Y = indexY;
            }

            if (ms.LeftButton == ButtonState.Released && startFollow)
            {
                startFollow = false;
            }

            //move end:
            if (ms.LeftButton == ButtonState.Pressed && indexX == end.X && indexY == end.Y)
            {
                if (!startFollow)
                {
                    endFollow = true;
                }
            }

            if (endFollow && ms.X > 0 && ms.X < GraphicsDevice.Viewport.Width - grid[0, 0].HitBox.Width && ms.Y > 0 && ms.Y < GraphicsDevice.Viewport.Height - grid[0, 0].HitBox.Height)
            {
                end.X = indexX;
                end.Y = indexY;
            }

            if (ms.LeftButton == ButtonState.Released && endFollow)
            {
                endFollow = false;
            }

            //Building a wall:

            bool firstCondition = ms.LeftButton == ButtonState.Pressed && mouseIndex.ToPoint() != lastMouseCell && mouseIndex != start && mouseIndex != end;
            bool secondCondition = ms.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released;

            if (firstCondition || secondCondition)
            {
                grid[indexY, indexX].Wall = !grid[indexY, indexX].Wall;
            }




            lastMouseState = ms;
            lastMouseCell = new Point(indexX, indexY);
            
            base.Update(gameTime);
        }

        //make a function that takes in (indexY, indexX) and return position
        Point convertToScreen(float indexX, float indexY)
        {
            return new Point((int)indexX * (grid[0, 0].HitBox.Width + 1) + 2, (int)indexY * (grid[0, 0].HitBox.Height + 1) + 2);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            //Draw grid:
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    if (grid[y, x].Wall)
                    {
                        grid[y, x].color = Color.Gray;
                    }
                    else
                    {
                        grid[y, x].color = Color.CornflowerBlue;
                    }
                    grid[y, x].Draw(spriteBatch);
                }
            }

            //Draw mouse square:
            spriteBatch.Draw(pixel, new Rectangle(mousecell.X, mousecell.Y, grid[0, 0].HitBox.Width - 3, grid[0, 0].HitBox.Height - 3), Color.Yellow);

            //Draw start:
            var position = convertToScreen((int)start.X, (int)start.Y);
            spriteBatch.Draw(pixel, new Rectangle(position.X, position.Y, grid[0, 0].HitBox.Width - 3, grid[0, 0].HitBox.Height - 3), Color.Green);

            //Draw end:
            position = convertToScreen((int)end.X, (int)end.Y);
            spriteBatch.Draw(pixel, new Rectangle(position.X, position.Y, grid[0, 0].HitBox.Width - 3, grid[0, 0].HitBox.Height - 3), Color.Red);

            //Draw highligted squares:
            //for (int i = 0; i < highlightedSquares.Count; i++)
            //{
            //    highlightedSquares[i].Draw(spriteBatch);
            //}

            foreach (var line in lines)
            {
                spriteBatch.DrawLine(pixel, line, 3, Color.Yellow);
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
