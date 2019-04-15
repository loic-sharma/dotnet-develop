using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Xunit;

namespace dotnet_develop.Tests
{
    // TODO: Place expected output on samples themselves as comments. Use Roslyn to parse expected output.
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

        [Fact]
        public void Arrays()
        {
            var result = Run("Arrays");
            var expected = ExpectedOutput(
                "1",
                "2");

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Methods()
        {
            var result = Run("Methods");
            var expected = ExpectedOutput(
                "123",
                "456");

            Assert.Equal(expected, result);
        }

        private static string Run(string name)
        {
            var testAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var samplesPath = Path.GetFullPath(Path.Combine(testAssemblyPath, "..", "..", "..", "..", "..", "samples"));
            var toolPath = Path.GetFullPath(Path.Combine(testAssemblyPath, "..", "..", "..", "..", "..", "..", "src", "dotnet-develop"));

            var dllPath = Path.Combine(samplesPath, name, "bin", "Debug", "netcoreapp2.2", $"{name}.dll");
            if (!File.Exists(dllPath))
            {
                throw new Exception($"Dll '{dllPath}' could not be found, try building the solution");
            }

            //DotnetDevelop.Program.Main(new string[] { dllPath });

            string output;
            using (var process = new Process())
            {
                process.StartInfo.WorkingDirectory = toolPath;
                process.StartInfo.FileName = @"C:\Program Files\dotnet\dotnet.exe";
                process.StartInfo.Arguments = $"run -- {dllPath}";

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
