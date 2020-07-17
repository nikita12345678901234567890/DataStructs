using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFindRevisiting
{
    class QuickUnion<T> : IUnionFind<T> where T : IComparable
    {
        public T[] values { get; set; }
        public int[] array { get; set; }

        Dictionary<T, int> mapping;
        public QuickUnion(T[] values)
        {
            this.values = values;
            array = new int[Count()];
            for (int i = 0; i < Count(); i++)
            {
                array[i] = i;
            }
            mapping = new Dictionary<T, int>();

            int count = 0;
            foreach (var item in values)
            {
                mapping[item] = count;
                count++;
            }
        }

        public bool Connected(int p, int q)
        {
            if (array[p] == array[q])
            {
                return true;
            }
            return false;
        }

        public int Count()
        {
            return values.Length;
        }

        public int Find(T p)
        {
            //int pIndex;
            //try
            //{
            //    pIndex = mapping[p];
            //}
            //catch (KeyNotFoundException ex)
            //{
            //    return -1;
            //}

            bool result = mapping.TryGetValue(p, out int pIndex);

            if (!result)
            {
                return -1;
            }

            for (int i = 0; i < Count(); i++)
            {
                if (values[i].Equals(p))
                {
                    pIndex = i;
                }
                if (pIndex != -1)
                {
                    break;
                }
            }
            int yes;
            for (int i = pIndex; true; i = array[i])
            {
                if (array[i] == i)
                {
                    yes = i;
                    break;
                }
            }
            return yes;
        }

        public void Union(T p, T q)
        {
            int pIndex = -1;
            int qIndex = -1;
            for (int i = 0; i < Count(); i++)
            {
                if (values[i].Equals(p))
                {
                    pIndex = i;
                }
                if (values[i].Equals(q))
                {
                    qIndex = i;
                }
                if (pIndex != -1 && qIndex != -1)
                {
                    break;
                }
            }
            array[qIndex] = pIndex;
        }
    }
}