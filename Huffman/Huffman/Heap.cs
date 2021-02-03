using System;
using System.Collections.Generic;
using System.Text;

namespace Huffman
{
    public class Heap<T>
    {
        List<T> heap;
        IComparer<T> comparer;
        public Heap(IComparer<T> comparer)
        {
            heap = new List<T>();
            this.comparer = comparer;
        }

        public int Count => heap.Count;
        public bool IsEmpty => Count == 0;

        public void Add(T item)
        {
            heap.Add(item);

            HeapifyUp(Count - 1);
        }

        private void HeapifyUp(int index)
        {
            if (index <= 0) return;

            int parent = (index - 1) / 2;

            if (comparer.Compare(heap[index], heap[parent]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[parent];
                heap[parent] = temp;

                HeapifyUp(parent);
            }
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            T root = heap[0];

            //Put the last element into the first element
            heap[0] = heap[Count - 1];

            heap.RemoveAt(Count - 1);

            //Heapify Down the last element that you just put in the first element
            HeapifyDown(0);

            return root;
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
                swapIndex = comparer.Compare(heap[leftChild], heap[rightChild]) < 0 ? leftChild : rightChild;
            }

            //If the recieved child is smaller than the index then swap them
            if (comparer.Compare(heap[swapIndex], heap[index]) < 0)
            {
                T temp = heap[index];
                heap[index] = heap[swapIndex];
                heap[swapIndex] = temp;
            }

            //Move down to the next children recursively
            HeapifyDown(swapIndex);
        }

    }
}