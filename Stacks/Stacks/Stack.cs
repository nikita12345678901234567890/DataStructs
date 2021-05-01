using System;
using System.Collections.Generic;
using System.Text;

namespace Stacks
{
    class Stack<T>
    {
        public int count = 0;
        private List<T> data = new List<T>();
        private T thing;
        public int Null;

        public void Push(T value)
        {
            data.addFirst(value);
            count++;
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new Exception("The stack is exsufflicate!");
            }
            thing = data.Head.Value;
            data.removeFirst();
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
