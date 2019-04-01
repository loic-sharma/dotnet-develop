using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace HotReload
{
    public class SignatureTypeProvider : ISignatureTypeProvider<SignatureTypeCode, object>
    {
        public static readonly SignatureTypeProvider Instance = new SignatureTypeProvider();

        public SignatureTypeCode GetArrayType(SignatureTypeCode elementType, ArrayShape shape)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetByReferenceType(SignatureTypeCode elementType)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetFunctionPointerType(MethodSignature<SignatureTypeCode> signature)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetGenericInstantiation(SignatureTypeCode genericType, ImmutableArray<SignatureTypeCode> typeArguments)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetGenericMethodParameter(object genericContext, int index)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetGenericTypeParameter(object genericContext, int index)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetModifiedType(SignatureTypeCode modifier, SignatureTypeCode unmodifiedType, bool isRequired)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetPinnedType(SignatureTypeCode elementType)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetPointerType(SignatureTypeCode elementType)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetPrimitiveType(PrimitiveTypeCode typeCode)
        {
            return (SignatureTypeCode)typeCode;
        }

        public SignatureTypeCode GetSZArrayType(SignatureTypeCode elementType)
        {
            // TODO: Return the type of the array?
            return elementType;
        }

        public SignatureTypeCode GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
        {
            throw new System.NotImplementedException();
        }

        public SignatureTypeCode GetTypeFromSpecification(MetadataReader reader, object genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
        {
            throw new System.NotImplementedException();
        }
    }
}
