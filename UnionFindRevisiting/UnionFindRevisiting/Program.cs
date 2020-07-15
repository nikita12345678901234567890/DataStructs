using System;
using System.Collections.Generic;

namespace UnionFindRevisiting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = {"Chandler", "Joey", "Phoebe", "Ross", "Monica", "Rachel", "Michael", "Jim", "Pam", "Dwight", "Kelly", "Ryan", "Creed"};
            QuickFind<string> find = new QuickFind<string>(values);

            find.Union("Chandler", "Joey");
            find.Union("Joey", "Pheobe");
            find.Union("Monica", "Rachel");
            find.Union("Chandler", "Ross");
            find.Union("Jim", "Pam");
            find.Union("Pam", "Dwight");
            find.Union("Michael", "Ryan");
            find.Union("Ryan", "Kelly");
            find.Union("Dwight", "Creed");
            find.Union("Joey", "Creed");

            if (find.Find("Peobe") == find.Find("Rachel"))
            {
                Console.WriteLine("Pheobe - Rachel = true");
            }
            else
            {
                Console.WriteLine("Pheobe - Rachel = false");
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


            //largest/smallest groups
            //List of all members in all groups.
        }
    }
}