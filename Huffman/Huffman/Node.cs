using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Node
    {
        public char letter;
        public int frequency;

        public Node left;
        public Node right;
        public string code;

        public Node(char letter, int frequency)
        {
            this.letter = letter;
            this.frequency = frequency;
        }
    }
}
