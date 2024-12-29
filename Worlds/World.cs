using CubivoxCore.Attributes;
using CubivoxCore.Voxels;
using CubivoxCore.Worlds.Generation;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// Represents a playable world (or "space").
    /// </summary>
    public interface World
    {
        /// <summary>
        /// Get the spawn location for the wold.
        /// </summary>
        /// <returns>The spawn location.</returns>
        Location GetSpawnLocation();

        /// <summary>
        /// Check if a chunk is loaded.
        /// </summary>
        /// <param name="location">The location of a chunk.</param>
        /// <returns>If the chunk is loaded.</returns>
        bool IsChunkLoaded(ChunkLocation location);

        /// <summary>
        /// Check if a chunk is loaded.
        /// </summary>
        /// <param name="x">Chunk X Location (In chunk space)</param>
        /// <param name="y">Chunk Y Location (In chunk space)</param>
        /// <param name="z">Chunk Z Location (In chunk space)</param>
        /// <returns>If the chunk is loaded.</returns>
        bool IsChunkLoaded(int x, int y, int z);

        /// <summary>
        /// Check if the provided chunk is loaded.
        /// </summary>
        /// <param name="chunk">The chunck to check.</param>
        /// <returns>If the chunk is loaded.</returns>
        bool IsChunkLoaded(Chunk chunk);

        /// <summary>
        /// Get a chunk.
        /// </summary>
        /// <param name="location">The location of the chunk to get.</param>
        /// <returns>The instance of the desired chunk (or null if not found).</returns>
        Chunk GetChunk(ChunkLocation location);

        /// <summary>
        /// Get a chunk.
        /// </summary>
        /// <param name="x">The x position of the chunk (in chunk space)</param>
        /// <param name="y">The y position of the chunk (in chunk space)</param>
        /// <param name="z">The z position of the chunk (in chunk space)</param>
        /// <returns>The instance of the desired chunk (or null if not found).</returns>
        Chunk GetChunk(int x, int y, int z);

        /// <summary>
        /// Set a voxel in the world.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="z">The z position.</param>
        /// <param name="voxel">The voxel definition to set the voxel to.</param>
        void SetVoxel(int x, int y, int z, VoxelDef voxel);

        /// <summary>
        /// Get a voxel in the world.
        /// 
        /// <para>Note: A Voxel is a mere snapshot of what a voxel was when the function is called. If information about the voxel changes, those changes will not be reflected in the existing Voxel instances.</para>
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="z">The z position.</param>
        /// <returns>A snapshot of the Voxel at the specified location when this method was called.</returns>
        Voxel GetVoxel(int x, int y, int z);

        /// <summary>
        /// Get the generator used by this world.
        /// </summary>
        /// <returns>The generator used by the world.</returns>
        WorldGenerator GetGenerator();

        /// <summary>
        /// Start a bulk edit for the world. This is a far more performant way of performing mass modification to the world.
        /// 
        /// <para>Note: This will overwrite any changes made between this method being called and <see cref="WorldBulkEditor.Submit"/> being called.</para>
        /// <para>Bulk editing is only available on the server.</para>
        /// </summary>
        /// <param name="editCuboid">The cuboid to edit in bulk.</param>
        /// <returns>The bulk editor for the world.</returns>
        [ServerOnly]
        WorldBulkEditor StartBulkEdit(Cuboid editCuboid);
    }
}
