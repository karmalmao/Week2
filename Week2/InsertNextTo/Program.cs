using System;

namespace InsertNextTo
{
    class Program
    {
        public static string[] InsertWorld(string[] a)
        {
            int[] terms = new int[400];
        }
        static void Main(string[] args)
        {
            var strings = new string[] { "hello", "the", "quick", "brown", "fox", "hello", "something" };
            for (int i = 0; i < strings.Length; i++)
                Console.Write($"{strings[i]} ");

            Console.WriteLine("");
            var strings2 = InsertWorld(strings);

            

            for (int i = 0; i < strings2.Length; i++)
                Console.Write($"{strings2[i]} ");
        }
    }
}
