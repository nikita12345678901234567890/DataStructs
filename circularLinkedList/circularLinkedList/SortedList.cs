using System;
using System.Collections.Generic;
using System.Text;

namespace circularLinkedList
{
    class SortedList<T> : List<T>
    {
        private Node<T> Counter;

        public void AddFirst(T value)   //Add a node to the front of the list
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

            T[] array = new T[count];
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                array[i] = Counter.Value;
                Counter = Counter.Next;
            }
            Array.Sort(array);
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                Counter.Value = array[i];
                Counter = Counter.Next;
            }
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

            T[] array = new T[count];
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                array[i] = Counter.Value;
                Counter = Counter.Next;
            }
            Array.Sort(array);
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                Counter.Value = array[i];
                Counter = Counter.Next;
            }
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

            T[] array = new T[count];
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                array[i] = Counter.Value;
                Counter = Counter.Next;
            }
            Array.Sort(array);
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                Counter.Value = array[i];
                Counter = Counter.Next;
            }
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

            T[] array = new T[count];
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                array[i] = Counter.Value;
                Counter = Counter.Next;
            }
            Array.Sort(array);
            Counter = Head;
            for (int i = 0; i < count; i++)
            {
                Counter.Value = array[i];
                Counter = Counter.Next;
            }
        }
    }
}
