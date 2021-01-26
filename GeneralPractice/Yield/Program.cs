using System;
using System.Collections.Generic;

namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            foreach (var i in PositiveInts(5))
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("yield break example: ");

            foreach (var i in PositiveInts2(5))
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Yield on property");

            foreach (var n in Names)
            {
                Console.WriteLine(n);
            }
        }

        public static IEnumerable<string> Names
        {
            get
            {
                yield return "James";
                yield return "John";
                yield return "Mike";
            }
        }

        public static IEnumerable<int> PositiveInts2(int max)
        {
            int i = 1;
            while (true)
            {
                yield return i++;
                if (i >= max)
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<int> PositiveInts(int max)
        {
            //var list = new List<int>(); // normally we would create a list and return it
            for (int i = 1; i < max; i++)
            {
                //list.Add(i);
                yield return i; // lazy loaded - it's not creating the list completely, it just generates the value when called
            }
            //return list; // normal return 
        }
    }
}
