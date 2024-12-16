using CubivoxCore.Attributes;
using CubivoxCore.Console;
using CubivoxCore.Events;
using CubivoxCore.Exceptions;
using CubivoxCore.Items;
using CubivoxCore.Mods;
using CubivoxCore.Networking;
using CubivoxCore.Players;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;
using CubivoxCore.Worlds;
using CubivoxCore.Worlds.Generation;
using System;
using System.Collections.ObjectModel;

namespace CubivoxCore
{
    /// <summary>
    /// The Mod that represents the Cubivox game itself.
    /// <br/>
    /// This is special and implemented by both the Client and Server.
    /// <br/>
    /// This class contains all the important components of Cubivox, such as the <see cref="ItemRegistry"/>.
    /// </summary>
    public abstract class Cubivox : Mod
    {
        protected static Cubivox instance;

        protected GeneratorRegistry generatorRegistry;
        protected ItemRegistry itemRegistry;
        protected TextureAtlas textureAtlas;
        protected EventManager eventManager;
        protected TransportRegistry transportRegistry;

        public string[] GetAuthors()
        {
            return new string[] { "Ryandw11" };
        }

        public string GetName()
        {
            return "Cubivox";
        }

        public string GetUppercaseName()
        {
            return "CUBIVOX";
        }

        public string GetVersion()
        {
            return "1.0";
        }

        public string GetDescription()
        {
            return "Cubivox";
        }

        public abstract void OnEnable();
        public abstract void LoadItemsStage(ItemRegistry registry);
        public abstract void LoadGeneratorsStage(GeneratorRegistry registry);
        public abstract Logger GetLogger();
        public abstract EnvType GetEnvType();
        public abstract ReadOnlyCollection<Player> GetOnlinePlayersImpl();
        public abstract ReadOnlyCollection<World> GetWorldsImpl();

        /// <summary>
        /// Assert that the code is executing on the server.
        /// </summary>
        public abstract void AssertServer();
        /// <summary>
        /// Assert that the code is executing on the client.
        /// </summary>
        public abstract void AssertClient();

        /// <summary>
        /// Get all of the online players on the server.
        /// </summary>
        /// <returns>All players currently online.</returns>
        public static ReadOnlyCollection<Player> GetOnlinePlayers()
        {
            return GetInstance().GetOnlinePlayersImpl();
        }

        /// <summary>
        /// Get an online player using their UUID.
        /// </summary>
        /// <param name="uuid">The UUID of the player to find.</param>
        /// <returns>The player or null if not found.</returns>
        public static Player GetPlayerByUuid(Guid uuid)
        {
            return GetInstance().GetOnlinePlayersImpl().FirstOrDefault(player => player.GetUUID() == uuid);
        }

        /// <summary>
        /// Get all of the loaded worlds.
        /// <para>This will only contain the current world on Clients.</para>
        /// </summary>
        /// <returns>All of the loaded worlds.</returns>
        public static ReadOnlyCollection<World> GetWorlds()
        {
            return GetInstance().GetWorldsImpl();
        }

        /// <summary>
        /// Broadcast a message to every player on the server and the console.
        /// </summary>
        /// <param name="message">The message to broadcast.</param>
        public static void BroadcastMessage(string message)
        {
            foreach (Player player in GetOnlinePlayers())
            {
                player.SendMessage(message);
            }
            GetInstance().GetLogger().Info(message);
        }

        public static Cubivox GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("The cubivox base game has not been initalized yet!");
            }
            return instance;
        }

        /// <summary>
        /// Get the generator registery.
        /// 
        /// <para>World generation is done on the server.</para>
        /// </summary>
        /// <returns>The world generator.</returns>
        /// <exception cref="InvalidEnvironmentException">Will except if called when not on the server.</exception>
        [ServerOnly]
        public static GeneratorRegistry GetGeneratorRegistry()
        {
            if (GetInstance().generatorRegistry == null)
                throw new InvalidEnvironmentException();

            return GetInstance().generatorRegistry;
        }

        /// <summary>
        /// Get the item registry.
        /// </summary>
        /// <returns>The item registry.</returns>
        public static ItemRegistry GetItemRegistry()
        {
            return GetInstance().itemRegistry;
        }

        /// <summary>
        /// Get the global voxel texture atlas.
        /// 
        /// <para>Texturing is only available on the client.</para>
        /// </summary>
        /// <returns>The global voxel texture atlas.</returns>
        /// <exception cref="InvalidEnvironmentException">Will except if called when not on the client.</exception>
        [ClientOnly]
        public static TextureAtlas GetTextureAtlas()
        {
            if (GetInstance().textureAtlas == null)
                throw new InvalidEnvironmentException();

            return GetInstance().textureAtlas;
        }

        /// <summary>
        /// Get the current environment. (Client or Server)
        /// </summary>
        /// <returns>The current environment</returns>
        public static EnvType GetEnvironment()
        {
            return GetInstance().GetEnvType();
        }

        /// <summary>
        /// Get a voxel definiton for a controller key.
        /// </summary>
        /// <param name="controllerKey">The controller key.</param>
        /// <returns>The voxel definition.</returns>
        public static VoxelDef GetVoxelDefinition(ControllerKey controllerKey)
        {
            return instance.itemRegistry.GetVoxelDefinition(controllerKey);
        }

        /// <summary>
        /// Get the event manager.
        /// </summary>
        /// <returns>The event manager.</returns>
        public static EventManager GetEventManager()
        {
            return GetInstance().eventManager;
        }

        /// <summary>
        /// Get the transport registry.
        /// </summary>
        /// <returns>The transport registry.</returns>
        public static TransportRegistry GetTransportRegistry()
        {
            return GetInstance().transportRegistry;
        }
    }
}
