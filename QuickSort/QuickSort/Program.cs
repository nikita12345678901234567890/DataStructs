using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            SortQuick<int> quick = new SortQuick<int>();
            int[] array = new int[7] { 7, 4, 3, 6, 2, 1, 5};
            array = quick.Sort2(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString() + ", ");
            }
        }
    }
}
