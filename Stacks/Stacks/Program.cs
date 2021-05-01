using System;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int input;
            while (true)
            {
                Console.WriteLine("Doth thee wanteth to pusheth, popeth, 'r peek?   (1, 2, or 3)");
                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Console.WriteLine("What doth thee wanteth to pusheth?");
                    input = int.Parse(Console.ReadLine());
                    stack.Push(input);
                    Console.WriteLine("Thy numb'r hast been did push.");
                }

                else if (input == 2)
                {
                    if (stack.count == 0)
                    {
                        Console.WriteLine("The stack is exsufflicate!");
                    }
                    else
                    {
                        Console.WriteLine($"Thee has't popp'd: {stack.Pop()}");
                    }
                }

                else if (input == 3)
                {
                    if (stack.count == 0)
                    {
                        Console.WriteLine("The stack is exsufflicate!");
                    }
                    else
                    {
                        Console.WriteLine($"Thee has't peek'd: {stack.Peek()}");
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
