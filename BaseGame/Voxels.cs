using CubivoxCore.Items;
using CubivoxCore.Utils;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame
{
    /// <summary>
    /// A repository of voxels that are built into Cubivox.
    /// </summary>
    public sealed class Voxels
    {
        private Voxels() { }

        public static readonly ControllerKey AIR = ControllerKeyUtils.CubivoxControllerKey("AIR");
        public static readonly ControllerKey TEST = ControllerKeyUtils.CubivoxControllerKey("TEST");
        public static readonly ControllerKey GRASS = ControllerKeyUtils.CubivoxControllerKey("GRASS");
        public static readonly ControllerKey DIRT = ControllerKeyUtils.CubivoxControllerKey("DIRT");
        public static readonly ControllerKey CANDY_CANE = ControllerKeyUtils.CubivoxControllerKey("CANDY_CANE");

        /// <summary>
        /// Get a voxel definition from its controller key.
        /// 
        /// <para>This is equivalent to <see cref="ItemRegistry.GetVoxelDefinition(ControllerKey)"/>.</para>
        /// </summary>
        /// <param name="key">The controller key of the voxel to get.</param>
        /// <returns>The voxel definition.</returns>
        public static VoxelDef Voxel(ControllerKey key)
        {
            return Cubivox.GetItemRegistry().GetVoxelDefinition(key);
        }
    }
}
