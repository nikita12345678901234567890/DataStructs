using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Huffman
{
    class Coder
    {
        public Coder()
        {
            
        }


        public string Encode(string text)
        {
            //This works, don't touch it:
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!frequency.ContainsKey(text[i]))
                {
                    frequency.Add(text[i], 1);
                }
                else
                {
                    frequency[text[i]]++;
                }
            }
            //end of working stuff


            var heap = new Heap<Node>(new NodeComparer());

            foreach (var kvp in frequency)
            {
                heap.Add(new Node(kvp.Key, kvp.Value));
            }


            //combining stuff
            while (heap.Count > 1)
            {
                //var big = heap.Pop(); //if using max heap
                //var smol = heap.Pop();

                var smol = heap.Pop(); //if using min heap
                var big = heap.Pop();

                var comb = new Node('$', big.frequency + smol.frequency);
                //comb.left = big; //if doing max heap
                //comb.right = smol;

                comb.right = big; //if doing min heap
                comb.left = smol;

                heap.Add(comb);
            }

            //tree:
            var root = heap.Pop();


            //making the tree into a string:
            string tree = "";

            Node Counter;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Counter = queue.Dequeue();

                //add to string
                //Do that line^!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (Counter.left != null)
                {
                    queue.Enqueue(Counter.left);
                }
                if (Counter.right != null)
                {
                    queue.Enqueue(Counter.right);
                }
            }

            return tree;
        }
    }
}