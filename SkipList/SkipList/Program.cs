using System;

namespace SkipList
{
    class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> list = new SkipList<int>();
            Random random = new Random(42);

            for (int i = 0; i < 10; i++)
            {
                list.Insert(random.Next(0, 100));
            }

            int[] array = list.Test();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(array[i].ToString());
            }

            list.Delete(12);
            list.Delete(14);
            list.Delete(16);
            list.Delete(17);
            list.Delete(26);
            list.Delete(51);
            list.Delete(52);
            list.Delete(66);
            list.Delete(72);
            list.Delete(76);
        }
    }
}