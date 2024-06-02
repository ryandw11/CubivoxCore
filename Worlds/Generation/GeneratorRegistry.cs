using CubivoxCore.Attributes;
using CubivoxCore.Mods;

namespace CubivoxCore.Worlds.Generation
{
    /// <summary>
    /// The GeneratorRegistry handles the registration of custom world generators.
    /// 
    /// <para>World generation is only available on the server.</para>
    /// </summary>
    [ServerOnly]
    public interface GeneratorRegistry
    {
        /// <summary>
        /// Register a new world generator.
        /// </summary>
        /// <param name="mod">The mod the generator is for.</param>
        /// <param name="worldGenerator">The world generator.</param>
        void RegisterWorldGenerator(Mod mod, WorldGenerator worldGenerator);

        /// <summary>
        /// Get the default world generator.
        /// </summary>
        /// <returns>The default world generator.</returns>
        WorldGenerator GetDefaultWorldGenerator();

        /// <summary>
        /// Get the world generator for a controller key.
        /// </summary>
        /// <param name="controllerKey">The controller key.</param>
        /// <returns>The world generator.</returns>
        WorldGenerator GetWorldGenerator(ControllerKey controllerKey);
    }
}
