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
    public static class BStar
    {
        public static Stack<Game26> SolvePuzzle(Game26 start, int[,] end)
        {
            Dictionary<int, Point> map = new Dictionary<int, Point>();

            for (int i = 0; i < start.gridSizeX * start.gridSizeY; i++)
            {
                map[i + 1] = new Point((i % start.gridSizeX), (i / start.gridSizeY));
            }

            Game26[] visited = new Game26[10];
            int index = 0;

            Comparison<Game26> comparison = new Comparison<Game26>((x, y) => x.finalDistance.CompareTo(y.finalDistance));
            HeapTree<Game26> heap = new HeapTree<Game26>(Comparer<Game26>.Create(comparison));

            //Initialize:
            start.reset();
            start.distance = 0;
            start.finalDistance = heuristic(start, map);
            heap.Insert(start);

            Game26 endGame = null;

            while (heap.Count > 0)
            {
                var current = heap.Pop();

                visited[index] = current;
                index++;
                index %= visited.Length;

                if (AreEqual(current, end))
                {
                    endGame = current;
                    break;
                }

                List<Game26> neighbors = GetNeighbors(current);

                for (int i = 0; i < neighbors.Count; i++)
                {
                    //final step to make this work is figure out a different condition on when to set founder;
                    double tentative = current.distance + 1;

                    if (tentative < neighbors[i].distance)
                    {
                        neighbors[i].distance = tentative;
                        neighbors[i].founder = current;
                        neighbors[i].finalDistance = neighbors[i].distance + heuristic(neighbors[i], map);
                    }

                    bool iscontained = false;
                    foreach(var game in visited)
                    {
                        if (game == null) continue;

                        if(AreEqual(game, neighbors[i].grid))
                        {
                            iscontained = true;
                        }
                    }

                    if (!iscontained && !heap.Contains(neighbors[i], Game26Equal))
                    {
                        heap.Insert(neighbors[i]);
                    }
                }
            }

            Stack<Game26> result = new Stack<Game26>();

            while (endGame != null)
            {
                result.Push(endGame);
                endGame = endGame.founder;
            }

            return result;
        }

        public static double heuristic(Game26 game, Dictionary<int, Point> map)
        {
            double number = 0;
            for (int x = 0; x < game.gridSizeX; x++)
            {
                for (int y = 0; y < game.gridSizeY; y++)
                {
                    var CurrentNumber = game.grid[y, x];
                    double xDistance = Math.Abs(x - map[CurrentNumber].X);
                    double yDistance = Math.Abs(y - map[CurrentNumber].Y);

                    number += xDistance + yDistance;
                }
            }

            return number;
        }

        public static List<Game26> GetNeighbors(Game26 current)
        {
            List<Game26> list = new List<Game26>();

            var moves = current.getMoves();

            for (int i = 0; i < moves.Count; i++)
            {
                Game26 copy = current.Copy();

                copy.moveTile(moves[i].x, moves[i].y);

                copy.finalDistance = double.PositiveInfinity;
                copy.distance = double.PositiveInfinity;

                list.Add(copy);
            }

            return list;
        }

        public static bool AreEqual(Game26 node, int[,] correct)
        {
            for (int x = 0; x < node.gridSizeX; x++)
            {
                for (int y = 0; y < node.gridSizeY; y++)
                {
                    if (node.grid[y, x] != correct[y, x])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool Game26Equal(Game26 a, Game26 b)
            => AreEqual(a, b.grid);
    }
}