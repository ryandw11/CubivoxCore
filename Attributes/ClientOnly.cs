using System;

namespace CubivoxCore.Attributes
{
    /// <summary>
    /// Mark a method to only be executed on the client. 
    /// 
    /// <para>Specific APIs, like the Event API, will respect this marking on methods and only call the method if running on the client.
    /// Please see the Cubivox documentation for the list of valid APIs which respect this attribute.</para>
    /// 
    /// <para>The CubivoxCore library also uses this attrbitue to mark methods or clases as being for the Client only. Please see the respective
    /// documentation for details on what the method / class does if used on the server.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface)]
    public class ClientOnly : Attribute
    {
    }
}
