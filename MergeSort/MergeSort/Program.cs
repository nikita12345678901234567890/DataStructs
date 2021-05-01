using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {6, 8, 3, 9, 123, 64, 8, 4, 9, 43, 9};

            SortMerge<int> thing = new SortMerge<int>();

            array = thing.Sort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
        }
    }
}