using System;
using System.Collections.Generic;

namespace HeapTree
{
    class Person
    {
        public string name;
        public int priority;

        public Person(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeHeap2<int, Person> tree = new TreeHeap2<int, Person>(true);
            Random random = new Random(27);
            for (int i = 0; i < 20; i++)
            {
                var per = new Person(((char)random.Next(65, 91)).ToString(), random.Next(0, 1000));
                tree.Insert(per.priority, per);
            }
            ;
            for (int i = 0; i < 20; i++)
            {
                var thing = tree.Pop();
                Console.WriteLine(thing.priority.ToString() + "\t" + thing.name);
            }
            ;
        }
    }
}