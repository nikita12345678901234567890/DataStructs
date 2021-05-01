using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tries
{
    class Node
    {
        public char letter;
        public Dictionary<char, Node> Children;
        public bool end;
        public Node parent;

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
        public Node(char letter, Node parent)
        {
            this.letter = letter;
            Children = new Dictionary<char, Node>();
            end = false;
            this.parent = parent;
        }
        public Node(char letter, bool end, Node parent)
        {
            this.letter = letter;
            Children = new Dictionary<char, Node>();
            this.end = end;
            this.parent = parent;
        }


        public override string ToString()
        {
            return $"Letter: {letter}, IsWord: {end}, Children: {string.Join(',', Children.Select(kvp => kvp.Key))}";
        }
    }
}
