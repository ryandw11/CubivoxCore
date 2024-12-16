using CubivoxCore.Attributes;
using CubivoxCore.Exceptions;
using CubivoxCore.Mods;
using CubivoxCore.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace CubivoxCore.Networking
{
    /// <summary>
    /// Transports are the main way for mods to communicate between the server and clients.
    /// 
    /// <para>ClientTransports sends data to a client. (Server -> Client)</para>
    /// <para>ServerTransports sends data to the server. (Client -> Server)</para>
    /// <para>Client and Server transports must be registered (on both clients and the server) before they can be used. It is best practice to register transports
    /// when the mod is enabled using <see cref="CubivoxMod.OnEnable"/>.</para>
    /// 
    /// <para>This is a utility class that wraps around <see cref="TransportRegistry"/>.</para>
    /// </summary>
    public sealed class Transporter
    {
        /// <summary>
        /// Register a client transport for use. This must be called on BOTH clients and the server
        /// in order to be used.
        /// </summary>
        /// <typeparam name="T">The transport delegate to register.</typeparam>
        /// <param name="key">The controller key to register the delegate for.</param>
        /// <param name="transportDelegate">The transport delegate to register.</param>
        /// <exception cref="InvalidTransportTypeException">If the delegate type T contains invalid types.</exception>
        /// <exception cref="TransportTypeException">If the delegate type T does not match what is already registered for the specified ControllerKey.</exception>
        public static void RegisterClientTransport<T>(ControllerKey key, T? transportDelegate = null) where T : Delegate
        {
            Cubivox.GetTransportRegistry().RegisterClientTransport(key, transportDelegate);
        }

        /// <summary>
        /// Register a server transport for use. This must be called on BOTH clients and the server
        /// in order to be used.
        /// </summary>
        /// <typeparam name="T">The transport delegate to register.</typeparam>
        /// <param name="key">The controller key to register the delegate for.</param>
        /// <param name="transportDelegate">The transport delegate to register.</param>
        /// <exception cref="InvalidTransportTypeException">If the delegate type T contains invalid types, or if the first parameter type is not <see cref="Player"/>.</exception>
        /// <exception cref="TransportTypeException">If the delegate type T does not match what is already registered for the specified ControllerKey.</exception>
        public static void RegisterServerTransport<T>(ControllerKey key, T? transportDelegate = null) where T : Delegate
        {
            Cubivox.GetTransportRegistry().RegisterServerTransport(key, transportDelegate);
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
        public static void Transport<T>(Player player, params object[] parameters) where T : Delegate
        {
            Cubivox.GetTransportRegistry().Transport<T>(player, parameters);
        }

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
        public static void Transport<T>(params object[] parameters) where T : Delegate
        {
            Cubivox.GetTransportRegistry().Transport<T>(parameters);
        }
    }
}
