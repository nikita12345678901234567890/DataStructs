using System;

namespace Balanced_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            Random random = new Random(2);
            int thing;

            for (int i = 0; i < 15; i++)
            {
                thing = random.Next(0, 100);
                tree.Insert(thing);
                Console.WriteLine(thing.ToString());
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            var array = tree.PreOrder();
            
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            tree.Delete(16);
            tree.Delete(77);
            tree.Delete(76);
            tree.Delete(51);
            tree.Delete(10);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            var array2 = tree.PreOrder();

            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
        }
    }
}