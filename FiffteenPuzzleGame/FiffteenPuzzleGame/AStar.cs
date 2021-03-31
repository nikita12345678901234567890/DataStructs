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
        public static Stack<Game25> SolvePuzzle(Game25 start, int[,] end)
        {
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

                for (int i = 0; i < neighbors.Count; i++)
                {
                    double tentative = current.distance + 1;

                    if (tentative < neighbors[i].distance)
                    {
                        neighbors[i].distance = tentative;
                        neighbors[i].founder = current;
                        neighbors[i].finalDistance = neighbors[i].distance + heuristic(neighbors[i]);
                    }

                    if(heap.Contains(neighbors[i]) == false && neighbors[i].visited == false)
                    {
                        heap.Insert(neighbors[i]);
                    }
                }
            }

            Stack<Game25> result = new Stack<Game25>();

            while (!result.Contains(start))
            {
                result.Push(endGame);
                endGame = endGame.founder;
            }

            return result;
        }

        public static double heuristic(Game25 game)
        {
            Dictionary<int, Point> map = new Dictionary<int, Point>();

            for (int i = 1; i <= 16; i++)
            {
                map[i] = new Point((i % 4), (i / 4));
            }

            double number = 0;
            for (int x = 0; x < game.grid.GetLength(1); x++)
            {
                for (int y = 0; y < game.grid.GetLength(0); y++)
                {
                    var CurrentTile = game.grid[y, x];
                    double xDistance = Math.Abs(CurrentTile.Position.X - map[CurrentTile.number].X);
                    double yDistance = Math.Abs(CurrentTile.Position.Y - map[CurrentTile.number].Y);

                    number += Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2)); 
                }
            }

            return number;
        }

        public static List<Game25> GetNeighbors(Game25 current)
        {
            List<Game25> list = new List<Game25>();

            var moves = current.getMoves();
            for (int i = 0; i < moves.Count; i++)
            {
                Game25 copy = current.Copy();

                //Make sure to populate copy's astar stuff in here

                copy.moveTile(moves[i]);
                list.Add(copy);
            }

            return list;
        }

        public static bool AreEqual(Game25 node, int[,] correct)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (node.grid[y, x].number != correct[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}