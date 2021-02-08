using System;

namespace lmao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("name?");
            string one = Console.ReadLine();
            Console.WriteLine("thinking");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("hmmm");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine($"yep {one} is a fuckwit lmao");
            Console.WriteLine("");
            Console.Write("press something to close");
            Console.ReadKey();
        }
    }
}
