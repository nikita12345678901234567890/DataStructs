using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class TreeHeap2<T, T2> where T : IComparable
    {
        List<T> array;
        List<T2> array2;
        bool min;
        public TreeHeap2(bool min)
        {
            array = new List<T>();
            array2 = new List<T2>();
            this.min = min;
        }

        public void Insert(T value, T2 person)
        {
            array.Add(value);
            array2.Add(person);
            if (array.Count > 1)
            {
                HeapifyUp(array.Count - 1);
            }
        }

        public T2 Pop()
        {
            T thing = array[0];
            array[0] = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);
            T2 thingy = array2[0];
            array2[0] = array2[array2.Count - 1];
            array2.RemoveAt(array2.Count - 1);
            HeapifyDown(0);
            return thingy;
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
                        T2 thingy = array2[index];
                        array2[index] = array2[FindParent(index)];
                        array2[FindParent(index)] = thingy;
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
                        T2 thingy = array2[index];
                        array2[index] = array2[FindParent(index)];
                        array2[FindParent(index)] = thingy;
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
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && array[FindLeft(index)].CompareTo(array[FindRight(index)]) < 0) || (FindLeft(index) < array.Count && FindRight(index) >= array.Count && array[index].CompareTo(array[FindLeft(index)]) > 0) || (FindLeft(index) >= array.Count && FindRight(index) < array.Count && array[index].CompareTo(array[FindRight(index)]) > 0))
                    {
                        T thing = array[index];
                        array[index] = array[FindLeft(index)];
                        array[FindLeft(index)] = thing;
                        T2 thingy = array2[index];
                        array2[index] = array2[FindLeft(index)];
                        array2[FindLeft(index)] = thingy;
                        index = FindLeft(index);
                    }
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && array[FindLeft(index)].CompareTo(array[FindRight(index)]) > 0) || (FindLeft(index) < array.Count && FindRight(index) >= array.Count && array[index].CompareTo(array[FindLeft(index)]) > 0) || (FindLeft(index) >= array.Count && FindRight(index) < array.Count && array[index].CompareTo(array[FindRight(index)]) > 0))
                    {
                        T thing = array[index];
                        array[index] = array[FindRight(index)];
                        array[FindRight(index)] = thing;
                        T2 thingy = array2[index];
                        array2[index] = array2[FindRight(index)];
                        array2[FindRight(index)] = thingy;
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
                        T2 thingy = array2[index];
                        array2[index] = array2[FindLeft(index)];
                        array2[FindLeft(index)] = thingy;
                        index = FindLeft(index);
                    }
                    if ((FindLeft(index) < array.Count && FindRight(index) < array.Count && array[FindLeft(index)].CompareTo(array[FindRight(index)]) < 0) || FindLeft(index) >= array.Count && FindRight(index) < array.Count)
                    {
                        T thing = array[index];
                        array[index] = array[FindRight(index)];
                        array[FindRight(index)] = thing;
                        T2 thingy = array2[index];
                        array2[index] = array2[FindRight(index)];
                        array2[FindRight(index)] = thingy;
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