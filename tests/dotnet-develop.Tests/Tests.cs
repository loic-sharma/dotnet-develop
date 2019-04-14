using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace dotnet_develop.Tests
{
    // TODO: Fix path in "Run"
    // TODO: Place expected output on samples themselves as comments. Use roslyn to parse expected output.
    public class Tests
    {
        [Fact]
        public void HelloWorld()
        {
            var result = Run("HelloWorld");
            var expected = ExpectedOutput("Hello world");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Math()
        {
            var result = Run("Math");
            var expected = ExpectedOutput(
                "3",
                "-1",
                "2",
                "0",
                "2",
                "1");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ControlFlow()
        {
            var result = Run("ControlFlow");
            var expected = ExpectedOutput(
                "If pass",
                "Else pass",
                "0",
                "1",
                "0",
                "1");

            Assert.Equal(expected, result);
        }

        private static string Run(string name)
        {
            var path = $@"D:\Code\dotnet-develop\tests\samples\{name}\bin\Debug\netcoreapp2.2\{name}.dll";
            if (!File.Exists(path))
            {
                throw new Exception($"Dll '{path}' could not be found, try building the solution");
            }

            string output;
            using (var process = new Process())
            {
                process.StartInfo.WorkingDirectory = @"D:\Code\dotnet-develop\src\dotnet-develop";
                process.StartInfo.FileName = @"C:\Program Files\dotnet\dotnet.exe";
                process.StartInfo.Arguments = $"run -- {path}";

                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();

                output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }

            return output;
        }

        private static string ExpectedOutput(params string[] output)
        {
            return string.Join(Environment.NewLine, output) + Environment.NewLine;
        }
    }
}
