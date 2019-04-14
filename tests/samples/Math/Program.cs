using System;

namespace Math
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var a = 1;
            var b = 2;

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);

            a++;
            b--;

            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
