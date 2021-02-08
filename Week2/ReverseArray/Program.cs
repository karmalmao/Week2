﻿using System;

namespace ReverseArray
{
    class Program
    {

        public static int[] ReverseArray(int[] a)
        {
            int[] b = a;
            Array.Reverse(b);
            return b;
        }
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            for (int i = 0; i < numbers.Length; i++)
                Console.Write($"{numbers[i]}, ");

            Console.WriteLine("");

            int[] reversed = ReverseArray(numbers);

            for (int i = 0; i < reversed.Length; i++)
                Console.Write($"{reversed[i]}, ");

        }
    }
}
