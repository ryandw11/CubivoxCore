using CubivoxCore.Attributes;
using CubivoxCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CubivoxCore.Networking
{
    /// <summary>
    /// A ServerTransport is a transport for Client -> Server communications.
    /// </summary>
    /// <typeparam name="T">The transport delegate. The first parameter of the delegate must be a Player type to represent which player sent the transport message.</typeparam>
    public abstract class ServerTransport<T> : IServerTransport where T : Delegate
    {
        protected ControllerKey mKey;

        /// <summary>
        /// Construct a server transport.
        /// </summary>
        /// <param name="key">The key of the transport.</param>
        /// <exception cref="InvalidTransportTypeException">If T has a parameter that is not supported for transports.</exception>
        public ServerTransport(ControllerKey key)
        {
            mKey = key;
        }

        /// <inheritdoc/>
        public ControllerKey GetControllerKey()
        {
            return mKey;
        }

        /// <inheritdoc/>
        public Type[] GetParameterTypes()
        {
            var methodInfo = typeof(T).GetMethod("Invoke");
            var parameters = methodInfo.GetParameters();

            Type[] allTypes = new Type[parameters.Length];
            if( allTypes.Length < 1)
            {
                // Error: Invalid delegate.
                return new Type[] { };
            }

            for( int i = 0; i < parameters.Length; ++i )
            {
                allTypes[i] = parameters[i].ParameterType;
            }

            return allTypes;
        }

        /// <summary>
        /// Invoke the transport to send data to the server.
        /// </summary>
        /// <param name="parameters">The data to send to the server. This must match the parameters in the delegate (excluding the first Player parameter).</param>
        /// <exception cref="ArgumentException">If the provided parameters doesn't match the types in the provided delegate.</exception>
        [ClientOnly]
        public abstract void Invoke(params object[] parameters);

        /// <summary>
        /// Register a delegate to be executed on the server.
        /// </summary>
        /// <param name="method">The delegate to execute.</param>
        [ServerOnly]
        public abstract void Register(T method);
    }
}
