using CubivoxCore.Worlds;

namespace CubivoxCore.Voxels
{
    /// <summary>
    /// Represents a Voxel from a specific point in time.
    /// 
    /// <para>This is effectly a snapshot from a moment in time, any modifications made to a Voxel will not be represented in existing instances.
    /// For this reason, Voxel instances should be used in the short term and not stored for later use.</para>
    /// </summary>
    public interface Voxel
    {
        /// <summary>
        /// Get the location of the voxel.
        /// </summary>
        /// <returns>The location of the voxel.</returns>
        Location GetLocation();

        /// <summary>
        /// The voxel definition for the voxel.
        /// </summary>
        /// <returns>The voxel definition for the voxel.</returns>
        VoxelDef GetVoxelDef();

        /// <summary>
        /// Get the chunk that the Voxel belongs to.
        /// </summary>
        /// <returns>The chunk that the Voxel belongs to.</returns>
        Chunk GetChunk();
    }
}
