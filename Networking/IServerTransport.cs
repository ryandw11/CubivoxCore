using CubivoxCore.Attributes;

namespace CubivoxCore.Networking
{
    /// <summary>
    /// The general purpose ServerTransport interface for Client -> Server communications.
    /// 
    /// <para>This interface is mainly for internal use. See <see cref="ServerTransport{T}"/> to use server transports. </para>
    /// </summary>
    public interface IServerTransport
    {
        /// <summary>
        /// Get the parameter types for the associated delegate.
        /// </summary>
        /// <returns>An array with the parameter types</returns>
        Type[] GetParameterTypes();

        /// <summary>
        /// Invoke the transport to send data to the server.
        /// </summary>
        /// <param name="parameters">The data to send to the server. This must match the parameters in the delegate (excluding the first Player parameter).</param>
        /// <exception cref="ArgumentException">If the provided parameters doesn't match the types in the provided delegate.</exception>
        [ClientOnly]
        void Invoke(params object[] parameters);

        /// <summary>
        /// Get the controller key for the transport.
        /// </summary>
        /// <returns>The controller key for the transport.</returns>
        ControllerKey GetControllerKey();
    }
}
