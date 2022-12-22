using CubivoxCore.Worlds;

namespace CubivoxCore.BaseGame
{
    public interface Chunk
    {
        Voxel GetVoxel(int x, int y, int z);
        World GetWorld();
        Location GetLocation();
        bool IsLoaded();
        bool Load();
    }
}
