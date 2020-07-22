using System;
using System.Collections.Generic;
using System.Text;

namespace Tries
{
    class Node
    {
        public char letter;
        public Dictionary<char, Node> Children;
        public bool end;

        public Node(char letter)
        {
            this.letter = letter;
            Children = new Dictionary<char, Node>();
            end = false;
        }
        public Node(char letter, bool end)
        {
            this.letter = letter;
            Children = new Dictionary<char, Node>();
            this.end = end;
        }
    }
}
