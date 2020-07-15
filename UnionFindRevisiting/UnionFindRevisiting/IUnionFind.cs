using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFindRevisiting
{
    interface IUnionFind<T>
    {
        T[] values { get; set; }
        int[] array { get; set; }

        void Union(T p, T q);

        int Find(T p);

        bool Connected(int p, int q);

        int Count();
    }
}