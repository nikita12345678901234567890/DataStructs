using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BurstTrie
{
    public class BSTNode<T> where T : IComparable<T>
    {
        public T Value;
        public BSTNode<T> LChild;
        public BSTNode<T> RChild;

        public BSTNode()
        { 
            
        }

        public BSTNode(T value)
        {
            Value = value;
        }
    }

    public class BST<T> where T : IComparable<T>
    {
        BSTNode<T> Root;
        public int Count { get; private set; }

        public BST()
        {
        }

        public void Insert(T value)
        {
            if (Root == null)
            { 
                Root = new BSTNode<T>();
                Root.Value = value;
                return;
            }

            BSTNode<T> curr = Root;
            while (true)
            {
                if (value.CompareTo(curr.Value) < 0)
                {
                    if (curr.LChild == null)
                    {
                        curr.LChild = new BSTNode<T>(value);
                        return;
                    }
                    else
                    { 
                        curr = curr.LChild;
                    }
                }
                else
                {
                    if (curr.RChild == null)
                    {
                        curr.RChild = new BSTNode<T>(value);
                        return;
                    }
                    else
                    {
                        curr = curr.RChild;
                    }
                }
            }
        }

        public bool Remove(T value) => Remove(ref Root, value);
        private bool Remove(ref BSTNode<T>? current, T value)
        {
            if (current == null)
                return false;


            if (!value.Equals(current.Value))
            {
                if (value.CompareTo(current.Value) < 0) return Remove(ref current.LChild, value);

                else return Remove(ref current.RChild, value);
            }

            Count--;
            if (current.LChild != null)
            {
                if (current.RChild != null)
                {
                    current.Value = StealLeaf(ref current.LChild);
                }
                else
                {
                    current = current.LChild;
                }
            }
            else
            {
                current = current.RChild;
            }
            return true;
        }

        T StealLeaf(ref BSTNode<T> probe)
        {
            if (probe.RChild == null)
            {
                var val = probe.Value;
                probe = probe.LChild!;
                return val;
            }
            return StealLeaf(ref probe.RChild);
        }

        public void GetAll(List<T> starter) => GetAll(Root, starter);

        private void GetAll(BSTNode<T> current, List<T> starter)
        {
            if (current == null) return;

            GetAll(current.LChild, starter);

            starter.Add(current.Value);

            GetAll(current.RChild, starter);
        }
    }
}