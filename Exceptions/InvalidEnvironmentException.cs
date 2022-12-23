using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Exceptions
{
    public class InvalidEnvironmentException : Exception
    {
        public InvalidEnvironmentException()
        { }

        public InvalidEnvironmentException(string message) : base(message)
        { }
    }
}
