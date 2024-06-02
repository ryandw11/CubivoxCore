using CubivoxCore.Voxels;
using CubivoxCore.Worlds.Generation;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// Represents a playable world (or "space") on a Server.
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
        bool IsChunkLoaded(Location location);

        /// <summary>
        /// Check if a chunk is loaded.
        /// </summary>
        /// <param name="x">Chunk X Location</param>
        /// <param name="y">Chunk Y Location</param>
        /// <param name="z">Chunk Z Location</param>
        /// <returns>If the chunk is loaded.</returns>
        bool IsChunkLoaded(int x, int y, int z);

        /// <summary>
        /// Check if the provided chunk is loaded.
        /// </summary>
        /// <param name="chunk">The chunck to check.</param>
        /// <returns>If the chunk is loaded.</returns>
        bool IsChunkLoaded(Chunk chunk);

        /// <summary>
        /// Request that a chunk is loaded.
        /// <para>Server Side Only</para>
        /// </summary>
        /// <param name="location">The location of the chunk.</param>
        void LoadChunk(Location location);

        /// <summary>
        /// Request that a chunk is loaded.
        /// <para>Server Side Only</para>
        /// </summary>
        /// <param name="x">Chunk X Location</param>
        /// <param name="y">Chunk Y Location</param>
        /// <param name="z">Chunk Z Location</param>
        void LoadChunk(int x, int y, int z);

        /// <summary>
        /// Request that a chunk is loaded.
        /// <para>Server Side Only</para>
        /// </summary>
        /// <param name="chunk"></param>
        void LoadChunk(Chunk chunk);

        /// <summary>
        /// Get a chunk.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        Chunk GetChunk(Location location);
        Chunk GetChunk(int x, int y, int z);
        void Save();
        void UnloadChunk(int x, int y, int z);
        void UnloadChunk(Chunk chunk);
        void SetVoxel(int x, int y, int z, VoxelDef voxel);
        Voxel GetVoxel(int x, int y, int z);
        WorldGenerator GetGenerator();
    }
}
