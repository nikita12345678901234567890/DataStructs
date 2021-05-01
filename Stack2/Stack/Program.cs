using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stuck<bool> stuck = new Stuck<bool>();
            stuck.Push(false);
            stuck.Push(true);
            Console.WriteLine(stuck.Peek().ToString());
            stuck.Popopopopopopopopopopopopop();
            stuck.BigRedButton();
        }
    }
}