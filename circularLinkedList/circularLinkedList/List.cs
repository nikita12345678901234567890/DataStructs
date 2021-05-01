using System;
using System.Collections.Generic;
using System.Text;

namespace circularLinkedList
{
    public class List<T>
    {
        public Node<T> Head;
        public Node<T> Tail;
        private Node<T> Counter;
        public int count = 0;

        public List()
        {

        }

        virtual public void AddFirst(T value)   //Add a node to the front of the list
        {
            count++;

            if (IsEmpty())
            {
                Head = new Node<T>(value);
                Tail = Head;
                Head.Next = Tail;
                Tail.Prev = Head;
                Head.Prev = Tail;
                Tail.Next = Head;
                return;
            }

            var newHead = new Node<T>(value);

            Head.Prev = newHead;
            newHead.Next = Head;
            Head = newHead;
            Tail.Next = Head;
            Head.Prev = Tail;
        }

        virtual public void AddLast(T value)    //Add a node to the end of the list
        {
            count++;
            
            if (IsEmpty())
            {
                Head = new Node<T>(value);
                Tail = Head;
                Head.Next = Tail;
                Tail.Prev = Head;
                Head.Prev = Tail;
                Tail.Next = Head;
                return;
            }


            var newTail = new Node<T>(value);

            Tail.Next = newTail;
            newTail.Prev = Tail;
            Tail = newTail;
            Tail.Next = Head;
            Head.Prev = Tail;
        }

        virtual public void AddBefore(int index, T value)  //Add a node with the given value before the given index
        {
            count++;

            if (IsEmpty())
            {
                Head = new Node<T>(value);
                Tail = Head;
                Head.Next = Tail;
                Tail.Prev = Head;
                Head.Prev = Tail;
                Tail.Next = Head;
                return;
            }

            var thing = new Node<T>(value);

            Counter = Head;
            for (int i = 0; i < index - 1; i++)
            {
                Counter = Counter.Next;
            }

            thing.Prev = Counter.Prev;
            thing.Next = Counter;
            thing.Prev.Next = thing;
            Counter.Prev = thing;
        }

        virtual public void AddAfter(int index, T value)   //Add a node with the given value after the given index
        {
            count++;

            if (IsEmpty())
            {
                Head = new Node<T>(value);
                Tail = Head;
                Head.Next = Tail;
                Tail.Prev = Head;
                Head.Prev = Tail;
                Tail.Next = Head;
                return;
            }

            var thing = new Node<T>(value);

            Counter = Head;
            for (int i = 0; i < index; i++)
            {
                Counter = Counter.Next;
            }

            thing.Prev = Counter.Prev;
            thing.Next = Counter;
            thing.Prev.Next = thing;
            Counter.Prev = thing;
        }

        public void RemoveFirst()  //Remove a node from the front of the list
        {
            if (IsEmpty())
            {
                return;
            }
            if (count == 1)
            {
                Head = null;
                Tail = null;
                count--;
                return;
            }

            Tail.Next = Head.Next;
            Head.Next.Prev = Tail;
            Head = Head.Next;

            count--;
        }

        public void RemoveLast()   //Remove a node from the end of the list
        {
            if (IsEmpty())
            {
                return;
            }
            if (count == 1)
            {
                Head = null;
                Tail = null;
                count--;
                return;
            }

            Tail.Prev.Next = Head;
            Head.Prev = Tail.Prev;
            Tail = Tail.Prev;

            count--;
        }

        public void Remove(T value)    //Remove the first node with the given value from the linked list
        {
            if (IsEmpty())
            {
                return;
            }
            if (count == 1)
            {
                Head = null;
                Tail = null;
                count--;
                return;
            }

            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                if (Counter.Value.Equals(value))
                {
                    Counter.Next.Prev = Counter.Prev;
                    Counter.Prev.Next = Counter.Next;
                    count--;
                    return;
                }

                Counter = Counter.Next;
            }
        }

        public bool IsEmpty()  //Determine if list is empty
        {
            if (Head == null)
            {
                return true;
            }
            return false;
        }

        public bool IsCircular(List<T> list)
        {
            for (int i = 0; i < list.count - 1; i++)
            {
                list.RemoveLast();
            }
            if (list.Head.Next == list.Head)
            {
                return true;
            }
            return false;
        }
    }
}