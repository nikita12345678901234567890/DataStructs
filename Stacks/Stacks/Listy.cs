using System;
using System.Collections.Generic;
using System.Text;

namespace Stacks
{
    class List<T>
    {
        public Node<T> Head;
        public Node<T> Counter;
        public Node<T> Counter2;
        int count = 0;
        public void addFirst(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
            }
            else
            {
                Head = new Node<T>(value, Head);
            }
            count++;
        }
        public void addLast(T value)
        {
          
            if (Head == null)
            {
                Head = new Node<T>(value);
                return;
            }
            Node<T> counter = Head;
            while (counter.Next != null)
            {
                counter = counter.Next;
            }
            counter.Next = new Node<T>(value);
            count++;
        }
        public void addBefore(T value, int index)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
                return;
            }
            Node<T> counter = Head;
            for (int i = 0; i < index - 2; i++)
            {
                counter = counter.Next;
            }
            Node<T> NodeToAdd = new Node<T>(value);
            Node<T> NextNode = counter.Next;
            counter.Next = NodeToAdd;
            NodeToAdd.Next = NextNode;
            count++;
        }
        public void addAfter(T value, int index)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
                return;
            }
            Node<T> counter = Head;
            for (int i = 0; i < index - 2; i++)
            {
                counter = counter.Next;
            }
            Node<T> NodeToAdd = new Node<T>(value);
            counter = counter.Next;
            Node<T> NextNode = counter.Next;
            counter.Next = NodeToAdd;
            NodeToAdd.Next = NextNode;
            count++;
        }
        public void removeFirst()
        {
            if (Head == null)
            {
                return;
            }
            Head = Head.Next;
            count--;
        }
        public void removeLast()
        {
            if (Head == null)
            {
                return;
            }
            Node<T> counter = Head;
            while (counter.Next.Next != null)
            {
                counter = counter.Next;
            }
            counter.Next = null;
            count--;
        }
        public bool IsCircular()
        {
            Counter = Head;
            Counter2 = Counter;
            int county = 0;
            while (Counter != Counter2 && county < 500)
            {
                Counter = Counter.Next;
                Counter2 = Counter.Next.Next;
                county++;
            }
            if (Counter == Counter2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}