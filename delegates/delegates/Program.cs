using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace delegates
{
    class Program
    {

        delegate void Function(string yeet);

        static int Add(int x, int y)
        {
            return x + y;
        }

        static int Mult(int x, int y)
        {
            return x * y;
        }


        static void DoSomething(Predicate<int> pred, int num)
        {
            Console.WriteLine(pred(num));
        }


        class Person : IComparable<Person>
        {
            public int Age { get; private set; }

            public Person(int age)
            {
                Age = age;
            }

            public int CompareTo([AllowNull] Person other)
            {
                return Age.CompareTo(other.Age);
            }
        }


        static void Main(string[] args)
        {
            Function function = Console.WriteLine;

            //function("Blah");

            // Action - variable inputs, but void output
            // Predicate - variable input, bool output
            // Func - variable input, output

            //Predicate<int> IsLessThanZero = (int x) =>
            //{
            //    if (x < 0)
            //    {
            //        return true;
            //    }

            //    return false;
            //};



            List<Person> people = new List<Person>()
            {
                new Person(45),
                new Person(5),
                new Person(15),
                new Person(25),
                new Person(57),
                new Person(35),
                new Person(6),
                new Person(52),
            };


            //Person person = people.Where((person) => person.Age > 50).FirstOrDefault();
            ;

            var person = people.Where(x => x.Age % 2 == 0);

            ;
            //// create a predicate called IsEven with lambda function

            //Predicate<int> IsEven = (int x) =>
            //{
            //    if (x % 2 == 0)
            //    {
            //        return true;
            //    }
            //    return false;
            //};

            //DoSomething(IsEven, 2);




            //Console.WriteLine(IsLessThanZero(-5));

            //Console.WriteLine(IsLessThanZero(5));

            //Console.WriteLine()

            //string op = "*";

            //if (op == "+")
            //{
            //    function = Add;
            //}
            //else
            //{
            //    function = Mult;
            //}

            //Console.WriteLine(function(5,6));



            // create a delegate that takes in a function with string input and void output




        }
    }
}
