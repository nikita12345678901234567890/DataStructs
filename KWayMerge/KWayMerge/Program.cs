using System;
using System.Collections.Generic;

namespace KWayMerge
{
    class Program
    {
        static Random gen = new Random();
        static List<int> GetNSortedNumbers(int n)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(gen.Next(1001));
            }

            list.Sort();

            return list;
        }
        static void Main(string[] args)
        {

            List<List<int>> listOfLists = new List<List<int>>();

            int size = gen.Next(5, 20);

            for (int i = 0; i < size; i++)
            {
                listOfLists.Add(GetNSortedNumbers(gen.Next(5, 15)));
            }

            //At this comment, I have a list of lists;

            List<int> Output = new List<int>();
            int smallest = 0;
            int total = 0;
            for (int i = 0; i < listOfLists.Count; i++)
            {
                total += listOfLists[i].Count;
            }

            for (int i = 0; i < total; i++)
            {
                smallest = listOfLists.Count - 1;
                for (int j = 0; j < listOfLists.Count; j++)
                {
                    if (listOfLists[j][0] < listOfLists[smallest][0])
                    {
                        smallest = j;
                    }
                }
                Output.Add(listOfLists[smallest][0]);
                Console.WriteLine(listOfLists[smallest][0]);
                listOfLists[smallest].RemoveAt(0);
                if (listOfLists[smallest].Count == 0)
                {
                    listOfLists.RemoveAt(smallest);
                }
            }
        }
    }
}
