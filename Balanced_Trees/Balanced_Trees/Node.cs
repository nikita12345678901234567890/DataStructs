using System;
using System.Collections.Generic;
using System.Text;

namespace Balanced_Trees
{
    public class Node<T>
    {
        public T value;
        public Node<T> Parent;
        public Node<T> LChild;
        public Node<T> RChild;

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

        public int Height
        {
            get
            {
                if (ChildCount == 0)
                {
                    return 1;
                }

                int lH = 0;
                int rH = 0;
                if (LChild != null)
                {
                    lH = LChild.Height;
                }
                if (RChild != null)
                {
                    rH = RChild.Height;
                }

                if (lH > rH)
                {
                    return lH + 1;
                }
                else
                {
                    return rH + 1;
                }
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

        public Node(T value)
        {
            this.value = value;
            Parent = null;
            LChild = null;
            RChild = null;
        }
    }
}