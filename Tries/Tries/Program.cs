using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace Tries
{
    class Program
    {

        //class Word
        //{
        //    public int MyProperty { get; set; }
        //}


        static void Main(string[] args)
        {
            Tire tire = new Tire();
            //tire.Insert("fish");
            //tire.Insert("flop");
            //var yeet = tire.GetAllMatchingPrefix("f");


            var jsonstring = File.ReadAllText("fulldictionary.json");

            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonstring);

            foreach (var kvp in dict)
            {
                tire.Insert(kvp.Key);
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Give me word now!!");
                string fish = Console.ReadLine();

                var yeet = tire.GetAllMatchingPrefix(fish);

                if (tire.IsWord(fish))
                {
                    Console.WriteLine(fish + ": " + dict[fish]);
                }
                foreach (var item in yeet)
                {
                    Console.WriteLine(item);
                }

                Console.ReadKey();
            }


        }
    }
}