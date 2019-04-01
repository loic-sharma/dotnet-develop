using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace HotReload
{
    public class SignatureTypeProvider : ISignatureTypeProvider<Type, object>
    {
        public static readonly SignatureTypeProvider Instance = new SignatureTypeProvider();

        public Type GetArrayType(Type elementType, ArrayShape shape)
        {
            throw new NotImplementedException();
        }

        public Type GetByReferenceType(Type elementType)
        {
            throw new NotImplementedException();
        }

        public Type GetFunctionPointerType(MethodSignature<Type> signature)
        {
            throw new NotImplementedException();
        }

        public Type GetGenericInstantiation(Type genericType, ImmutableArray<Type> typeArguments)
        {
            throw new NotImplementedException();
        }

        public Type GetGenericMethodParameter(object genericContext, int index)
        {
            throw new NotImplementedException();
        }

        public Type GetGenericTypeParameter(object genericContext, int index)
        {
            throw new NotImplementedException();
        }

        public Type GetModifiedType(Type modifier, Type unmodifiedType, bool isRequired)
        {
            throw new NotImplementedException();
        }

        public Type GetPinnedType(Type elementType)
        {
            throw new NotImplementedException();
        }

        public Type GetPointerType(Type elementType)
        {
            throw new NotImplementedException();
        }

        public Type GetPrimitiveType(PrimitiveTypeCode typeCode)
        {
            switch (typeCode)
            {
                case PrimitiveTypeCode.Void: return typeof(void);
                case PrimitiveTypeCode.Boolean: return typeof(bool);
                case PrimitiveTypeCode.Char: return typeof(char);
                case PrimitiveTypeCode.SByte: return typeof(sbyte);
                case PrimitiveTypeCode.Byte: return typeof(byte);
                case PrimitiveTypeCode.Int16: return typeof(Int16);
                case PrimitiveTypeCode.UInt16: return typeof(UInt16);
                case PrimitiveTypeCode.Int32: return typeof(Int32);
                case PrimitiveTypeCode.UInt32: return typeof(UInt32);
                case PrimitiveTypeCode.Int64: return typeof(Int64);
                case PrimitiveTypeCode.UInt64: return typeof(UInt64);
                case PrimitiveTypeCode.Single: return typeof(Single);
                case PrimitiveTypeCode.Double: return typeof(double);
                case PrimitiveTypeCode.String: return typeof(string);

                default:
                    throw new NotImplementedException();
            }
        }

        public Type GetSZArrayType(Type elementType)
        {
            throw new NotImplementedException();
        }

        public Type GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
        {
            throw new NotImplementedException();
        }

        public Type GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
        {
            throw new NotImplementedException();
        }

        public Type GetTypeFromSpecification(MetadataReader reader, object genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
        {
            throw new NotImplementedException();
        }
    }
}
