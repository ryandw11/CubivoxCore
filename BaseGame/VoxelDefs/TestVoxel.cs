using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    [Name("Test Voxel")]
    [Key("TEST")]
    [Texture(TextureRoot.CUBIVOX, "test_voxel.png")]
    public sealed class TestVoxel : ModVoxel
    {
        public TestVoxel(Mod mod) : base(mod)
        {
        }
    }
}
