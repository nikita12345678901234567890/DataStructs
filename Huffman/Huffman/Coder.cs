using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace Huffman
{
    class Coder
    {
        public Coder()
        {
            
        }


        //return a tuple of (string, Dictionary<char, string>) representing the encoded message and the table along with it
        public (string message, Dictionary<char, string> table) Encode(string text)
        {
            //Putting chars and frequencies into dictionary:
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


            //putting the tree into a dictionary:
            Dictionary<char, string> tree = new Dictionary<char, string>();

            Node Counter;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);


            while (queue.Count != 0)
            {
                Counter = queue.Dequeue();

                if (Counter != root && Counter.letter != '$')
                {
                    tree.Add(Counter.letter, Counter.code);
                }

                if (Counter.left != null)
                {
                    Counter.left.code = Counter.code + "0";
                    queue.Enqueue(Counter.left);
                }
                if (Counter.right != null)
                {
                    Counter.right.code = Counter.code + "1";
                    queue.Enqueue(Counter.right);
                }
            }

            //comverting the string into binary:
            string binary = "";

            StringBuilder binaryStringBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                foreach (var c in tree)
                {
                    if(text[i] == c.Key)
                    {
                        binaryStringBuilder.Append(c.Value);
                    }
                }
            }

            return (binaryStringBuilder.ToString(), tree);
        }

        public string Decode((string message, Dictionary<char, string> table) item)
        {
            string message = item.message;
            var table = item.table;

            StringBuilder text = new StringBuilder();

            StringBuilder thing = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                thing.Append(message[i]);

                foreach (var yeet in table)
                {
                    if (thing.ToString() == yeet.Value)
                    {
                        text.Append(yeet.Key);
                        thing.Clear();
                    }
                }
            }

            return text.ToString();
        }
    }
}