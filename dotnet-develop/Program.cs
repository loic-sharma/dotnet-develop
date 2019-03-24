using System;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace dotnet_develop
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
                var handle = MetadataTokens.Handle(entryPointToken);
                // TODO Check IsNil
                // TODO Check Kind == MethodDefinition
                var methodDefinitionHandle = (MethodDefinitionHandle)handle;
                var entryPointDefinition = metadataReader.GetMethodDefinition(methodDefinitionHandle);
                var entryPointBody = reader.GetMethodBody(entryPointDefinition.RelativeVirtualAddress);

                // Get the correct number of locals
                // See: https://github.com/dotnet/corert/blob/635cf21aca11265ded9d78d216424bd609c052f5/src/Common/src/TypeSystem/Ecma/EcmaSignatureParser.cs#L242
                var entryPointSignature = metadataReader.GetStandaloneSignature(entryPointBody.LocalSignature);
                var signatureBlobReader = metadataReader.GetBlobReader(entryPointSignature.Signature);
                if (signatureBlobReader.ReadSignatureHeader().Kind != SignatureKind.LocalVariables)
                {
                    throw new BadImageFormatException();
                }
                var localsCount = signatureBlobReader.ReadCompressedInteger();

                // See https://github.com/dotnet/corert/blob/master/src/System.Private.Interpreter/src/Internal/Runtime/Interpreter/ILInterpreter.cs#L78
                var stack = new LowLevelStack<StackItem>();
                var locals = new StackItem[localsCount];
                var ilReader = new ILReader(entryPointBody.GetILBytes());

                while (ilReader.HasNext)
                {
                    var opcode = ilReader.ReadILOpcode();
                    switch (opcode)
                    {
                        case ILOpcode.nop:
                            // Do nothing!
                            break;
                        case ILOpcode.ldloc_0:
                        case ILOpcode.ldloc_1:
                        case ILOpcode.ldloc_2:
                        case ILOpcode.ldloc_3:
                            stack.Push(locals[opcode - ILOpcode.ldloc_0]);
                            break;
                        case ILOpcode.stloc_0:
                        case ILOpcode.stloc_1:
                        case ILOpcode.stloc_2:
                        case ILOpcode.stloc_3:
                            locals[opcode - ILOpcode.stloc_0] = stack.Pop();
                            break;
                        case ILOpcode.ldc_i4_0:
                        case ILOpcode.ldc_i4_1:
                        case ILOpcode.ldc_i4_2:
                        case ILOpcode.ldc_i4_3:
                        case ILOpcode.ldc_i4_4:
                        case ILOpcode.ldc_i4_5:
                        case ILOpcode.ldc_i4_6:
                        case ILOpcode.ldc_i4_7:
                        case ILOpcode.ldc_i4_8:
                            stack.Push(StackItem.FromInt32(opcode - ILOpcode.ldc_i4_0));
                            break;
                        case ILOpcode.add:
                            // TODO handle more than just int 32..
                            stack.Push(StackItem.FromInt32(stack.Pop().AsInt32() + stack.Pop().AsInt32()));
                            break;
                        case ILOpcode.ldstr:
                            var userStringToken = ilReader.ReadILToken();
                            var rawUserStringHandle = MetadataTokens.Handle(userStringToken);
                            // TODO Check Kind == UserString
                            var userStringHandle = (UserStringHandle)rawUserStringHandle;
                            var userString = metadataReader.GetUserString(userStringHandle);
                            stack.Push(StackItem.FromObjectRef(userString));
                            break;

                        case ILOpcode.call:
                            var callToken = ilReader.ReadILToken();
                            var callHandle = MetadataTokens.Handle(callToken);
                            var memberReference = metadataReader.GetMemberReference((MemberReferenceHandle)callHandle);

                            // TODO
                            if (metadataReader.GetString(memberReference.Name) == "WriteLine")
                            {
                                var value = stack.Pop();
                                switch (value.Kind)
                                {
                                    case StackValueKind.ObjRef:
                                        Console.WriteLine(value.AsObjectRef());
                                        break;

                                    case StackValueKind.Int32:
                                        Console.WriteLine(value.AsInt32());
                                        break;
                                }
                            }
                            break;

                        case ILOpcode.ret:
                            // TODO
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }           
            }
        }
    }
}
