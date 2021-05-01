using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Stack
{
    class fish<T> where T : IComparable
    {
        List<T> a_list = new List<T>();
        public fish()
        {
            Console.WriteLine("fish");
        }

        public void Enqueue (T thing)
        {
            a_list.Add(thing);
        }

        public T Peek()
        {
            return a_list[0];
        }

        public void BigRedButton()
        {
            a_list.Clear();
        }

        public T Dequeue()
        {
            T thing = Peek();
            a_list.RemoveAt(0);
            return thing;
        }
    }
}