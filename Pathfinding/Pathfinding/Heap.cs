using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class Heap<T>
    {
        List<T> array;
        bool min;

        IComparer<T> Comparer;

        public int Count
        {
            get
            {
                return array.Count;
            }
        }
        public Heap(bool min, IComparer<T> comparer)
        {
            array = new List<T>();
            this.min = min;

            if (comparer == null)
            {
                Comparer = default;
            }
            else
            {
                Comparer = comparer;
            }
        }

        public void Insert(T value)
        {
            array.Add(value);
            if (array.Count > 1)
            {
                HeapifyUp(array.Count - 1);
            }
        }

        public T Pop()
        {
            T thing = array[0];
            array[0] = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);
            HeapifyDown(0);
            return thing;
        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            for (int i = 0; i < array.Count; i++)
            {
                if (min)
                {
                    if (Comparer.Compare(array[index], array[FindParent(index)]) < 0)
                    {
                        T thing = array[index];
                        array[index] = array[FindParent(index)];
                        array[FindParent(index)] = thing;
                        index = FindParent(index);
                    }
                }
                else
                {
                    if (Comparer.Compare(array[index], array[FindParent(index)]) > 0)
                    {
                        T thing = array[index];
                        array[index] = array[FindParent(index)];
                        array[FindParent(index)] = thing;
                        index = FindParent(index);
                    }
                }
            }
        }

        private void HeapifyDown(int index)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (min)
                {
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && Comparer.Compare(array[FindLeft(index)], array[FindRight(index)]) < 0) || FindLeft(index) < array.Count && FindRight(index) >= array.Count || (FindLeft(index) < array.Count && FindRight(index) > array.Count && Comparer.Compare(array[index], array[FindLeft(index)]) > 0) || (FindLeft(index) >= array.Count && FindRight(index) < array.Count && Comparer.Compare(array[index], array[FindRight(index)]) > 0))
                    {
                        T thing = array[index];
                        array[index] = array[FindLeft(index)];
                        array[FindLeft(index)] = thing;
                        index = FindLeft(index);
                    }
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && Comparer.Compare(array[FindLeft(index)], array[FindRight(index)]) > 0) || FindLeft(index) >= array.Count && FindRight(index) < array.Count || (FindLeft(index) < array.Count && FindRight(index) > array.Count && Comparer.Compare(array[index], array[FindLeft(index)]) > 0) || (FindLeft(index) >= array.Count && FindRight(index) < array.Count && Comparer.Compare(array[index], array[FindRight(index)]) > 0))
                    {
                        T thing = array[index];
                        array[index] = array[FindRight(index)];
                        array[FindRight(index)] = thing;
                        index = FindRight(index);
                    }
                }
                else
                {
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && Comparer.Compare(array[FindLeft(index)], array[FindRight(index)]) > 0) || FindLeft(index) < array.Count && FindRight(index) >= array.Count)
                    {
                        T thing = array[index];
                        array[index] = array[FindLeft(index)];
                        array[FindLeft(index)] = thing;
                        index = FindLeft(index);
                    }
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && Comparer.Compare(array[FindLeft(index)], array[FindRight(index)]) < 0) || FindLeft(index) >= array.Count && FindRight(index) < array.Count)
                    {
                        T thing = array[index];
                        array[index] = array[FindRight(index)];
                        array[FindRight(index)] = thing;
                        index = FindRight(index);
                    }
                }
            }
        }

        private int FindParent(int index)
        {
            return (index - 1) / 2;
        }

        private int FindLeft(int index)
        {
            return index + (index + 1);
        }

        private int FindRight(int index)
        {
            return index + (index + 2);
        }

        public static List<T> YEETSort(List<T> yeet, IComparer<T> comparer)
        {
            Heap<T> tree = new Heap<T>(true, comparer);
            for (int i = 0; i < yeet.Count; i++)
            {
                tree.Insert(yeet[i]);
            }
            List<T> yeeter = new List<T>();
            for (int i = 0; i < yeet.Count; i++)
            {
                yeeter.Add(tree.Pop());
            }
            return yeeter;
        }

        public bool Contains(T thing)
        {
            return array.Contains(thing);
        }
    }
}