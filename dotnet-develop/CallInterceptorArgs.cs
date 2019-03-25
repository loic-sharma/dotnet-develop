namespace HotReload
{
    // https://github.com/dotnet/corert/blob/123e8740d58d7660313efe6f3500ab082248440d/src/System.Private.TypeLoader/src/Internal/Runtime/TypeLoader/CallInterceptor.cs#L321
    public struct CallInterceptorArgs
    {
        /// <summary>
        /// The set of arguments and return value. The return value is located at the Zero-th index.
        /// </summary>
        public LocalVariableSet ArgumentsAndReturnValue;
        /// <summary>
        /// Convenience set of locals, most like for use with MakeDynamicCall
        /// </summary>
        public LocalVariableSet Locals;
    }

    public struct LocalVariableSet
    {
        /// <summary>
        /// Get the variable at index. Error checking is not performed
        /// </summary>
        public unsafe T GetVar<T>(int index)
        {
            return default(T);
        }

        /// <summary>
        /// Set the variable at index. Error checking is not performed
        /// </summary>
        public unsafe void SetVar<T>(int index, T value)
        {

        }
    }
}
