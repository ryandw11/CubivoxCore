using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Attributes
{
    /// <summary>
    /// Mark a method to only be executed on the server.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ServerOnly : Attribute
    {
    }
}
