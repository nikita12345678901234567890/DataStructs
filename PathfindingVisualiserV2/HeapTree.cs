using System;
using System.Collections.Generic;
using System.Text;

namespace PathfindingVisualiserV2
{
    class HeapTree<T> where T : IComparable<T>
    {
        List<T> array;

        public int Count => array.Count;

        bool min;
        public HeapTree(bool min)
        {
            array = new List<T>();
            this.min = min;
        }
        //Do not touch under any circumatsnces!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
            //Get the parent index
            int parent = (index - 1) / 2;

            //Base case when there is no more parent
            if (index == 0)
            {
                return;
            }

            //If the index is less than the parent swap them
            if (array[index].CompareTo(array[parent]) < 0)
            {
                T temp = array[index];
                array[index] = array[parent];
                array[parent] = temp;
            }

            //Go up to the parent recursively
            HeapifyUp(parent);
        }

        private void HeapifyDown(int index)
        {
            //Getting the left and right child
            int leftChild = index * 2 + 1;

            //If you don't have a left child, you can't have a right child
            //If there are no children, recursion stops
            if (leftChild >= Count)
            {
                return;
            }

            int rightChild = index * 2 + 2;
            int swapIndex = 0;

            //If there is no right child at this point, the smaller child is the left child
            if (rightChild >= Count)
            {
                swapIndex = leftChild;
            }
            else
            {
                //If both children exist, pick the smaller one
                swapIndex = array[leftChild].CompareTo(array[rightChild]) < 0 ? leftChild : rightChild;
            }

            //If the recieved child is smaller than the index then swap them
            if (array[swapIndex].CompareTo(array[index]) < 0)
            {
                T temp = array[index];
                array[index] = array[swapIndex];
                array[swapIndex] = temp;
            }

            //Move down to the next children recursively
            HeapifyDown(swapIndex);
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
            HeapTree<T> tree = new HeapTree<T>(true);
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

        public bool Contains(T item)
            => array.Contains(item);
    }
}
