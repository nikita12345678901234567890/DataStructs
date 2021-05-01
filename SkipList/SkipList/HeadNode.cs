using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class HeadNode<T>
    {
        public int Height
        {
            get
            {
                return Nexts.Count;
            }
            set
            {
                Height = value;

            }
        }
        public List<Node<T>> Nexts;

        public HeadNode(int height)
        {
            this.Height = height;
            Nexts = new List<Node<T>>();
        }
    }
}