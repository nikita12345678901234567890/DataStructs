using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class TreeHeap<T> where T : IComparable
    {
        List<T> array;
        bool min;
        public TreeHeap(bool min)
        {
            array = new List<T>();
            this.min = min;
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
                    if (array[index].CompareTo(array[FindParent(index)]) < 0)
                    {
                        T thing = array[index];
                        array[index] = array[FindParent(index)];
                        array[FindParent(index)] = thing;
                        index = FindParent(index);
                    }
                }
                else
                {
                    if (array[index].CompareTo(array[FindParent(index)]) > 0)
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
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && array[FindLeft(index)].CompareTo(array[FindRight(index)]) < 0) || FindLeft(index) < array.Count && FindRight(index) >= array.Count || (FindLeft(index) < array.Count && FindRight(index) >= array.Count && array[index].CompareTo(array[FindLeft(index)]) > 0) || (FindLeft(index) >= array.Count && FindRight(index) < array.Count && array[index].CompareTo(array[FindRight(index)]) > 0))
                    {
                        T thing = array[index];
                        array[index] = array[FindLeft(index)];
                        array[FindLeft(index)] = thing;
                        index = FindLeft(index);
                    }
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && array[FindLeft(index)].CompareTo(array[FindRight(index)]) > 0) || FindLeft(index) >= array.Count && FindRight(index) < array.Count || (FindLeft(index) < array.Count && FindRight(index) >= array.Count && array[index].CompareTo(array[FindLeft(index)]) > 0) || (FindLeft(index) >= array.Count && FindRight(index) < array.Count && array[index].CompareTo(array[FindRight(index)]) > 0))
                    {
                        T thing = array[index];
                        array[index] = array[FindRight(index)];
                        array[FindRight(index)] = thing;
                        index = FindRight(index);
                    }
                }
                else
                {
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && array[FindLeft(index)].CompareTo(array[FindRight(index)]) > 0) || FindLeft(index) < array.Count && FindRight(index) >= array.Count)
                    {
                        T thing = array[index];
                        array[index] = array[FindLeft(index)];
                        array[FindLeft(index)] = thing;
                        index = FindLeft(index);
                    }
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && array[FindLeft(index)].CompareTo(array[FindRight(index)]) < 0) || FindLeft(index) >= array.Count && FindRight(index) < array.Count)
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

        public static List<T> YEETSort(List<T> yeet)
        {
            TreeHeap<T> tree = new TreeHeap<T>(true);
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
    }
}