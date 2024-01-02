using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Attributes
{
    /// <summary>
    /// Mark a method to only be executed on the client.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ClientOnly : Attribute
    {
    }
}
