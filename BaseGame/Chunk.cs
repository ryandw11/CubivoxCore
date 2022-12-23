using CubivoxCore.Worlds;

namespace CubivoxCore.BaseGame
{
    public interface Chunk
    {
        void SetVoxel(int x, int y, int z, VoxelDef voxelDef);
        Voxel GetVoxel(int x, int y, int z);
        World GetWorld();
        Location GetLocation();
        bool IsLoaded();
        bool Load();
    }
}
