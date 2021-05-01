using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int input;
            while (true)
            {
                Console.WriteLine("Doth thee wisheth to enqueue, dequeue, 'r peek?   (1, 2, or 3)");
                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Console.WriteLine("What doth thee wanteth to enqueue?");
                    input = int.Parse(Console.ReadLine());
                    queue.Enqueue(input);
                    Console.WriteLine("Thy numb'r hast been did enqueue.");
                }

                else if (input == 2)
                {
                    if (queue.count == 0)
                    {
                        Console.WriteLine("The stack is exsufflicate!");
                    }
                    else
                    {
                        Console.WriteLine($"Thee has't dequeue'd: {queue.Dequeue()}");
                    }
                }

                else if (input == 3)
                {
                    if (queue.count == 0)
                    {
                        Console.WriteLine("The stack is exsufflicate!");
                    }
                    else
                    {
                        Console.WriteLine($"Thee has't peek'd: {queue.Peek()}");
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
