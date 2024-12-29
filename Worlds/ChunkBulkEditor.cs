using CubivoxCore.Attributes;
using CubivoxCore.Voxels;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// Edit a chunk in bulk.
    /// 
    /// <para>Setting single voxels on a chunk sends a packet to clients immediately, the ChunkBulkEditor submits chunk changes
    /// within a single packet, which is far more optimal. Use this class for any large scale changes.</para>
    /// </summary>
    [ServerOnly]
    public interface ChunkBulkEditor
    {
        /// <summary>
        /// Set a voxel within a chunk to a specific voxel type.
        /// 
        /// <para>The way this method handles locationi s that it modulates the x, y, and z coordinates to get its position within the chunk.
        /// No validation is performed to ensure that the provided values are actually within the chunk bounds. This means either
        /// local or global coordinates can be passed into the function and still work.</para>
        /// </summary>
        /// <param name="x">The global or local x position.</param>
        /// <param name="y">The global or local y position.</param>
        /// <param name="z">The global or local z position</param>
        /// <param name="voxelDef">The voxel defition for the voxel should be set too.</param>
        void SetVoxel(int x, int y, int z, VoxelDef voxelDef);

        /// <summary>
        /// Fill a cuboid with voxels.
        /// </summary>
        /// <param name="x1">The x position for the first corner.</param>
        /// <param name="y1">The y position for the first corner.</param>
        /// <param name="z1">The z position for the first corner.</param>
        /// <param name="x2">The x position for the second corner.</param>
        /// <param name="y2">The y position for the second corner.</param>
        /// <param name="z2">The z position for the second corner.</param>
        /// <param name="voxelDef">The voxel definition to fill with.</param>
        void FillCube(int x1, int y1, int z1, int x2, int y2, int z2, VoxelDef voxelDef);

        /// <summary>
        /// Fill a cuboid with voxels.
        /// </summary>
        /// <param name="cuboid">The cuboid to fill.</param>
        /// <param name="voxelDef">The voxel definition to fill with.</param>
        void FillCube(Cuboid cuboid, VoxelDef voxelDef);

        /// <summary>
        /// Fill a chunk with a voxel.
        /// </summary>
        /// <param name="voxelDef">The voxel definition to fill with.</param>
        void Fill(VoxelDef voxelDef);
    }
}
