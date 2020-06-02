using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class Node<T>
    {
        public Node<T> Next;
        public Node<T> Prev;
        public T Value;

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }

        public Node(T value, Node<T> next, Node<T> prev)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }
    }
}
