using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HashMap
{
    class MyStringList
    {
        private List<string> data;

        public int Count { get; private set; }


        public string this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }


        public MyStringList()
        {
            data = new List<string>();
        }

        public void Add(string newItem)
        {
            data.Add(newItem);
            Count++;
        }

        public bool Remove(string item)
        {
            Count--;
            return data.Remove(item);
        }
    }

    class Program
    {

        class StringHolder : IEquatable<StringHolder>
        {
            private readonly string holder;

            public StringHolder(string holder)
            {
                this.holder = holder;
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as StringHolder);
            }

            public bool Equals([AllowNull] StringHolder other)
            {
                return other != null &&
                       holder == other.holder;
            }

            public override int GetHashCode()
            {
                string fishy = holder.ToString();
                int yeet = 0;
                int index = 1;
                foreach (char c in fishy)
                {
                    yeet += ((43 * c) + 34) * index;
                    index++;
                }
                return yeet;
            }

            public static bool operator ==(StringHolder left, StringHolder right)
            {
                return EqualityComparer<StringHolder>.Default.Equals(left, right);
            }

            public static bool operator !=(StringHolder left, StringHolder right)
            {
                return !(left == right);
            }

            public static implicit operator StringHolder(string str)
            {
                return new StringHolder(str);
            }
        }

        static void Main(string[] args)
        {
            MapHash<StringHolder, int> hash = new MapHash<StringHolder, int>();

            hash.Add("test", 5);
            hash.Add("hi", 20);
            hash.Add("monopoly", 6);
            hash.Add("something", 149);
            hash.Add("question", 69);
            hash.Add("chickenchickenpie", 123456789);
            hash.Add("ani", 888);
            hash.Add("foot letuce", 15);
            //hash.Add("alex", 222);
            //hash.Add("chris", 700000000);
            //hash.Add("write", 3000);
            //hash.Add("visual", 27);
            //hash.Add("basic", 59);
            //hash.Add("thad", 213);
            //hash.Add("house", 211);
            //hash.Add("is", 210);
            //hash.Add("a", 67);
            //hash.Add("joke", 19);
            //hash.Add("god", 56);
            //hash.Add("and", 39);
            //hash.Add("even", 712);
            //hash.Add("has", 77);
            //hash.Add("a reddit", 561);
            //hash.Add("thread", 934);
            //hash.Add("for", 89);
            //hash.Add("his", 40);
            //hash.Add("jokes", 52);
            //hash.Add("thing", 134);



            Console.WriteLine(hash["foot letuce"]);
            hash["foot letuce"] = 42;
            Console.WriteLine(hash["foot letuce"]);
            hash.Remove("foot letuce");
            Console.WriteLine(hash["foot letuce"]);
            ;
        }
    }
}