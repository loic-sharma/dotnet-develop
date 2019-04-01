using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using Internal.Runtime.Interpreter;
using Internal.TypeSystem;

namespace HotReload
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var stream = File.OpenRead(@"D:\Code\dotnet-develop\samples\HelloWorld\bin\Debug\netcoreapp2.2\HelloWorld.dll"))
            using (var reader = new PEReader(stream))
            {
                var metadataReader = reader.GetMetadataReader();

                // https://github.com/dotnet/corefx/blob/cea2a3e00c9a508fbf92bcaf0aeb4df833514057/src/System.Reflection.MetadataLoadContext/src/System/Reflection/TypeLoading/Modules/Ecma/EcmaModule.cs#L50
                var entryPointToken = reader.PEHeaders.CorHeader.EntryPointTokenOrRelativeVirtualAddress;
                var handle = entryPointToken.AsHandle();
                if (handle.Kind != HandleKind.MethodDefinition)
                {
                    ThrowHelper.ThrowInvalidProgramException();
                }

                var entryPoint = metadataReader.GetMethodDefinition((MethodDefinitionHandle)handle);
                var entryPointBody = reader.GetMethodBody(entryPoint.RelativeVirtualAddress);

                // TODO: Pass CLI arguments down to entry point.
                var interpreter = new ILInterpreter(reader, metadataReader, entryPoint, entryPointBody);
                var arguments = new StackItem[0];

                interpreter.InterpretMethod(ref arguments);
            }
        }
    }
}
