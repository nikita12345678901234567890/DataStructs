using System;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache<int, string> cache = new LRUCache<int, string>(10);

            Random random = new Random();

            for (int i = 0; i < cache.max; i++)
            {
                int thing = random.Next(0, 100);
                cache.Put(thing, thing.ToString());
            }

            for (int i = 0; i < 100; i++)
            {
                string thing;
                bool thingy = cache.TryGetValue(i, out thing);
                Console.WriteLine(i.ToString() + "\t" + thing + "\t" + thingy);
            }
            ;
        }
    }
}