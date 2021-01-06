using System;
using System.Collections.Generic;
using System.Text;

namespace Trees
{
    class Tree<T> where T : IComparable
    {
        public int count = 0;
        public Node<T> Root;
        private Node<T> Counter;
        private Node<T> Counter2;
        public Tree()
        {

        }


        public bool Search(T value)     //Search tree for a node with the given key: While the current node is not null and the keys are not a match, set the current node to either its left or right child.Set it to the left child if the key is less than the current node’s key.Otherwise set it to the right child.
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

        public T Minimum(T value)     //Shift over left as many times as possible to get the smallest element of a given sub-tree.
        {
            Counter = Root;
            while (!Counter.value.Equals(value))
            {
                if (Counter.value.CompareTo(value) > 0)
                {
                    Counter = Counter.LChild;
                }
                if(Counter.value.CompareTo(value) < 0)
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

        public T Maximum(T value)     //Shift over right as many times as possible to get the largest element of a given sub-tree.
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

        public void Insert(T value)     //Start with the root of the tree.If there is no root, set the root to the new node.Increment the size of the tree and return. If there is a root, traverse the tree until you find the proper locations for the new node.This can be done by going left or right(depending on how the current node’s key compares to the new node’s key.NOTE: if the key's are equal, traverse right. This is the standard practice) until a leaf is reached. Current will stop right on the parent of the new node, but the new node does know this. So you must set the parent of the new node to the current. Finally, depending on whether the new node’s key is less than or greater than the current node, the new node is set as the left or right child of the current node, respectively.
        {
            count++;

            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }

            Counter = Root;


            Counter = Root;
            while (Counter != null)
            {
                //If the value is less than
                //We go to the left or if the left is null we insert the value at the left
                //Samething goes for the right side
                if (value.CompareTo(Counter.value) < 0)
                {
                    if (Counter.LChild == null)
                    {
                        Counter.LChild = new Node<T>(value);
                        Counter.LChild.Parent = Counter;
                        break;
                    }
                    Counter = Counter.LChild;
                }
                else
                {
                    if (Counter.RChild == null)
                    {
                        Counter.RChild = new Node<T>(value);
                        Counter.RChild.Parent = Counter;
                        break;
                    }
                    Counter = Counter.RChild;
                }
            }
        }

        public void Delete(T value)     //Start at the root of the tree, and do an in-order traversal of the tree until the node is found.Then follow the following cases (always keep in mind any edge cases such as root, null, parent, and children connections):
        {
            if (Root == null)
            {
                return;
            }

            Counter = Root;
            for (int i = 0; i < count; i++)
            {
                if (Counter.value.Equals(value))
                {
                    if (Counter.ChildCount == 0)
                    {
                        if (Counter.value.CompareTo(Counter.Parent.value) < 0)
                        {
                            Counter.Parent.LChild = null;
                        }

                        if (Counter.value.CompareTo(Counter.Parent.value) > 0)
                        {
                            Counter.Parent.RChild = null;
                        }
                        count--;
                        return;
                    }

                    if (Counter.LChild != null && Counter.RChild == null)
                    {
                        if (Counter.value.CompareTo(Counter.Parent.value) < 0)
                        {
                            Counter.Parent.LChild = Counter.LChild;
                            Counter.LChild.Parent = Counter.Parent;
                        }

                        if (Counter.value.CompareTo(Counter.Parent.value) > 0)
                        {
                            Counter.Parent.RChild = Counter.LChild;
                            Counter.RChild.Parent = Counter.Parent;
                        }
                        count--;
                        return;
                    }

                    if (Counter.LChild == null && Counter.RChild != null)
                    {
                        if (Counter.value.CompareTo(Counter.Parent.value) < 0)
                        {
                            Counter.Parent.LChild = Counter.RChild;
                            Counter.RChild.Parent = Counter.Parent;
                        }

                        if (Counter.value.CompareTo(Counter.Parent.value) > 0)
                        {
                            Counter.Parent.RChild = Counter.RChild;
                            Counter.RChild.Parent = Counter.Parent;
                        }
                        count--;
                        return;
                    }

                    if (Counter.ChildCount == 2)
                    {
                        Counter2 = Counter;

                        Counter2 = Counter2.LChild;

                        while (Counter2.RChild != null)
                        {
                            Counter2 = Counter2.RChild;
                        }

                        Counter.value = Counter2.value;
                        if (Counter2.IsLeftChild)
                        {
                            Counter2.Parent.LChild = null;
                        }
                        else
                        {
                            Counter2.Parent.RChild = null;
                        }
                        Counter2 = null;
                    }
                    count--;
                    return;
                }

                if (Counter.value.CompareTo(value) > 0)
                {
                    Counter = Counter.LChild;
                }

                if (Counter.value.CompareTo(value) < 0)
                {
                    Counter = Counter.RChild;
                }
                count--;
            }
        }

        /*public T[] PreOrder()
        {
            if (Root == null)
            {
                return null;
            }

            List<T> list = new List<T>();
            Counter = Root;
            while(list.Count < count)
            {
                if (!list.Contains(Counter.value))
                {
                    list.Add(Counter.value);
                }

                else if (Counter.ChildCount == 0)
                {
                    Counter = Counter.Parent;
                }

                else if (Counter.ChildCount == 1)
                {
                    if (Counter.LChild != null && !list.Contains(Counter.LChild.value))
                    {
                        Counter = Counter.LChild;
                    }
                    else
                    {
                        Counter = Counter.RChild;
                    }
                }

                else if (Counter.ChildCount == 2)
                {
                    if (list.Contains(Counter.value) && list.Contains(Counter.LChild.value) && list.Contains(Counter.RChild.value))
                    {
                        Counter = Counter.Parent;
                    }
                    else if (!list.Contains(Counter.LChild.value))
                    {
                        Counter = Counter.LChild;
                    }
                    else
                    {
                        Counter = Counter.RChild;
                    }
                }
            }


            return list.ToArray();
        }*/

        public IEnumerable<T> PreOrder()
        {
            Queue<T> nodes = new Queue<T>();

            Stack<Node<T>> stack = new Stack<Node<T>>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                Node<T> curr = stack.Pop();

                nodes.Enqueue(curr.value);

                if (curr.RChild != null)
                {
                    stack.Push(curr.RChild);
                }

                if (curr.LChild != null)
                {
                    stack.Push(curr.LChild);
                }
            }

            return nodes;
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

        public T[] PreOrderStack()
        {
            if (Root == null)
            {
                return null;
            }

            Stack<Node<T>> stack = new Stack<Node<T>>();
            List<T> list = new List<T>();
            stack.Push(Root);

            while (list.Count < count)
            {
                Counter = stack.Pop();

                list.Add(Counter.value);
                if (Counter.RChild != null)
                {
                    stack.Push(Counter.RChild);
                }
                if (Counter.LChild != null)
                {
                    stack.Push(Counter.LChild);
                }
            }

            return list.ToArray();
        }

        public T[] InOrderStack()
        {
            if (Root == null)
            {
                return null;
            }

            Stack<Node<T>> stack = new Stack<Node<T>>();
            List<T> list = new List<T>();
            Counter = Root;

            while (list.Count < count)
            {
                if (Counter != null)
                {
                    stack.Push(Counter);
                    Counter = Counter.LChild;
                }

                else
                {
                    Counter = stack.Pop();
                    list.Add(Counter.value);
                    Counter = Counter.RChild;
                }
            }

            return list.ToArray();
        }

        public T[] PostOrderStack()
        {
            if (Root == null)
            {
                return null;
            }

            Stack<Node<T>> stack = new Stack<Node<T>>();
            Stack<T> stack2 = new Stack<T>();
            List<T> list = new List<T>();
            stack.Push(Root);

            while (stack.Count > 0)
            {
                Counter = stack.Pop();

                stack2.Push(Counter.value);

                if (Counter.LChild != null)
                {
                    stack.Push(Counter.LChild);
                }

                if (Counter.RChild != null)
                {
                    stack.Push(Counter.RChild);
                }
            }

            return stack2.ToArray();
        }

        public T[] BreadthFirst()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            List<T> list = new List<T>();
            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                Counter = queue.Dequeue();
                list.Add(Counter.value);
                if (Counter.LChild != null)
                {
                    queue.Enqueue(Counter.LChild); 
                }
                if (Counter.RChild != null)
                {
                    queue.Enqueue(Counter.RChild);
                }
            }

            return list.ToArray();
        }
    }
}