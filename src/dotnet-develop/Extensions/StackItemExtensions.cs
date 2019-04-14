using System;
using System.Reflection.Metadata;
using Internal.IL;
using Internal.Runtime.Interpreter;

namespace DotnetDevelop
{
    internal static class StackItemExtensions
    {
        public static object ToObject(ref this StackItem item)
        {
            switch (item.Kind)
            {
                case StackValueKind.Int32:
                    return item.AsInt32Unchecked();

                case StackValueKind.Int64:
                    return item.AsInt64Unchecked();

                case StackValueKind.NativeInt:
                    return item.AsNativeIntUnchecked();

                case StackValueKind.Float:
                    return item.AsDoubleUnchecked();

                case StackValueKind.ObjRef:
                    return item.AsObjectRef();

                default:
                case StackValueKind.ValueType:
                case StackValueKind.ByRef:
                    throw new NotImplementedException();
            }
        }

        public static StackItem ToStackItem(this object value, Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                case TypeCode.Byte:
                case TypeCode.Char:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                    return StackItem.FromInt32((int)value);
                case TypeCode.DateTime:
                    break;
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return StackItem.FromDouble((double)value);
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return StackItem.FromInt64((long)value);
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.String:
                    return StackItem.FromObjectRef(value);
                default:
                    throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}
