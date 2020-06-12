using System;

namespace MergeSort2
{
    class Program
    {
        static T[] Yeet<T>(T[] array) where T : IComparable
        {
            if (array.Length <= 1)
            {
                return array;
            }
            T[] array1 = new T[array.Length / 2];
            T[] array2 = new T[array.Length - array1.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length / 2)
                {
                    array1[i] = array[i];
                }
                else
                {
                    array2[i - array1.Length] = array[i];
                }
            }
            var fish = Yeet<T>(array1);
            var fishy = Yeet<T>(array2);
            return Sort(fish, fishy);
        }

        static T[] Sort<T>(T[] one, T[] two) where T : IComparable
        {
            T[] array = new T[one.Length + two.Length];
            int j = 0;
            int ok = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (j < one.Length && ok < two.Length && one[j].CompareTo(two[ok]) < 0)
                {
                    array[i] = one[j];
                    j++;
                }
                else if (j < one.Length && ok < two.Length && one[j].CompareTo(two[ok]) >= 0)
                {
                    array[i] = two[ok];
                    ok++;
                }
                else if(j >= one.Length)
                {
                    array[i] = two[ok];
                    ok++;
                }
                else if (ok >= two.Length)
                {
                    array[i] = one[j];
                    j++;
                }
            }
            return array;
        }
        static void Main(string[] args)
        {
            int[] array = {5, 27, 1, 15, 19, 31, 48, -5, 2};
            int[] yeet = Yeet<int>(array);

            Console.WriteLine("Hello World!");
        }
    }
}
