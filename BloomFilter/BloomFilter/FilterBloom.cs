using System;
using System.Collections.Generic;
using System.Text;

namespace BloomFilter
{
    class FilterBloom<T>
    {
        List<Func<T, int>> funcS;
        int M = 0;
        int N = 0;
        int K = 3;
        bool[] array;

        public FilterBloom(int cap)
        {
            M = cap;
            array = new bool[M];
            funcS = new List<Func<T, int>>();
            funcS.Add(HashFuncOne);
            funcS.Add(HashFuncTwo);
            funcS.Add(HashFuncThree);
        }

        public void LoadHashFunc(Func<T, int> hashFunc)
        {
            funcS.Add(hashFunc);
            K++;
        }

        public void Insert(T item)
        {
            for (int i = 0; i < K; i++)
            {
                array[Math.Abs(funcS[i](item)) % array.Length] = true;
            }
            N++;
        }

        public bool ProbablyContains(T item)
        {
            bool yoot = true;
            for (int i = 0; i < K; i++)
            {
                if (array[Math.Abs(funcS[i](item)) % array.Length] == false)
                {
                    return false;
                }
            }
            
            return yoot;
        }

        private int HashFuncOne(T item)
        {
            return item.GetHashCode();
        }

        private int HashFuncTwo(T item)
        {
            return HashFuncThree(item) + "tempString".GetHashCode();
        }

        private int HashFuncThree(T item)
        {
            return int.Parse(HashFuncOne(item).ToString()).GetHashCode();
        }
    }
}
