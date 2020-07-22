using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tries
{
    class Tire
    {
        Node root;

        public Tire()
        {
            root = new Node('|');
        }
        public void Clear()
        {
            root.Children.Clear();
        }

        public void Insert(string word)
        {
            Node fish = root;
            var Word = word.ToCharArray();

            for (int i = 0; i < Word.Length; i++)
            {
                if (fish.Children.ContainsKey(Word[i]))
                {
                    fish = fish.Children[Word[i]];
                }
                else
                {
                    fish.Children.Add(Word[i], new Node(Word[i]));
                }
            }
        }

        public bool Contains(string word)
        { 
            
        }

        private Node Search(string word)
        { 
            
        }

        public List<string> GetAllMatchingPrefix(string prefix)
        {

        }

        public bool Remove(string prefix)
        { 
            
        }
    }
}
