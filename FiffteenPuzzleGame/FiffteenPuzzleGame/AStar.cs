using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiffteenPuzzleGame
{
    public static class AStar
    {
        public static Stack<Game25> SolvePuzzle(Game25 start, int[,] endNumbers)
        {
            Tile[,] end = new Tile[endNumbers.GetLength(0), endNumbers.GetLength(1)];
            for (int y = 0; y < end.GetLength(0); y++)
            {
                for (int x = 0; x < end.GetLength(1); x++)
                {
                    end[y, x] = new Tile(null, Vector2.Zero, Vector2.Zero, Point.Zero, Color.White, endNumbers[y, x] == 0, endNumbers[y, x], null);
                }
            }

            Comparison<Game25> comparison = new Comparison<Game25>((x, y) => x.finalDistance.CompareTo(y.finalDistance));
            HeapTree<Game25> heap = new HeapTree<Game25>(Comparer<Game25>.Create(comparison));

            //Initialize:
            start.reset();
            start.distance = 0;
            start.finalDistance = heuristic(start);
            heap.Insert(start);

            Game25 endGame = null;

            while (heap.Count > 0)
            {
                var current = heap.Pop();

                current.visited = true;

                if (AreEqual(current, end))
                {
                    endGame = current;
                    break;
                }

                List<Game25> neighbors = GetNeighbors(current);
                if(neighbors.Count == 0 || neighbors.Count > 4)
                {

                }


                for (int i = 0; i < neighbors.Count; i++)
                {
                    //final step to make this work is figure out a different condition on when to set founder;
                    double tentative = current.distance + 1;

                    if (tentative < neighbors[i].distance)
                    {
                        neighbors[i].distance = tentative;
                        neighbors[i].founder = current;
                        neighbors[i].finalDistance = neighbors[i].distance + heuristic(neighbors[i]);
                    }

                    if(neighbors[i].visited == false && heap.Contains(neighbors[i], Game25Equal) == false)
                    {
                        heap.Insert(neighbors[i]);
                    }
                }
            }

            Stack<Game25> result = new Stack<Game25>();

            while (endGame != null)
            {
                result.Push(endGame);
                endGame = endGame.founder;
            }

            return result;
        }

        public static double heuristic(Game25 game)
        {
            Dictionary<int, Point> map = new Dictionary<int, Point>();

            for (int i = 0; i < game.gridSize * game.gridSize; i++)
            {
                map[i + 1] = new Point((i % game.gridSize), (i / game.gridSize));
            }

            double number = 0;
            for (int x = 0; x < game.grid.GetLength(1); x++)
            {
                for (int y = 0; y < game.grid.GetLength(0); y++)
                {
                    var CurrentTile = game.grid[y, x];
                    double xDistance = Math.Abs(CurrentTile.index.X - map[CurrentTile.number].X);
                    double yDistance = Math.Abs(CurrentTile.index.Y - map[CurrentTile.number].Y);

                    number += xDistance + yDistance;
                }
            }

            return number;
        }

        public static List<Game25> GetNeighbors(Game25 current)
        {
            List<Game25> list = new List<Game25>();

            var moves = current.getMoves();

            if(moves.Count > 4)
            {

            }

            for (int i = 0; i < moves.Count; i++)
            {
                Game25 copy = current.Copy();

                //Find this tile in this other grid

                //Make a function that takes in a number and a grid and returns the tile that matches that number

                copy.moveTile(Match(moves[i].number, copy));

          //      copy.distance++;
                copy.visited = false;
                copy.finalDistance = double.PositiveInfinity;
                copy.distance = double.PositiveInfinity;

                list.Add(copy);
            }

            return list;
        }

        public static Tile Match(int number, Game25 game)
        {
            for (int x = 0; x < game.gridSize; x++)
            {
                for (int y = 0; y < game.gridSize; y++)
                {
                    if (game.grid[y, x].number == number)
                    {
                        return game.grid[y, x];
                    }
                }
            }
            return null;
        }

        public static bool AreEqual(Game25 node, Tile[,] correct)
        {
            for (int x = 0; x < node.gridSize; x++)
            {
                for (int y = 0; y < node.gridSize; y++)
                {
                    if (node.grid[y, x].number != correct[y, x].number)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool Game25Equal(Game25 a, Game25 b)
            => AreEqual(a, b.grid);
    }
}