using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RedBlackTree
{
    class Tree<T> where T : IComparable<T>
    {
        public int count = 0;
        public Node<T> Root;
        private Node<T> Counter;
        private Node<T> Counter2;
        public Tree()
        {

        }

        public bool Search(T value)
        {
            Counter = Root;
            while (Counter != null && !Counter.value.Equals(value))
            {
                if (Counter.value.CompareTo(value) > 0)
                {
                    Counter = Counter.LChild;
                }
                if (Counter.value.CompareTo(value) < 0)
                {
                    Counter = Counter.RChild;
                }
            }

            if (Counter == null)
            {
                return false;
            }
            return true;
        }

        public T Minimum(T value)
        {
            Counter = Root;
            while (!Counter.value.Equals(value))
            {
                if (Counter.value.CompareTo(value) > 0)
                {
                    Counter = Counter.LChild;
                }
                if (Counter.value.CompareTo(value) < 0)
                {
                    Counter = Counter.RChild;
                }
            }

            while (Counter.LChild != null)
            {
                Counter = Counter.LChild;
            }

            return Counter.value;
        }

        public T Maximum(T value)
        {
            Counter = Root;
            while (!Counter.value.Equals(value))
            {
                if (Counter.value.CompareTo(value) > 0)
                {
                    Counter = Counter.LChild;
                }
                if (Counter.value.CompareTo(value) < 0)
                {
                    Counter = Counter.RChild;
                }
            }

            while (Counter.RChild != null)
            {
                Counter = Counter.RChild;
            }

            return Counter.value;
        }

        public void Insert(T value)
        {
            count++;

            if (Root == null)
            {
                Root = new Node<T>(value, false);
                return;
            }

            Counter = Root;

            while (Counter != null)
            {
                if (Counter.ChildCount == 2 && Counter.LChild.IsRed && Counter.RChild.IsRed)
                {
                    FlipColor(Counter);
                }

                if (value.CompareTo(Counter.value) < 0)
                {
                    if (Counter.LChild == null)
                    {
                        Counter.LChild = new Node<T>(value, true);
                        Counter.LChild.Parent = Counter;
                        break;
                    }
                    Counter = Counter.LChild;
                }
                else
                {
                    if (Counter.RChild == null)
                    {

                        Counter.RChild = new Node<T>(value, true);
                        Counter.RChild.Parent = Counter;
                        break;
                    }
                    Counter = Counter.RChild;
                }
            }

            for (int i = 0; i < count * 2 && Counter != null; i++)
            {
                if (Counter.ChildCount == 2 && Counter.LChild.IsRed && Counter.RChild.IsRed)
                {
                    FlipColor(Counter);
                }
                if (Counter.RChild != null && Counter.RChild.IsRed)
                {
                    LRotate(Counter);
                }
                if (Counter.LChild != null && Counter.LChild.IsRed && Counter.LChild.LChild != null && Counter.LChild.LChild.IsRed)
                {
                    RRotate(Counter);
                }

                Counter = Counter.Parent;
            }
        }

        public void Delete(T value)
        {
            count--;
            if (Root == null)
            {
                return;
            }
            if (!Search(value))
            {
                return;
            }

            Counter = Root;
            for (int i = 0; i < count && Counter != null; i++)
            {
                if (Counter.value.CompareTo(value) > 0)
                {
                    if (Counter.LChild != null)
                    {
                        Counter = Counter.LChild;

                        if (Counter.LChild != null && Counter.LChild.LChild != null && !Counter.LChild.IsRed && !Counter.LChild.LChild.IsRed)
                        {
                            MoveRedLeft(Counter);
                        }
                    }
                }

                else if (Counter.value.CompareTo(value) <= 0)
                {
                    if (Counter.LChild != null && Counter.LChild.IsRed)
                    {
                        RRotate(Counter);
                    }

                    if (Counter.value.Equals(value))
                    {
                        if (Counter.ChildCount == 0)
                        {
                            if (Counter.IsLeftChild)
                            {
                                Counter.Parent.LChild = null;
                                break;
                            }
                            else
                            {
                                Counter.Parent.RChild = null;
                                break;
                            }
                        }
                        else
                        {
                            if (Counter.ChildCount == 2)
                            {
                                if (Counter.RChild.LChild.ChildCount == 0 && Counter.RChild.RChild.ChildCount == 0)
                                {
                                    MoveRedRight(Counter);
                                }
                            }
                            else if (Counter.ChildCount == 1)
                            {
                                if (Counter.RChild.LChild != null && Counter.RChild.LChild.ChildCount == 0)
                                {
                                    MoveRedRight(Counter);
                                }
                                if (Counter.RChild.RChild != null && Counter.RChild.RChild.ChildCount == 0)
                                {
                                    MoveRedRight(Counter);
                                }
                            }


                            Counter2 = Counter.RChild;
                            while (Counter2.LChild != null)
                            {
                                Counter2 = Counter2.LChild;
                            }

                        }
                    }

                    if (Counter.value.CompareTo(value) < 0)
                    {
                        if (Counter.ChildCount == 2)
                        {
                            if (Counter.RChild.ChildCount == 2 && Counter.RChild.LChild.ChildCount == 0 && Counter.RChild.RChild.ChildCount == 0)
                            {
                                MoveRedRight(Counter);
                            }
                        }
                        else if (Counter.ChildCount == 1)
                        {
                            if (Counter.RChild != null && Counter.RChild.LChild != null && Counter.RChild.LChild.ChildCount == 0)
                            {
                                MoveRedRight(Counter);
                            }
                            if (Counter.RChild != null && Counter.RChild.RChild != null && Counter.RChild.RChild.ChildCount == 0)
                            {
                                MoveRedRight(Counter);
                            }
                        }
                        Counter = Counter.RChild;
                    }
                }
            }

            while (Counter != null)
            {
                Fixup(Counter);
                if (Counter != null)
                {
                    Counter = Counter.Parent;
                }
            }
        }

        private void LRotate(Node<T> node)
        {
            Node<T> newStart = node.RChild;
            newStart.Parent = node.Parent;

            if (node.Parent == null)
            {
                Root = newStart;
            }
            else
            {
                if (node.IsLeftChild)
                {
                    newStart.Parent.LChild = newStart;
                }
                else
                {
                    newStart.Parent.RChild = newStart;
                }
            }

            node.Parent = newStart;
            node.RChild = newStart.LChild;
            if (node.RChild != null)
            {
                node.RChild.Parent = node;
            }
            newStart.LChild = node;

            newStart.IsRed = !newStart.IsRed;
            newStart.LChild.IsRed = !newStart.LChild.IsRed;
        }

        private void RRotate(Node<T> node)
        {
            Node<T> newStart = node.LChild;
            newStart.Parent = node.Parent;

            if (node.Parent == null)
            {
                Root = newStart;
            }
            else
            {
                if (node.IsLeftChild)
                {
                    node.Parent.LChild = newStart;
                }
                else
                {
                    node.Parent.RChild = newStart;
                }
            }

            node.Parent = newStart;
            node.LChild = newStart.RChild;
            if (node.LChild != null)
            {
                node.LChild.Parent = node;
            }
            newStart.RChild = node;

            newStart.IsRed = !newStart.IsRed;
            newStart.RChild.IsRed = !newStart.RChild.IsRed;
        }

        private void FlipColor(Node<T> node)
        {
            node.IsRed = !node.IsRed;
            if (node.LChild != null)
            {
                if (node.IsRed && node.LChild.IsRed)
                {
                    node.LChild.IsRed = !node.LChild.IsRed;
                }
            }
            if (node.RChild != null)
            {
                if (node.IsRed && node.RChild.IsRed)
                {
                    node.RChild.IsRed = !node.RChild.IsRed;
                }
            }

            if (Root.IsRed == true)
            {
                Root.IsRed = false;
            }
        }

        private void MoveRedRight(Node<T> node)
        {

            if (node.LChild.LChild != null && !node.LChild.LChild.IsRed)
            {
                FlipColor(node);
            }
            else
            {
                RRotate(node);
                FlipColor(node.Parent);
            }
        }

        private void MoveRedLeft(Node<T> node)
        {
            FlipColor(node);

            if (node.RChild.LChild.IsRed)
            {
                RRotate(node.RChild);
                LRotate(node);
                FlipColor(node.Parent);
            }
        }

        private void Fixup(Node<T> node)
        {
            if (node.RChild != null && node.RChild.IsRed)
            {
                LRotate(node);
                RRotate(Root);
                RRotate(Root.RChild);
                return;
            }

            if (node.LChild != null && node.LChild.LChild != null && node.LChild.IsRed && node.LChild.LChild.IsRed)
            {
                RRotate(node);
                Counter = node.Parent;
            }

            if (node.LChild != null && node.RChild != null && node.LChild.IsRed && node.RChild.IsRed)
            {
                FlipColor(node);
            }

            if ((node.LChild != null && node.LChild.ChildCount == 2) && node.LChild.RChild.IsRed && !node.LChild.LChild.IsRed)
            {
                RRotate(node.LChild);
                Counter = node.Parent;

                if (Counter.LChild.IsRed)
                {
                    RRotate(Counter);
                }
            }
        }

    }
}