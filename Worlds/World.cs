using CubivoxCore.BaseGame;

namespace CubivoxCore.Worlds
{
    public interface World
    {
        Location GetSpawnLocation();
        bool IsChunkLoaded(Location location);
        bool IsChunkLoaded(int x, int y, int z);
        bool IsChunkLoaded(Chunk chunk);
        void LoadChunk(Location location);
        void LoadChunk(int x, int y, int z);
        void LoadChunk(Chunk chunk);
        Chunk GetChunk(Location location);
        Chunk GetChunk(int x, int y, int z);
        void Save();
        void UnloadChunk(int x, int y, int z);
        void UnloadChunk(Chunk chunk);
        void SetVoxel(int x, int y, int z, VoxelDef voxel);
        Voxel GetVoxel(int x, int y, int z);
    }
}
