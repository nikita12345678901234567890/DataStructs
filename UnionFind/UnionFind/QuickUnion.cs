using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class QuickUnion : IUnionFind
    {
        //Do friends
        public int[] array { get; set; }

        public QuickUnion(int size)
        {
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            if (Connected(p, q))
            {
                return;
            }
            array[q] = p;
        }

        public int Find(int p)
        {
            int fish = p;
            int fishy = -666;
            while (true)
            {
                if (fish == fishy)
                {
                    return fish;
                }
                fishy = fish;
                fish = array[fish];
            }
        }

        public bool Connected(int p, int q)
        {
            if (Find(p) == Find(q))
            {
                return true;
            }
            return false;
        }

        public int Count()
        {
            return array.Length;
        }

        public List<List<int>> GetAllGroups()
        {
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < Count(); i++)
            {
                list.Add(new List<int>());
            }
            for (int i = 0; i < Count(); i++)
            {
                list[Find(array[i])].Add(array[i]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Count == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            return list;
        }
    }
}