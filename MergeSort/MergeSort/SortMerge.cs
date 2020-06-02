using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    class SortMerge <T> where T : IComparable
    {
        public T[] Merge(T[] first, T[] second)
        {
            T[] array = new T[first.Length + second.Length];

            for (int i = 0, j = 0, k = 0; i < array.Length; i++)
            {
                if (j < first.Length && k < second.Length)
                {
                    if (first[j].CompareTo(second[k]) >= 0)
                    {
                        array[i] = first[j];
                        j++;
                    }

                    else
                    {
                        array[i] = second[k];
                        k++;
                    }
                }
                else
                {
                    if (j < first.Length)
                    {
                        array[i] = first[j];
                        j++;
                    }
                    if (k < second.Length)
                    {
                        array[i] = second[k];
                        k++;
                    }
                }
            }

            return array;
        }

        public T[] UnMerge(T[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int leftLength = array.Length / 2;
            int rightLength = array.Length - leftLength;

            T[] left = new T[leftLength];
            T[] right = new T[rightLength];

            for (int i = 0; i < leftLength; i++)
            {
                left[i] = array[i];
            }

            for (int i = 0; i < rightLength; i++)
            {
                right[i] = array[i + leftLength];
            }

            return Merge(UnMerge(left), UnMerge(right));
        }

        public T[] Sort(T[] input)
        {
            if (input.Length <= 0)
            {
                return input;
            }

            

            return UnMerge(input);
        }
    }
}