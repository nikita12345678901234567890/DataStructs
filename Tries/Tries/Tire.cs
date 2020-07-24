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
                    if(i == Word.Length - 1)
                    {
                        fish.Children.Add(Word[i], new Node(Word[i], true, fish));
                        break;
                    }
                    fish.Children.Add(Word[i], new Node(Word[i], fish));
                    fish = fish.Children[Word[i]];
                }
            }
        }

        public bool Contains(string word)
        {
            var Word = word.ToCharArray();
            Node fish = root;
            for (int i = 0; i < Word.Length; i++)
            {
                if (fish.Children.ContainsKey(Word[i]))
                {
                    fish = fish.Children[Word[i]];
                }
                else if (fish.letter == Word[i] && fish.end)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private Node Search(string word)
        {
            var Word = word.ToCharArray();
            Node fish = root;
            for (int i = 0; i < Word.Length; i++)
            {
                if (fish.Children.ContainsKey(Word[i]))
                {
                    fish = fish.Children[Word[i]];
                }
                else
                {
                    return fish;
                }
            }
            return root;
        }

        public List<string> GetAllMatchingPrefix(string prefix)
        {
            List<string> yeet = new List<string>();
            Node fish = Search(prefix);
            
        }

        private void GitAllMatchingPrefix(Node fish, List<string> yeet, string prefix)
        {
            
        }

        public bool Remove(string prefix)
        {
            var Word = prefix.ToCharArray();
            Node fish = root;
            for (int i = 0; i < Word.Length; i++)
            {
                if (fish.Children.ContainsKey(Word[i]))
                {
                    fish = fish.Children[Word[i]];
                }
                else if (fish.letter == Word[i] && fish.end)
                {
                    fish.end = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}