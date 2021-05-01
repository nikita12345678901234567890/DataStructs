using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSort
{
    class SortQuick<T> where T : IComparable
    {
        T thingy;
        public SortQuick()
        {
            
        }

        public T[] Sort(T[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                Sort(array, start, pivot - 1);
                Sort(array, pivot + 1, end);
            }
          
            return array;
        }

        public int Partition(T[] array, int start, int end)
        {
            int pivot = end;
            int wall = start;

            for (int i = wall; i < end; i++)
            {
                if (array[i].CompareTo(array[pivot]) < 0)
                {
                    thingy = array[i];
                    array[i] = array[wall];
                    array[wall] = thingy;
                    wall++;
                }
            }

            thingy = array[pivot];
            array[pivot] = array[wall];
            array[wall] = thingy;

            return pivot;
        }

        public T[] Sort2(T[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition2(array, start, end);
                Sort2(array, start, pivot + 1);
                Sort2(array, pivot - 1, end);
            }

            return array;
        }

        public int Partition2(T[] array, int start, int end)
        {
            int pivot = start;
            while (start <= end)
            {
                while (array[start].CompareTo(array[pivot]) >= 0)
                {
                    start++;
                }
                while (array[end].CompareTo(array[pivot]) < 0)
                {
                    end--;
                }
                thingy = array[start];
                array[start] = array[end];
                array[end] = thingy;
            }

            return pivot;
        }
    }
}