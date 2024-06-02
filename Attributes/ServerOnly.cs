namespace CubivoxCore.Attributes
{
    /// <summary>
    /// Mark a method to only be executed on the server. 
    /// 
    /// <para>Specific APIs, like the Event API, will respect this marking on methods and only call the method if running on the server.
    /// Please see the Cubivox documentation for the list of valid APIs which respect this attribute.</para>
    /// 
    /// <para>The CubivoxCore library also uses this attrbitue to mark methods or clases as being for the Server only. Please see the respective
    /// documentation for details on what the method / class does if used on the client.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Interface)]
    public class ServerOnly : Attribute
    {
    }
}
