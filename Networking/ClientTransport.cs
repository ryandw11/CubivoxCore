using CubivoxCore.Attributes;
using CubivoxCore.Networking.DataFormat;
using CubivoxCore.Players;

namespace CubivoxCore.Networking
{
    /// <summary>
    /// A ClientTransport is a transport for Server -> Client communications.
    /// </summary>
    /// <typeparam name="T">The transport delegate.</typeparam>
    public abstract class ClientTransport<T> : IClientTransport where T : Delegate
    {
        protected ControllerKey mKey;

        public ClientTransport(ControllerKey key)
        {
            mKey = key;

            TransportFormat.AssertSupportedTypes(GetParameterTypes());
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
            if (allTypes.Length < 1)
            {
                // Error: Invalid delegate.
                return new Type[] { };
            }

            for (int i = 0; i < parameters.Length; ++i)
            {
                allTypes[i] = parameters[i].ParameterType;
            }

            return allTypes;
        }

        /// <inheritdoc/>
        [ServerOnly]
        public abstract void Invoke(Player player, params object[] parameters);

        /// <summary>
        /// Register a delegate to be executed on clients.
        /// </summary>
        /// <param name="method">The delegate to execute.</param>
        [ClientOnly]
        public abstract void Register(T method);
    }
}
