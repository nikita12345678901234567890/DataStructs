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


            Node start = new Node(Smallest(frequency), frequency[Smallest(frequency)]);
            frequency.Remove(Smallest(frequency));
            
            for (int i = 0; i < frequency.Count; i++)
            {
                
            }
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