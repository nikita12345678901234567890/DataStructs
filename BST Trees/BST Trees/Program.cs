using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            string input;
            int value;

            while (true)
            {
                Console.WriteLine("I = insert, D = delete, m = minimum, M = maximum, S = search, PO = pre-order, IO = in-order, pO = post-order");

                input = Console.ReadLine();

                if (input == "I")
                {
                    Console.WriteLine("What doth thee wanteth to ins'rt?");
                    value = int.Parse(Console.ReadLine());
                    tree.Insert(value);
                    Console.WriteLine("OK");
                }

                if (input == "D")
                {
                    Console.WriteLine("What doth thee wanteth to fordid?");
                    value = int.Parse(Console.ReadLine());
                    tree.Delete(value);
                    Console.WriteLine("OK");
                }

                if (input == "m")
                {
                    Console.WriteLine("Of what sub-tree?");
                    value = int.Parse(Console.ReadLine());
                    Console.WriteLine(tree.Minimum(value).ToString());
                }

                if (input == "M")
                {
                    Console.WriteLine("Of what sub-tree?");
                    value = int.Parse(Console.ReadLine());
                    Console.WriteLine(tree.Maximum(value).ToString());
                }

                if (input == "S")
                {
                    Console.WriteLine("What doth thee wanteth to searcheth f'r?");
                    value = int.Parse(Console.ReadLine());
                    if (tree.Search(value))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("This value is somewh're in the tree.  If 't be true thee wanteth to knoweth its exact location, prithee payeth me $5.");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Err'r numb'r 666.");
                        Console.WriteLine("Eith'r this value is not in the tree, 'r thee oweth me wage.");
                        Console.WriteLine("Whatev'r the case, i suggesteth yond thee starteth running.");
                    }
                }

                if (input == "PO")
                {
                    Console.WriteLine("");
                    int[] array = new int[tree.PreOrder().Length];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = tree.PreOrder()[i];
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + ", ");
                    }
                }

                if (input == "IO")
                {
                    Console.WriteLine("");
                    int[] array = new int[tree.InOrder().Length];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = tree.InOrder()[i];
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + ", ");
                    }
                }

                if (input == "pO")
                {
                    Console.WriteLine("");
                    int[] array = new int[tree.PostOrder().Length];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = tree.PostOrder()[i];
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + ", ");
                    }
                }

                if (input == "z")
                {
                    tree.Insert(20);
                    tree.Insert(10);
                    tree.Insert(30);
                    tree.Insert(5);
                    tree.Insert(15);
                    tree.Insert(25);
                    tree.Insert(35);
                }




                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}
