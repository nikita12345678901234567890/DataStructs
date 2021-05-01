using System;
using System.Linq;
using System.Threading;
using RedBlackTree;

namespace RedBlackTreeVisualizer
{
    class Program
    {
        //┴ ┐ ─ ┌ ┘ └
        static void Main(string[] args)
        {
            Random rnd = new Random();

            var tree = new LeftLeaningRedBlackTree<int>();
            Node<int>[] items;
            int[] array = { 10, 20, 30, 40, 50, 25 };
            for (int i = 0; i < array.Length/*50*/; i++)
            {
                //tree.Add(rnd.Next(1, 10));
                tree.Add(array[i]);
                items = tree.PreOrderNode().ToArray();
                Console.Clear();
                Display(items);

                Thread.Sleep(250);
            }

            tree.Remove(50);
            items = tree.PreOrderNode().ToArray();
            Console.Clear();
            Display(items);

            Console.ReadKey();
        }

        static void Display(Node<int>[] items)
        {
            int index = 0;
            int maxLevel = 6 * 2;

            display(0, Console.BufferWidth, 0);

            void display(int start, int end, int level)
            {
                if (level == maxLevel || index >= items.Length)
                {
                    return;
                }

                int center = (start + end) / 2;

                if (!items[index].IsBlack)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.SetCursorPosition(center, level);
                Console.Write(items[index].Value);

                Console.SetCursorPosition(center, level + 1);

                Console.ForegroundColor = ConsoleColor.Gray;

                int current = index;

                #region Fancy Display
                if (items[index].Left != null && items[index].Right != null)
                {
                    Console.Write('┴');
                }
                else if (items[index].Left != null)
                {
                    Console.Write("┘");
                }
                else if (items[index].Right != null)
                {
                    Console.Write("└");
                }

                if (items[index].Left != null)
                {
                    Console.CursorLeft = (start + center) / 2;

                    if (!items[index].Left.IsBlack)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write("┌");

                    for (int i = Console.CursorLeft; i < center; i++)
                    {
                        Console.Write("─");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (items[index].Right != null)
                {
                    if (!items[index].Right.IsBlack)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.CursorLeft = center + 1;

                    for (int i = Console.CursorLeft; i < (end + center) / 2; i++)
                    {
                        Console.Write("─");
                    }

                    Console.Write("┐");

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                #endregion

                if (items[index].Left == null && items[index].Right == null)
                {
                    index++;
                    return;
                }

                index++;
                level += 2;

                if (items[current].Left != null)
                {
                    display(start, center, level);
                }

                if (items[current].Right != null)
                {
                    display(center, end, level);
                }
            }
        }
    }    
}
