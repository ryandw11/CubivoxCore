using System;

namespace CubivoxCore.Exceptions
{
    /// <summary>
    /// This exception is thrown by some methods when it is not supported to call this on a specific environment.
    /// </summary>
    public class InvalidEnvironmentException : Exception
    {
        public InvalidEnvironmentException()
        { }

        public InvalidEnvironmentException(string message) : base(message)
        { }
    }
}
