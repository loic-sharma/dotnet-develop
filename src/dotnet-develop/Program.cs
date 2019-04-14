namespace HotReload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = @"D:\Code\dotnet-develop\tests\samples\HelloWorld\bin\Debug\netcoreapp2.2\HelloWorld.dll";
            if (args.Length > 0)
            {
                path = args[args.Length - 1];
            }

            new Interpreter().InterpretDll(path);
        }
    }
}
