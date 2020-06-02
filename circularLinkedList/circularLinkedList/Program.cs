using System;

namespace circularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<int> list = new SortedList<int>();

            Random gen = new Random();

            for (int i = 0; i < 5; i++)
            {
                list.AddLast(gen.Next(1, 100));
            }


            //string input;
            //int number;
            //int index;
            //while (true)
            //{
            //    Console.WriteLine("a = addFirst, A = addLast, b = addBefore, B = addAfter, c = removeFirst, C = removeLast, cc = remove, d = getCount");
            //    input = Console.ReadLine();
            //    for (int i = 0; i < 3; i++)
            //    {
            //        Console.WriteLine();
            //    }

            //    if (input == "a")
            //    {
            //        Console.WriteLine("What do you want to add?");
            //        number = int.Parse(Console.ReadLine());
            //        list.AddFirst(number);
            //        Console.WriteLine("OK");
            //    }
            //    if (input == "A")
            //    {
            //        Console.WriteLine("What do you want to add?");
            //        number = int.Parse(Console.ReadLine());
            //        list.AddLast(number);
            //        Console.WriteLine("OK");
            //    }
            //    if (input == "b")
            //    {
            //        Console.WriteLine("What do you want to add?");
            //        number = int.Parse(Console.ReadLine());
            //        for (int i = 0; i < 3; i++)
            //        {
            //            Console.WriteLine();
            //        }
            //        Console.WriteLine("Before index:");
            //        index = int.Parse(Console.ReadLine());
            //        list.AddBefore(index, number);
            //        Console.WriteLine("OK");
            //    }
            //    if (input == "B")
            //    {
            //        Console.WriteLine("What do you want to add?");
            //        number = int.Parse(Console.ReadLine());
            //        for (int i = 0; i < 3; i++)
            //        {
            //            Console.WriteLine();
            //        }
            //        Console.WriteLine("After index:");
            //        index = int.Parse(Console.ReadLine());
            //        list.AddAfter(index, number);
            //        Console.WriteLine("OK");
            //    }
            //    if (input == "c")
            //    {
            //        list.RemoveFirst();
            //        Console.WriteLine("OK");
            //    }
            //    if (input == "C")
            //    {
            //        list.RemoveLast();
            //        Console.WriteLine("OK");
            //    }
            //    if (input == "cc")
            //    {
            //        Console.WriteLine("What do you want to remove?");
            //        number = int.Parse(Console.ReadLine());
            //        list.Remove(number);
            //        Console.WriteLine("OK");
            //    }
            //    if (input == "d")
            //    {
            //        Console.WriteLine(list.count.ToString());
            //    }



            //    for (int i = 0; i < 5; i++)
            //    {
            //        Console.WriteLine();
            //    }
           // }
        }
    }
}