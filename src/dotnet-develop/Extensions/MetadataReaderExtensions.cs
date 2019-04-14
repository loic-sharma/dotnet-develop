using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace HotReload
{
    internal static class MetadataReaderExtensions
    {
        // See: https://github.com/dotnet/corert/blob/635cf21aca11265ded9d78d216424bd609c052f5/src/Common/src/TypeSystem/Ecma/EcmaSignatureParser.cs#L242
        public static int GetLocalsCount(this MetadataReader reader, MethodBodyBlock method)
        {
            if (method.LocalSignature.IsNil)
            {
                return 0;
            }

            var entryPointSignature = reader.GetStandaloneSignature(method.LocalSignature);
            var signatureBlobReader = reader.GetBlobReader(entryPointSignature.Signature);
            if (signatureBlobReader.ReadSignatureHeader().Kind != SignatureKind.LocalVariables)
            {
                throw new BadImageFormatException();
            }

            return signatureBlobReader.ReadCompressedInteger();
        }

        public static void ParseMethodSignature(this MetadataReader reader, MethodDefinition method)
        {
//            method.DecodeSignature
        }

        public static Handle AsHandle(this int token)
        {
            return MetadataTokens.Handle(token);
        }
    }
}
