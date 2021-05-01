using System;
using System.Collections.Generic;
using System.Linq;

namespace UnionFindRevisiting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = {"Chandler", "Joey", "Phoebe", "Ross", "Monica", "Rachel", "Michael", "Jim", "Pam", "Dwight", "Kelly", "Ryan", "Creed"};
            QuickFind<string> find = new QuickFind<string>(values);

            find.Union("Chandler", "Joey");
            find.Union("Joey", "Phoebe");
            find.Union("Monica", "Rachel");
            find.Union("Chandler", "Ross");
            find.Union("Jim", "Pam");
            find.Union("Pam", "Dwight");
            find.Union("Michael", "Ryan");
            find.Union("Ryan", "Kelly");
            find.Union("Dwight", "Creed");
            find.Union("Joey", "Creed");

            if (find.Find("Phoebe") == find.Find("Rachel"))
            {
                Console.WriteLine("Phoebe - Rachel = true");
            }
            else
            {
                Console.WriteLine("Phoebe - Rachel = false");
            }
            if (find.Find("Jim") == find.Find("Creed"))
            {
                Console.WriteLine("Jim - Creed = true");
            }
            else
            {
                Console.WriteLine("Jim - Creed = false");
            }
            if (find.Find("Michael") == find.Find("Pam"))
            {
                Console.WriteLine("Michael - Pam = true");
            }
            else
            {
                Console.WriteLine("Michael - Pam = false");
            }
            if (find.Find("Chandler") == find.Find("Creed"))
            {
                Console.WriteLine("Chandler - Creed = true");
            }
            else
            {
                Console.WriteLine("Chandler - Creed = false");
            }

            Dictionary<int, List<string>> list = new Dictionary<int, List<string>>();
            for (int i = 0; i < find.Count(); i++)
            {
                if (!list.ContainsKey(find.array[i]))
                {
                    list.Add(find.array[i], new List<string>());
                }
                list[find.array[i]].Add(find.values[i]);
            }

            Console.WriteLine("");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("");
                Console.WriteLine($"Group: {list.Keys.ToList<int>()[i]}");
                for (int j = 0; j < list[list.Keys.ToList<int>()[i]].Count; j++)
                {
                    Console.WriteLine($"\t{list[list.Keys.ToList<int>()[i]][j]}");
                }
            }
        }
    }
}