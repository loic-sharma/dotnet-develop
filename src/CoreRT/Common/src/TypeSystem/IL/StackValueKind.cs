// https://github.com/dotnet/corert/blob/5e3ccd07b0d787276414315a1c0b38b809ed4b99/src/Common/src/TypeSystem/IL/StackValueKind.cs

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Internal.IL
{
    //
    // Corresponds to "I.12.3.2.1 The evaluation stack" in ECMA spec
    //
    internal enum StackValueKind
    {
        /// <summary>An unknow type.</summary>
        Unknown,
        /// <summary>Any signed or unsigned integer values that can be represented as a 32-bit entity.</summary>
        Int32,
        /// <summary>Any signed or unsigned integer values that can be represented as a 64-bit entity.</summary>
        Int64,
        /// <summary>Underlying platform pointer type represented as an integer of the appropriate size.</summary>
        NativeInt,
        /// <summary>Any float value.</summary>
        Float,
        /// <summary>A managed pointer.</summary>
        ByRef,
        /// <summary>An object reference.</summary>
        ObjRef,
        /// <summary>A value type which is not any of the primitive one.</summary>
        ValueType
    }
}
