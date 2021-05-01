using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    class Queue<T>
    {
        public int count = 0;
        private List<T> data = new List<T>();
        private T thing;
        public int Null;

        public void Enqueue(T value)
        {
            data.AddLast(value);
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("The stack is exsufflicate!");
            }
            thing = data.Head.Value;
            data.RemoveFirst();
            count--;
            return thing;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new Exception("The stack is exsufflicate!");
            }
            return data.Head.Value;
        }
    }
}
