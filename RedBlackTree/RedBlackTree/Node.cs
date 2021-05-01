using System;
using System.Collections.Generic;
using System.Text;

namespace RedBlackTree
{
    public class Node<T>
    {
        public T value;
        public Node<T> Parent;
        public Node<T> LChild;
        public Node<T> RChild;
        public bool IsRed;

        public int ChildCount
        {
            get
            {
                int count = 0;

                if (LChild != null)
                {
                    count++;
                }

                if (RChild != null)
                {
                    count++;
                }

                return count;
            }
        }

        public bool IsLeftChild
        {
            get
            {
                if (Parent != null && Parent.LChild == this)
                {
                    return true;
                }

                return false;
            }
        }

        public Node(T value, bool IsRed)
        {
            this.value = value;
            Parent = null;
            LChild = null;
            RChild = null;
            this.IsRed = IsRed;
        }
    }
}