using System;




namespace Arrays2
{
    class Program
    {
        static float FindNeedle(string[] a)
        {
            return Array.IndexOf(a, "needle");
            
        }
        static void Main(string[] args)
        {
            var strings = new string[] { "hay", "junk", "hay", "hay", "moreJunk", "needle", "randomJunk" };

            var needleLocation = FindNeedle(strings);

            Console.Write(needleLocation);

            // TODO: output to the console.
        }
    }
}
