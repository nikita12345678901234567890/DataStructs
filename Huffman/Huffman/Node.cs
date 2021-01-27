using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    class Node
    {
        public char character;
        public Node Rchild;
        public Node Lchild;

        public Node(char character)
        {
            this.character = character;
        }
    }
}
