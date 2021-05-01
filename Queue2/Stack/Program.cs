using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            fish<bool> stuck = new fish<bool>();
            stuck.Enqueue(false);
            stuck.Enqueue(true);
            Console.WriteLine(stuck.Peek().ToString());
            Console.WriteLine(stuck.Dequeue().ToString());
            Console.WriteLine(stuck.Dequeue().ToString());
            stuck.BigRedButton();
        }
    }
}