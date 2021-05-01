using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    interface IUnionFind<T>
    {
        T[] array2 { get; set; }
        int[] array { get; set; }

        void Union(int p, int q);

        int Find(int p);

        bool Connected(int p, int q);

        int Count();
    }
}