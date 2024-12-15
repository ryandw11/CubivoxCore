using CubivoxCore.Attributes;
using CubivoxCore.Exceptions;
using CubivoxCore.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace CubivoxCore.Networking
{
    /// <summary>
    /// Register and use transports to communicate between clients and the server.
    /// </summary>
    public abstract class TransportRegistry
    {
        protected Dictionary<Type, IServerTransport> mServerTransports;
        protected Dictionary<Type, IClientTransport> mClientTransports;
        protected Dictionary<ControllerKey, Type> mTypeMap;

        public TransportRegistry()
        {
            mServerTransports = new Dictionary<Type, IServerTransport>();
            mClientTransports = new Dictionary<Type, IClientTransport>();
            mTypeMap = new Dictionary<ControllerKey, Type>();
        }

        /// <summary>
        /// Register a client transport for use. This must be called on BOTH clients and the server
        /// in order to be used.
        /// </summary>
        /// <typeparam name="T">The transport delegate to register.</typeparam>
        /// <param name="key">The controller key to register the delegate for.</param>
        /// <param name="transportDelegate">The transport delegate to register. If null, the delegate type will just be registered.</param>
        /// <exception cref="InvalidTransportTypeException">If the delegate type T contains invalid types.</exception>
        /// <exception cref="TransportTypeException">If the delegate type T does not match what is already registered for the specified ControllerKey.</exception>
        public void RegisterClientTransport<T>(ControllerKey key, T? transportDelegate = null) where T : Delegate
        {
            // If the key already exists, try to register that delegate to the transport.
            Type transportDelegateType;
            if(mTypeMap.TryGetValue(key, out transportDelegateType) )
            {
                IClientTransport clientTransport = mClientTransports[transportDelegateType];
                try
                {
                    ClientTransport<T> typedClientTransport = (ClientTransport<T>) clientTransport;
                    if (transportDelegate != null)
                    {
                        typedClientTransport.Register(transportDelegate);
                    }
                    return;
                }
                catch(InvalidCastException)
                {
                    // The T delegate type does not match what is already defined for the existing key, error out.
                    throw new TransportTypeException();
                }
            }

            if( transportDelegate == null )
            {
                // Already exists.
                return;
            }

            // Else, add it.
            var transport = CreateClientTransport<T>(key);
            transport.Register(transportDelegate);
            mClientTransports.Add(typeof(T), transport);
            mTypeMap.Add(key, typeof(T));
        }

        /// <summary>
        /// Register a server transport for use. This must be called on BOTH clients and the server
        /// in order to be used.
        /// </summary>
        /// <typeparam name="T">The transport delegate to register.</typeparam>
        /// <param name="key">The controller key to register the delegate for.</param>
        /// <param name="transportDelegate">The transport delegate to register. If null, the delegate type will just be registered.</param>
        /// <exception cref="InvalidTransportTypeException">If the delegate type T contains invalid types, or if the first parameter type is not <see cref="Player"/>.</exception>
        /// <exception cref="TransportTypeException">If the delegate type T does not match what is already registered for the specified ControllerKey.</exception>
        public void RegisterServerTransport<T>(ControllerKey key, T? transportDelegate = null) where T : Delegate
        {
            // If the key already exists, try to register that delegate to the transport.
            Type transportDelegateType;
            if (mTypeMap.TryGetValue(key, out transportDelegateType))
            {
                IServerTransport serverTransport = mServerTransports[transportDelegateType];
                try
                {
                    ServerTransport<T> typedServerTransport = (ServerTransport<T>) serverTransport;
                    if(transportDelegate != null)
                    {
                        typedServerTransport.Register(transportDelegate);
                    }
                    return;
                }
                catch (InvalidCastException)
                {
                    // The T delegate type does not match what is already defined for the existing key, error out.
                    throw new TransportTypeException();
                }
            }

            if(transportDelegate == null )
            {
                // Type already exists.
                return;
            }

            // Else, add it.
            var transport = CreateServerTransport<T>(key);
            transport.Register(transportDelegate);
            mServerTransports.Add(typeof(T), transport);
            mTypeMap.Add(key, typeof(T));
        }

        /// <summary>
        /// Transport data from a server to a client. (Trigger a client transport).
        /// Ensure that the delegate T is registered using the <see cref="RegisterClientTransport{T}(ControllerKey, T)"/>
        /// method (on both the client and the server).
        /// <para>This should only be called on the server.</para>
        /// </summary>
        /// <typeparam name="T">The delegate for the transport to use.</typeparam>
        /// <param name="player">The player to send the data to.</param>
        /// <param name="parameters">The data to send to the player. The types must match those defined in the delegate T.</param>
        /// <exception cref="ArgumentException">If the provided parameters doesn't match the types in the provided delegate.</exception>
        /// <exception cref="InvalidEnvironmentException">If this method is called on a client.</exception>
        [ServerOnly]
        public abstract void Transport<T>(Player player, params object[] parameters) where T : Delegate;

        /// <summary>
        /// Transport data from a client to The server. (Trigger a server transport).
        /// Ensure that the delegate T is registered using the <see cref="RegisterServerTransport{T}(ControllerKey, T)"/>
        /// method (on both the client and the server).
        /// <para>This should only be called on clients.</para>
        /// </summary>
        /// <typeparam name="T">The delegate for the transport to use.</typeparam>
        /// <param name="parameters">The data to send to the server. The types must match those defined in the delegate T.</param>
        /// <exception cref="ArgumentException">If the provided parameters doesn't match the types in the provided delegate.</exception>
        /// <exception cref="InvalidEnvironmentException">If this method is called on the server.</exception>
        [ClientOnly]
        public abstract void Transport<T>(params object[] parameters) where T : Delegate;

        protected abstract ClientTransport<T> CreateClientTransport<T>(ControllerKey key) where T : Delegate;
        protected abstract ServerTransport<T> CreateServerTransport<T>(ControllerKey key) where T : Delegate;
    }
}
