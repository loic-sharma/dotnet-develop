using System;

namespace dotnet_develop
{
    public static partial class ThrowHelper
    {
        [System.Diagnostics.DebuggerHidden]
        public static void ThrowInvalidProgramException()
        {
            throw new InvalidOperationException("Invalid program");
        }
    }
}
