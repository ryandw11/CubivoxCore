using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    [Name("Dirt")]
    [Key("DIRT")]
    [Texture(TextureRoot.CUBIVOX, "Textures/dirt_voxel")]
    public sealed class DirtVoxel : ModVoxel
    {
        public DirtVoxel(Mod mod) : base(mod)
        {
        }
    }
}
