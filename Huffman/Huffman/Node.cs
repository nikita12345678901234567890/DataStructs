using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Node
    {
        public char character;
        public int number;
        public Node Rchild;
        public Node Lchild;
        public Node parent;

        public Node(char character, int number)
        {
            this.character = character;
            this.number = number;
        }
    }
}
