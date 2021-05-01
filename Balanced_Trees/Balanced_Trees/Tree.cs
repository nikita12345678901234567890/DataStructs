using System;
using System.Collections.Generic;
using System.Text;

namespace Balanced_Trees
{
    class Tree<T> where T : IComparable<T>
    {
        public int count = 0;
        private int balance = 0;
        public Node<T> Root;
        private Node<T> Counter;
        private Node<T> Counter2;
        public Tree()
        {

        }


        public bool Search(T value)
        {
            Counter = Root;
            while (!Counter.value.Equals(value) && (Counter.RChild != null || Counter.LChild != null))
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

            if (Counter.value.Equals(value))
            {
                return true;
            }
            else
            {
                return false;
            }
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
                Root = new Node<T>(value);
                return;
            }

            Insert(value, Root);
        }

        private void Insert(T value, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (value.CompareTo(node.value) < 0)
            {
                if (node.LChild == null)
                {
                    node.LChild = new Node<T>(value);
                    node.LChild.Parent = node;
                    Balance(node.LChild);
                }
                else
                {
                    Insert(value, node.LChild);
                }
            }
            else if (value.CompareTo(node.value) >= 0)
            {
                if (node.RChild == null)
                {
                    node.RChild = new Node<T>(value);
                    node.RChild.Parent = node;
                    Balance(node.RChild);
                }
                else
                {
                    Insert(value, node.RChild);
                }
            }
        }

        public void Delete(T value)
        {
            count--;
            if (Root == null)
            {
                return;
            }

            Delete(value, Root);
        }

        private void Delete(T value, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (value.CompareTo(node.value) < 0)
            {
                Delete(value, node.LChild);
            }
            else if (value.CompareTo(node.value) > 0)
            {
                Delete(value, node.RChild);
            }
            else
            {
                if (node.ChildCount == 0)
                {
                    if (node.IsLeftChild)
                    {
                        node.Parent.LChild = null;
                    }

                    else if (!node.IsLeftChild)
                    {
                        node.Parent.RChild = null;
                    }
                    count--;
                    return;
                }

                if (node.LChild != null && node.RChild == null)
                {
                    if (node.value.CompareTo(node.Parent.value) < 0)
                    {
                        node.Parent.LChild = node.LChild;
                        node.LChild.Parent = node.Parent;
                    }

                    if (node.value.CompareTo(node.Parent.value) > 0)
                    {
                        node.Parent.RChild = node.LChild;
                        node.RChild.Parent = node.Parent;
                    }
                    count--;
                    return;
                }

                if (node.LChild == null && node.RChild != null)
                {
                    if (node.value.CompareTo(node.Parent.value) < 0)
                    {
                        node.Parent.LChild = node.RChild;
                        node.RChild.Parent = node.Parent;
                    }

                    if (node.value.CompareTo(node.Parent.value) > 0)
                    {
                        node.Parent.RChild = node.RChild;
                        node.RChild.Parent = node.Parent;
                    }
                    count--;
                    return;
                }

                if (node.ChildCount == 2)
                {
                    Counter2 = node;

                    Counter2 = Counter2.LChild;

                    while (Counter2.RChild != null)
                    {
                        Counter2 = Counter2.RChild;
                    }

                    node.value = Counter2.value;
                    if (Counter2.IsLeftChild)
                    {
                        Counter2.Parent.LChild = null;
                    }
                    else
                    {
                        Counter2.Parent.RChild = null;
                    }
                }
                Balance(Counter2.Parent);
            }
        }

        public IEnumerable<T> PreOrder()
        {
            List<T> list = new List<T>();

            preOrder(Root);

            return list;

            void preOrder(Node<T> curr)
            {
                list.Add(curr.value);

                if (curr.LChild != null)
                {
                    preOrder(curr.LChild);
                }

                if (curr.RChild != null)
                {
                    preOrder(curr.RChild);
                }
            }
        }        

        public T[] InOrder()
        {
            if (Root == null)
            {
                return null;
            }

            List<T> list = new List<T>();
            Counter = Root;

            while (list.Count < count)
            {
                if (Counter.LChild != null && !list.Contains(Counter.LChild.value))
                {
                    Counter = Counter.LChild;
                }
                else if (!list.Contains(Counter.value))
                {
                    list.Add(Counter.value);
                }
                else if (Counter.RChild != null && !list.Contains(Counter.RChild.value))
                {
                    Counter = Counter.RChild;
                }
                else
                {
                    Counter = Counter.Parent;
                }
            }


            return list.ToArray();
        }

        public T[] PostOrder()
        {
            if (Root == null)
            {
                return null;
            }

            List<T> list = new List<T>();
            Counter = Root;

            while (list.Count < count)
            {
                if (Counter.LChild != null && !list.Contains(Counter.LChild.value))
                {
                    Counter = Counter.LChild;
                }
                else if (Counter.RChild != null && !list.Contains(Counter.RChild.value))
                {
                    Counter = Counter.RChild;
                }
                else if (!list.Contains(Counter.value))
                {
                    list.Add(Counter.value);
                }
                else
                {
                    Counter = Counter.Parent;
                }
            }


            return list.ToArray();
        }

        private void Balance(Node<T> Counter)
        {
            if (count <= 1)
            {
                return;
            }

            if (Counter == null)
            {
                return;
            }

            if (Counter.ChildCount == 0)
            {
                balance = 0;
            }
            if (Counter.ChildCount == 1 && Counter.LChild != null)
            {
                balance = -Counter.LChild.Height;
            }
            if (Counter.ChildCount == 1 && Counter.RChild != null)
            {
                balance = Counter.RChild.Height;
            }
            if(Counter.ChildCount == 2)
            {
                balance = Counter.RChild.Height - Counter.LChild.Height;
            }

            if (balance >= 2)
            {
                if (Counter.RChild != null && Counter.RChild.LChild != null && Counter.LChild == null)
                {
                    RRotate(Counter.RChild);
                    LRotate(Counter);
                }
                else
                {
                    LRotate(Counter);
                }
            }
            else if (balance <= -2)
            {
                if (Counter.LChild != null && Counter.LChild.RChild != null && Counter.RChild == null)
                {
                    LRotate(Counter.LChild);
                    RRotate(Counter);
                }
                else
                {
                    RRotate(Counter);
                }
            }

            if (Counter.Parent != null)
            {
                Balance(Counter.Parent);
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
        }
    }
}