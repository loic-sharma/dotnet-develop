using System;

namespace Arrays
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var a = new int[2];
            a[0] = 1;
            a[1] = 2;

            Console.WriteLine(a[0]);
            Console.WriteLine(a[1]);

            // TODO: This generates a static field and calls RuntimeHelpers::InitializeArray
            //var b = new int[] { 1, 2, 3, 4, 5 };

            //Console.WriteLine(b[3]);
            //Console.WriteLine(b[4]);
        }
    }
}
