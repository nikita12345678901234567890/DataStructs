using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class Node<T>
    {
        public T value;
        public int height;
        public Node<T>[] Nexts;

        public Node(T value, int height)
        {
            this.value = value;
            this.height = height;
            Nexts = new Node<T>[height];
        }

        public Node(int height)
        {
            this.height = height;
            Nexts = new Node<T>[height];
        }

        public void IncrementHeight()
        {
            var temp = new Node<T>[height + 1];
            for (int i = 0; i < height; i++)
            {
                temp[i] = Nexts[i];
            }
            Nexts = temp;
        }
    }
}