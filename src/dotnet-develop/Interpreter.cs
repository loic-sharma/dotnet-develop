using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using Internal.Runtime.Interpreter;
using Internal.TypeSystem;

namespace DotnetDevelop
{
    public class Interpreter
    {
        public void InterpretDll(string path, string[] args)
        {
            using (var stream = File.OpenRead(path))
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

                var arguments = PrepareEntryPointArguments(entryPoint, args);

                var interpreter = new ILInterpreter(reader, metadataReader, entryPoint, entryPointBody);
                interpreter.InterpretMethod(ref arguments);
            }
        }

        private StackItem[] PrepareEntryPointArguments(MethodDefinition entryPoint, string[] args)
        {
            var signature = entryPoint.DecodeSignature(SignatureTypeCodeProvider.Instance, null);
            if (signature.ParameterTypes.Length > 1)
            {
                ThrowHelper.ThrowInvalidProgramException();
            }

            // The first argument is the return value
            var arguments = new StackItem[signature.ParameterTypes.Length + 1];
            if (signature.ParameterTypes.Length == 1)
            {
                //if (signature.ParameterTypes[0] != SignatureTypeCode.Array)
                //{
                //    ThrowHelper.ThrowInvalidProgramException();
                //}

                arguments[1] = StackItem.FromObjectRef(args);
            }

            return arguments;
        }
    }
}
