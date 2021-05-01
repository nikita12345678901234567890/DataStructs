using System;

namespace Linked_lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Listy<int> List = new Listy<int>();
            while (true)
            {
                Console.WriteLine("a = addFirst, A = addLast, b = addBefore, B = addAfter, c = removeFirst, C = removeLast");
                string choice = Console.ReadLine();
                if (choice == "a")
                {
                    Console.WriteLine("Vat zoes you vant to adds?");
                    List.addFirst(int.Parse(Console.ReadLine()));
                    Console.WriteLine("OK");
                }
                if (choice == "A")
                {
                    Console.WriteLine("Vat zoes you vant to adds?");
                    List.addLast(int.Parse(Console.ReadLine()));
                    Console.WriteLine("OK");
                }
                if (choice == "b")
                {
                    Console.WriteLine("Vat zoes you vant to adds?");
                    int value = int.Parse(Console.ReadLine());
                    Console.WriteLine("Before index:");
                    int index = int.Parse(Console.ReadLine());
                    List.addBefore(value, index);
                    Console.WriteLine("OK");
                }
                if (choice == "B")
                {
                    Console.WriteLine("Vat zoes you vant to adds?");
                    int value = int.Parse(Console.ReadLine());
                    Console.WriteLine("After index:");
                    int index = int.Parse(Console.ReadLine());
                    List.addAfter(value, index);
                    Console.WriteLine("OK");
                }
                if (choice == "c")
                {
                    List.removeFirst();
                    Console.WriteLine("OK");
                }
                if (choice == "C")
                {
                    List.removeLast();
                    Console.WriteLine("OK");
                }
                if (choice == "z")
                {
                    Console.WriteLine(List.IsCircular().ToString());
                }
                for(int i = 0; i < 5; i++)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
