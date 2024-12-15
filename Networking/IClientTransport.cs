using CubivoxCore.Attributes;
using CubivoxCore.Players;

namespace CubivoxCore.Networking
{
    /// <summary>
    /// The general purpose ClientTransport interface for Server -> Client communications.
    /// 
    /// <para>This interface is mainly for internal use. See <see cref="ClientTransport{T}"/> to use client transports.</para>
    /// </summary>
    public interface IClientTransport
    {
        /// <summary>
        /// Get the parameter types for the associated delegate.
        /// </summary>
        /// <returns>An array with the parameter types</returns>
        Type[] GetParameterTypes();

        /// <summary>
        /// Invoke the transport to send data to a client.
        /// </summary>
        /// <param name="player">The player to send the data to.</param>
        /// <param name="parameters">The data to send to the server. This must match the parameters in the delegate.</param>
        /// <exception cref="ArgumentException">If the provided parameters doesn't match the types in the provided delegate.</exception>
        [ServerOnly]
        void Invoke(Player player, params object[] parameters);

        /// <summary>
        /// Get the controller key for the transport.
        /// </summary>
        /// <returns>The controller key for the transport.</returns>
        ControllerKey GetControllerKey();
    }
}
