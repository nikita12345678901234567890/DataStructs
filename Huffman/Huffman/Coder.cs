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
            //change all "NodeNode" to Node!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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


            var heap = new Heap<NodeNode>(new NodeNodeComparer());

            foreach (var kvp in frequency)
            {
                heap.Add(new NodeNode(kvp.Key, kvp.Value));
            }



            while (heap.Count > 1)
            {
                var big = heap.Pop();
                var smol = heap.Pop();
                var comb = new NodeNode('$', big.frequency + smol.frequency);
                comb.left = big;
                comb.right = smol;

                heap.Add(comb);
            }
            var root = heap.Pop();


            return "";
        }

        private char Smallest(Dictionary<char, int> dict)
        {
            var small = dict.ElementAt(0);
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict.ElementAt(i).Value < small.Value)
                {
                    small = dict.ElementAt(i);
                }
            }

            return small.Key;
        }
    }
}