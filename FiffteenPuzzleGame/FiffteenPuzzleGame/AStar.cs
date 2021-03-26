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
        public static Stack<Game25> SolvePuzzle(Game25 start, Game25 end)
        {
            Comparison<Game25> comparison = new Comparison<Game25>((x, y) => x.finalDistance.CompareTo(y.finalDistance));
            HeapTree<Game25> heap = new HeapTree<Game25>(Comparer<Game25>.Create(comparison));

            //Initialize:
            start.reset();
            start.distance = 0;
            start.finalDistance = heuristic(start, end);


            

            return null;
        }

        double heuristic(Game25 game)
        {
            Dictionary<int, Point> map = new Dictionary<int, Point>();

            for (int i = 0; i < 16; i++)
            {
                map[i] = new Point((i % 4), (i / 4));
            }

            for (int i = 0; i < 16; i++)
            {

            }
        }
    }
}
