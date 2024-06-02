using CubivoxCore.Voxels;

namespace CubivoxCore.Worlds.Generation
{
    /// <summary>
    /// Stores the data of a chunk while it is being generated.
    /// </summary>
    public interface ChunkData
    {
        /// <summary>
        /// Set the voxel at the specified position.
        /// <para>The coordinates here are in chunk space.</para>
        /// </summary>
        /// <param name="x">X position in chunk space</param>
        /// <param name="y">Y position in chunk space</param>
        /// <param name="z">Z position in chunk space</param>
        /// <param name="voxelDef">The voxel definition to place here.</param>
        void SetVoxel(int x, int y, int z, VoxelDef voxelDef);
    }
}
