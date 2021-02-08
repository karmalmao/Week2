using System;

namespace CalculateAverage
{
    class Program
    {
        public static int CalculateAverage(int[] a)
        {
            int j = 0;
            int value = 0;
            int index = a[j];
            for (j = 0; j < a.Length; j++)
            {
                value = index + value;
            }
            int ans = value / a.Length;
            return ans;


        }

        static void Main(string[] args)
        {
            int[] numbers = new int[] { 10, 3, 6, 6, 4, 8, 1, 7 };
            Console.WriteLine(CalculateAverage(numbers));
        }

        
    }
}
