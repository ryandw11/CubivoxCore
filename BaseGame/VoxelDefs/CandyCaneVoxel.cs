using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    [Name("Candy Cane")]
    [Key("CANDY_CANE")]
    [Texture(TextureRoot.CUBIVOX, "Textures/candy_cane_voxel")]
    public sealed class CandyCaneVoxel : ModVoxel
    {
        public CandyCaneVoxel(Mod mod) : base(mod)
        {
        }
    }
}
