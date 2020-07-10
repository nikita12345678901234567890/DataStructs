using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFindRevisiting
{
    class QuickFind<T> : IUnionFind<T> where T : IComparable
    {
        public T[] values { get; set; }
        public int[] array { get; set; }

        public QuickFind(T[] values)
        {
            this.values = values;
            array = new int[Count()];
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
            int index = -1;
            for (int i = 0; i < Count(); i++)
            {
                if (values[i].Equals(p))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("The number you are trying to reach has not been found, please don't try again.");
            }
            return array[index];
        }

        public void Union(T p, T q)
        {
            int pIndex = -1;
            int pGroup = -1;
            int qIndex = -1;
            int qGroup = -1;
            for (int i = 0; i < Count(); i++)
            {
                if (values[i].Equals(p))
                {
                    pIndex = i;
                    pGroup = array[i];
                }
                if (values[i].Equals(q))
                {
                    qIndex = i;
                    qGroup = array[i];
                }
                if (pIndex != -1 && qIndex != -1)
                {
                    break;
                }
            }
            for (int i = 0; i < Count(); i++)
            {
                if (array[i] == pGroup)
                {
                    array[i] = qGroup;
                }
            }
        }
    }
}
