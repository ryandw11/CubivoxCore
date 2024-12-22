using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    [Name("Grass")]
    [Key("GRASS")]
    [Texture(TextureRoot.CUBIVOX, "Textures/grass_voxel")]
    public sealed class GrassVoxel : ModVoxel
    {
        public GrassVoxel(Mod mod) : base(mod)
        {
        }
    }
}
