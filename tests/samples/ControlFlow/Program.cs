using System;

namespace ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                Console.WriteLine("If pass");
            }
            else
            {
                Console.WriteLine("If fail");
            }

            if (false)
            {
                Console.WriteLine("Else fail");
            }
            else
            {
                Console.WriteLine("Else pass");
            }

            for (var i = 0; i < 2; i++)
            {
                Console.WriteLine(i);
            }

            var j = 0;
            while (j < 2)
            {
                Console.WriteLine(j);
                j++;
            }
        }
    }
}
