using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Stack
{
    class Stuck<T> where T : IComparable
    {
        List<T> a_list = new List<T>();
        public Stuck()
        {
            Console.WriteLine("fish");
        }

        public void Push(T thing)
        {
            a_list.Add(thing);
        }

        public T Peek()
        {
            return a_list[a_list.Count - 1];
        }

        public void BigRedButton()
        {
            a_list.Clear();
        }

        public T Popopopopopopopopopopopopop()
        {
            T thing = Peek();
            a_list.RemoveAt(a_list.Count - 1);
            return thing;
        }
    }
}