using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuikSort
{
    class Program
    {
        static List<T> Quik<T>(List<T> array) where T : IComparable
        {
            if (array.Count <= 1)
            {
                return array;
            }

            List<T> array1 = new List<T>();
            List<T> array2 = new List<T>();
            T pivot = array[0];
            int l = 0;
            int r = array.Count - 1;
            //foreach (T thing in array)
            //{
            //    if (thing.CompareTo(pivot) < 0)
            //    {
            //        array1.Add(thing);
            //    }
            //    else
            //    {
            //        array2.Add(thing);
            //    }
            //}

            while (true)
            {
                while (l < array.Count && array[l].CompareTo(pivot) < 0)
                {
                    l++;
                }
                while (r >= 0 && array[r].CompareTo(pivot) >= 0)
                {
                    r--;
                }
                if (l < r)
                {
                    var chris = array[l];
                    array[l] = array[r];
                    array[r] = chris;
                }
                else
                {
                    break;
                }
            }
            foreach (T t in array)
            {
                if (t.CompareTo(pivot) < 0)
                {
                    array1.Add(t);
                }
                else
                {
                    array2.Add(t);
                }
            }
            array1 = Quik(array1);
            array2 = Quik(array2);
            array.Clear();
            for (int i = 0; i < array1.Count + array2.Count; i++)
            {
                if (i < array1.Count)
                {
                    array.Add(array1[i]);
                }
                else
                {
                    array.Add(array2[i - array1.Count]);
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            List<int> array = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                array.Add(random.Next(1, 101));
                Console.WriteLine(array.Last().ToString());
            }
            var yeet = Quik<int>(array);
            foreach (int i in yeet)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("yeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeet");
        }
    }
}