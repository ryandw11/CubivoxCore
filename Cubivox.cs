using CubivoxCore.BaseGame;
using CubivoxCore.BaseGame.Texturing;
using CubivoxCore.Exceptions;
using CubivoxCore.Mods;
using CubivoxCore.Worlds.Generation;
using System;

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

        public abstract void OnEnable();
        public abstract EnvType GetEnvType();

        /// <summary>
        /// Assert that the code is executing on the server.
        /// </summary>
        public abstract void AssertServer();
        /// <summary>
        /// Assert that the code is executing on the client.
        /// </summary>
        public abstract void AssertClient();

        public static Cubivox GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("The cubivox base game has not been initalized yet!");
            }
            return instance;
        }

        public static GeneratorRegistry GetGeneratorRegistry()
        {
            if (GetInstance().generatorRegistry == null)
                throw new InvalidEnvironmentException();

            return GetInstance().generatorRegistry;
        }

        public static ItemRegistry GetItemRegistry()
        {
            return GetInstance().itemRegistry;
        }

        public static TextureAtlas GetTextureAtlas()
        {
            if (GetInstance().textureAtlas == null)
                throw new InvalidEnvironmentException();

            return GetInstance().textureAtlas;
        }

        public static EnvType GetEnvironment()
        {
            return GetInstance().GetEnvType();
        }

        public static VoxelDef GetVoxelDefinition(ControllerKey controllerKey)
        {
            return instance.itemRegistry.GetVoxelDefinition(controllerKey);
        }
    }
}
