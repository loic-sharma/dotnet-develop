using System;

namespace Methods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(A());
            Console.WriteLine(B(456));
        }

        public static int A()
        {
            return 123;
        }

        public static int B(int input) => input;
    }
}
