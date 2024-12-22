using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    [Name("Dirt")]
    [Key("DIRT")]
    [Texture(TextureRoot.CUBIVOX, "dirt_voxel.png")]
    public sealed class DirtVoxel : ModVoxel
    {
        public DirtVoxel(Mod mod) : base(mod)
        {
        }
    }
}
