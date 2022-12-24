using CubivoxCore.BaseGame.Texturing;

namespace CubivoxCore.BaseGame
{
    public interface VoxelDef : Item
    {
        AtlasTexture GetAtlasTexture();
        bool IsTransparent();
    }
}
