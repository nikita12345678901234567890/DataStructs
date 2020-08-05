using System;
using System.Collections.Generic;

namespace BloomFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            FilterBloom<int> BoomFilter = new FilterBloom<int>(100);
            List<int> yeet = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int yoot = random.Next(int.MinValue, 500);
                BoomFilter.Insert(yoot);
                if (i % 10 == 0)
                {
                    yeet.Add(yoot);
                }
            }
            for (int i = 0; i < yeet.Count; i++)
            {
                Console.WriteLine(BoomFilter.ProbablyContains(yeet[i]));
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(BoomFilter.ProbablyContains(500 + (i * 32)));
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine(BoomFilter.OofRate());

        }
    }
}