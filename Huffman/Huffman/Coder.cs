using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Coder
    {
        public Node Root;

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

            //make tree!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  
        }
    }
}
