using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    [Name("Test Voxel")]
    [Key("TEST")]
    [Texture(TextureRoot.CUBIVOX, "Textures/test_voxel")]
    public sealed class TestVoxel : ModVoxel
    {
        public TestVoxel(Mod mod) : base(mod)
        {
        }
    }
}
