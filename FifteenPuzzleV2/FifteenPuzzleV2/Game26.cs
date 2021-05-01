using System;
using System.Collections.Generic;
using System.Text;

namespace FifteenPuzzleV2
{
    public class Game26
    {
        public int gridSizeX = StaticVariables.gridSizeX;
        public int gridSizeY = StaticVariables.gridSizeY;

        public int[,] grid;

        public double distance;
        public double finalDistance;
        public Game26 founder;

        int EmptyCell;
        public Game26()
        {
            EmptyCell = gridSizeX * gridSizeY;
        }

        public void randomizeGrid(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                var moves = getMoves();

                int move = StaticVariables.Random.Next(moves.Count);

                moveTile(moves[move].x, moves[move].y);
            }
        }

        public List<(int x, int y)> getMoves()
        {
            List<(int x, int y)> list = new List<(int x, int y)>();
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    if (GetEmptyCell(x, y) != (-1, -1))
                    {
                        list.Add((x, y));
                    }
                }
            }
            return list;
        }

        public void moveTile(int x, int y)
        {
            var neighbor = GetEmptyCell(x, y);

            var temp2 = grid[y, x];
            grid[y, x] = grid[neighbor.y, neighbor.x];
            grid[neighbor.y, neighbor.x] = temp2;
        }

        bool inBounds(int x, int y)
        {
            return x >= 0 && x < grid.GetLength(1) && y >= 0 && y < grid.GetLength(0);
        }

        (int x, int y) GetEmptyCell(int cellx, int celly)
        {
            for (int y = celly - 1; y <= celly + 1; y++)
            {
                for (int x = cellx - 1; x <= cellx + 1; x++)
                {
                    if (cellx != x && celly != y) continue;

                    if ((cellx == x && celly == y) || !inBounds(x, y))
                    {
                        continue;
                    }

                    if (grid[y, x] == EmptyCell)
                    {
                        return (x, y);
                    }
                }
            }

            return (-1, -1);
        }
        public void reset()
        {
            distance = double.PositiveInfinity;
            finalDistance = double.PositiveInfinity;
            founder = null;
        }

        public Game26 Copy()
        {
            Game26 copy = new Game26();

            copy.grid = new int[gridSizeY, gridSizeX];

            Array.Copy(grid, copy.grid, grid.Length);
            return copy;
        }

        public void MatchGrid(Game25 game)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int x = 0; x < gridSizeX; x++)
                {
                    grid[y, x] = game.grid[y, x].number;
                }
            }
        }
    }
}
