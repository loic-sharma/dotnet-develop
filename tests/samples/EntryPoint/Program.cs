using System;

namespace EntryPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
