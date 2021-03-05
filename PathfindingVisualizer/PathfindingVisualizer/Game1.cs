﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

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
        //Part 3 of A*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
                    grid[y, x] = new Node(square, new Vector2(0 + (x * size), 0 + (y * size)), scale, Vector2.Zero, new Point(x, y));
                }
            }

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            start = new Vector2(5, 10);
            end = new Vector2(15, 10);

            Astar(start.ToPoint(), end.ToPoint(), false);

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
                    double tentative = temp.Distance + 1;

                    if (tentative < Neighbors[i].Distance)
                    {
                        Neighbors[i].Distance = tentative;
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


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var ms = Mouse.GetState();

            int indexX = (ms.X / grid[0, 0].HitBox.Width);
            int indexY = (ms.Y / grid[0, 0].HitBox.Height);

            mousecell = convert(indexX, indexY);

            Window.Title = $"X:{indexX}, Y:{indexY}";


            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        //make a function that takes in (indexY, indexX) and return position
        Point convert(float indexX, float indexY)
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

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j].Draw(spriteBatch);
                }
            }

            spriteBatch.Draw(pixel, new Rectangle(mousecell.X, mousecell.Y, grid[0, 0].HitBox.Width - 3, grid[0, 0].HitBox.Height - 3), Color.Yellow);

            var position = convert((int)start.X, (int)start.Y);
            spriteBatch.Draw(pixel, new Rectangle(position.X, position.Y, grid[0, 0].HitBox.Width - 3, grid[0, 0].HitBox.Height - 3), Color.Green);

            position = convert((int)end.X, (int)end.Y);
            spriteBatch.Draw(pixel, new Rectangle(position.X, position.Y, grid[0, 0].HitBox.Width - 3, grid[0, 0].HitBox.Height - 3), Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
