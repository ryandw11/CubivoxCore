using System;

namespace CubivoxCore.Exceptions
{
    /// <summary>
    /// This exception is thrown by when a class is missing any property attributes that are required.
    /// </summary>
    public class MissingPropertyExcaption : Exception
    {
        public MissingPropertyExcaption(string message) : base(message)
        { }
    }
}
