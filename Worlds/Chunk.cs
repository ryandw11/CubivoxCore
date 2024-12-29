using CubivoxCore.Attributes;
using CubivoxCore.Voxels;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// Represents a small chunk voxels within the greater world.
    /// 
    /// <para>A chunk is a section of 16 x 16 x 16 voxels, containing a total of 4,096 voxels.</para>
    /// </summary>
    public interface Chunk
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
        /// Get a voxel within a chunk.
        /// 
        /// <para>Note: A Voxel is a mere snapshot of what a voxel was when the function is called. If information about the voxel changes, those changes will not be reflected in the existing Voxel instances.</para>
        /// </summary>
        /// <param name="x">The global or local x position.</param>
        /// <param name="y">The global or local y position.</param>
        /// <param name="z">The global or local z position.</param>
        /// <returns>A snapshot of the Voxel at the specified location when this method was called.</returns>
        Voxel GetVoxel(int x, int y, int z);

        /// <summary>
        /// Get the world the chunk is in.
        /// </summary>
        /// <returns>The world the chunk is in.</returns>
        World GetWorld();

        /// <summary>
        /// Get the local of the chunk.
        /// </summary>
        /// <returns>The location of the chunk.</returns>
        ChunkLocation GetLocation();

        /// <summary>
        /// Completely regenerates a chunk based upon the world's generator.
        /// 
        /// <para>This method does nothing on the client.</para>
        /// </summary>
        [ServerOnly]
        void Regenerate();

        /// <summary>
        /// Start a bulk edit.
        /// 
        /// <para>Note: Other mods can still perform bulk edits in the same area at the same time.</para>
        /// <para>Bulk editing is only available on the server.</para>
        /// </summary>
        /// <returns>The bulk editor.</returns>
        [ServerOnly]
        ChunkBulkEditor StartBulkEdit();

        /// <summary>
        /// Submit a bulk editor.
        /// <para>This will send out packets for clients to update their chunks.</para>
        /// <para>Bulk editing is only available on the server.</para>
        /// </summary>
        /// <param name="chunkBulkEditor">The bulk edit to submit.</param>
        [ServerOnly]
        void SubmitBulkEdit(ChunkBulkEditor chunkBulkEditor);
    }
}
