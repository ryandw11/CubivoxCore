using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    [Name("Candy Cane")]
    [Key("CANDY_CANE")]
    [Texture(TextureRoot.CUBIVOX, "candy_cane_voxel.png")]
    public sealed class CandyCaneVoxel : ModVoxel
    {
        public CandyCaneVoxel(Mod mod) : base(mod)
        {
        }
    }
}
