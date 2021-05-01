using Colorful;
using System;
using System.Drawing;
using Console = Colorful.Console;

namespace RedBlackTree
{
    class Program
    {
        static void Main(string[] args)
        {
            FigletFont font = FigletFont.Load("../../../doh.flf");
            Figlet figlet = new Figlet(font);


            Tree<int> tree = new Tree<int>();
            Random random = new Random();
            int[] array = {10, 20, 30, 40, 50, 25};

            for (int i = 0; i < array.Length; i++)
            {
                tree.Insert(array[i]);
                Console.WriteLine(figlet.ToAscii(array[i].ToString()), Color.DarkOrange);
            }



            tree.Delete(50);
            tree.Delete(1000);
        }
    }
}