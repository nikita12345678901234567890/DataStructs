using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    class SkipList<T> where T : IComparable
    {
        public int count = 0;
        public Node<T> Head;
        private Node<T> Counter;

        Random random = new Random();

        public IComparer<T> Comparer { get; private set; }


        public SkipList()
        {
            Head = new Node<T>(ChooseRandomHeight());
        }

        private int ChooseRandomHeight()
        {
            int coin = random.Next(0, 2);
            int i = 1;
            while (true)
            {
                coin = random.Next(0, 2);
                if (coin == 0)
                {
                    i++;
                }
                else
                {
                    return i;
                }
            }
        }

        public void Insert(T value)
        {
            var node = new Node<T>(value, ChooseRandomHeight());
            if (node.height >= Head.height)
            {
                for (int i = 0; i < node.height - Head.height; i++)
                {
                    Head.IncrementHeight();
                    Head.height++;
                }
            }
            Counter = Head;

            int thing = Head.height - 1;
            while (thing >= 0)
            {
                int comparison = Counter.Nexts[thing] == null ? 1 : Counter.Nexts[thing].value.CompareTo(value);

                if (comparison > 0)
                {
                    if (node.height > thing)
                    {
                        node.Nexts[thing] = Counter.Nexts[thing];
                        Counter.Nexts[thing] = node;
                    }
                    thing--;
                }
                else if (comparison < 0)
                {
                    Counter = Counter.Nexts[thing];
                }
                else if (comparison == 0)
                {
                    throw new Exception("No duplicate keys allowed");
                }
            }
            count++;
        }

        public void Delete(T value)
        {
            count--;
            Counter = Head;
            int thing = Head.height - 1;
            while (thing >= 0)
            {
                int comparison = Counter.Nexts[thing] == null ? 1 : Counter.Nexts[thing].value.CompareTo(value);

                if (comparison > 0)
                {
                    thing--;
                }
                else if (comparison < 0)
                {
                    Counter = Counter.Nexts[thing];
                }
                else if (comparison == 0)
                {
                    while (thing >= 0)
                    {
                        if (Counter.Nexts[thing].value.Equals(value))
                        {
                            Counter.Nexts[thing] = Counter.Nexts[thing].Nexts[thing];
                            thing--;
                        }
                        else
                        {
                            Counter = Counter.Nexts[thing];
                        }
                    }
                    return;
                }
            }
            count++;
        }

        public int[] Test()
        {
            //return an array with the heights of all the nodes;
            int[] array = new int[count];
            Counter = Head.Nexts[0];
            for (int i = 0; i < count; i++)
            {
                array[i] = Counter.height;
                Counter = Counter.Nexts[0];
            }
            return array;
        }
    }
}