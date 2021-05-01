using System;
using System.IO;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines(@"\\GMRDC1\Folder Redirection\nikita.ulianov\Desktop\friends.txt");
            QuickUnion blobfish = new QuickUnion(int.Parse(file[0]));
            for (int i = 1; i < file.Length; i++)
            {
                string[] temp = file[i].Split(' ');
                blobfish.Union(int.Parse(temp[0]), int.Parse(temp[1]));
            }
            var dog = blobfish.GetAllGroups();
            ;
        }
    }
}