using System;
using System.Linq;

namespace HotReload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("Please provide a path to a DLL");
                return;
            }

            var path = args[0];
            var dllArgs = ParseDllArgs(args);

            new Interpreter().InterpretDll(path, dllArgs);
        }

        private static string[] ParseDllArgs(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i].Trim() == "--")
                {
                    return args.Skip(i + 1).ToArray();
                }
            }

            return new string[0];
        }
    }
}
