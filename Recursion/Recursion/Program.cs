using System;

namespace Recursion
{
    class Program
    {
        static void thingy(int number)
        {
            if (number < 0)
            {
                return;
            }

            Console.WriteLine(number);
            thingy(number - 1);
        }

        // create a recursive function which gives you the sum of the numbers from the number to 0

        static int sum(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            return number + sum(number - 1);
        }

        // create a function to return the factorial value of a number

        static int factorial(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }
            return number * factorial(number - 1);
        }

        // list all the numbers from 0 - 100;

        static void List(int min, int max)
        {
            Console.WriteLine(min);
            if (min == max)
            {
                return;
            }
            List(min + 1, max);
        }

        // return the reverse of a string using a recursive function

        static string revstring(string stringy, int length)
        {
            if (length < 0)
            {
                return "";
            }
            return stringy[length] + revstring(stringy, length - 1);
        }


        //fibbonotchi

        //static void fibonotchi(int one = 0, int two = 1, int three = 1)
        //{
        //    Console.WriteLine(three);
        //    three = one + two;
        //    one = two;
        //    two = three;
        //    fibonotchi();
        //}


        static int fib(int num)
        {
            if (num == 0)
            {
                return 0;
            }

            if (num == 1)
            {
                return 1;
            }

            Console.WriteLine(num);
            return fib(num - 2) + fib(num - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Counting down from 10:");
            thingy(10);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Sum of numbers 10 - 0:");
            int x = sum(10);
            Console.WriteLine(x);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Factorial of 6:");
            Console.WriteLine(factorial(6));
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("The reverse of 'test':");
            string test = "test";

            string stringy = revstring(test, test.Length - 1);

            Console.WriteLine(stringy);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("All numbers 0 - 100:");
            List(0, 100);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Fibonotchi:");
            fib(15);
        }
    }
}
