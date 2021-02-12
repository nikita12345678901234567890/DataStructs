using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Huffman
{
    class IntComparer : Comparer<int>
    {
        public override int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if (x == y)
            {
                return 0;
            }
            else if (x < y)
            {
                return 1;
            }

            return -1;
        }
    }

    class NodeComparer : Comparer<Node>
    {
        public override int Compare([AllowNull] Node x, [AllowNull] Node y)
        {
            //return y.frequency.CompareTo(x.frequency);  // max heap
            return x.frequency.CompareTo(y.frequency);  // min heap
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*List<(int, string)> list = new List<(int, string)>();

            char start = 'a';
            for (int i = 0; i < 26; i++)
            {
                list.Add((i, start.ToString()));
                start++;
            }

            IntComparer comp = new IntComparer();

            Heap<int> heap = new Heap<int>(comp);

            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                heap.Add(random.Next(100));
            }


            var heap = new Heap<Node>(new NodeComparer());
            heap.Add(new Node('a', 5));
            heap.Add(new Node('z', 2));
            heap.Add(new Node('f', 8));
            heap.Add(new Node('c', 1));*/

            var coder = new Coder();

            Console.WriteLine(coder.Decode(coder.Encode("this is a test")));
        }
    }
}