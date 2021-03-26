using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiffteenPuzzleGame
{
    class Game25
    {
        int gridSize = 4;
        public Tile[,] grid;
        Random random;

        public double distance;
        public double finalDistance;
        public Game25 founder;
        public bool visited;
       
        public Game25(GraphicsDeviceManager graphics, Random random, Texture2D square, Texture2D tile, SpriteFont font)
        {
            this.random = random;

            grid = new Tile[gridSize, gridSize];
            int size = (graphics.PreferredBackBufferWidth / grid.GetLength(1));
            Vector2 scale = new Vector2(size / (float)square.Width, size / (float)square.Height);

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    int number = (y * 4) + x + 1;

                    bool isEmpty = y == gridSize - 1 && x == gridSize - 1;

                    Texture2D texture = isEmpty ? square : tile;
                    Color tint = isEmpty ? Color.White : Color.Gray;

                    grid[y, x] = new Tile(texture, Vector2.Zero, scale, Vector2.Zero, new Point(x, y), tint, isEmpty, number, font);
                }
            }
        }

        public void update(MouseState ms, MouseState lastMouseState)
        {

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

                moveTile(currentTile);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            //Draw grid:
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    grid[y, x].Draw(spriteBatch);
                }
            }
        }
        void randomizeGrid(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                var moves = getMoves();

                int move = random.Next(moves.Count);

                moveTile(moves[move]);
            }
        }
        List<Tile> getMoves()
        {
            List<Tile> list = new List<Tile>();
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    if (GetEmptyCell(grid[y, x]) != null)
                    {
                        list.Add(grid[y, x]);
                    }
                }
            }
            return list;
        }
        void moveTile(Tile currentTile)
        {
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



        public void reset()
        {
            visited = false;
            distance = double.PositiveInfinity;
            finalDistance = double.PositiveInfinity;
            founder = null;
        }
    }
}
