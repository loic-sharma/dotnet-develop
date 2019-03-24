// This file was based off of:
// https://github.com/dotnet/corert/blob/5e3ccd07b0d787276414315a1c0b38b809ed4b99/src/Common/src/TypeSystem/Common/ThrowHelper.cs#L1

namespace Internal.TypeSystem
{
    public static partial class ThrowHelper
    {
        [System.Diagnostics.DebuggerHidden]
        public static void ThrowInvalidProgramException()
        {
            throw new System.InvalidOperationException("Invalid program");
        }
    }
}
