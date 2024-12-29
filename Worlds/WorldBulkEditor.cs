using CubivoxCore.Attributes;
using CubivoxCore.Voxels;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// Edit a world in bulk.
    /// 
    /// <para>Setting single voxels in the world sends a packet to clients immediately, the WorldBulkEditor submits each chunk that is changed
    /// within individual packets, which is far more optimal. Use this class for any large scale changes.</para>
    /// 
    /// <para>The bulk editor makes a copy of the world data within the cuboid region.</para>
    /// </summary>
    [ServerOnly]
    public interface WorldBulkEditor
    {
        /// <summary>
        /// The Cuboid that the bulk editor covers.
        /// </summary>
        Cuboid EditCuboid { get; }

        /// <summary>
        /// Set a voxel within the world to a specific voxel type.
        /// </summary>
        /// <param name="x">The global x position.</param>
        /// <param name="y">The global y position.</param>
        /// <param name="z">The global z position</param>
        /// <param name="voxelDef">The voxel defition for the voxel should be set too.</param>
        /// <exception cref="ArgumentException">If the voxel specified is not within the Cuboid region.</exception>
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
        /// Fill the space with a single voxel.
        /// </summary>
        /// <param name="voxelDef">The voxel definition to fill with.</param>
        void Fill(VoxelDef voxelDef);

        /// <summary>
        /// Submit a world bulk edit.
        /// 
        /// <para>Once submitted, this bulk editor cannot be used anymore.</para>
        /// </summary>
        void Submit();
    }
}
