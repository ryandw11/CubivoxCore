using CubivoxCore.Attributes;
using CubivoxCore.BaseGame;
using CubivoxCore.BaseGame.Texturing;

namespace CubivoxCore.Mods
{
    public class ModVoxel : ModItem, VoxelDef
    {
        protected AtlasTexture atlasTexture;
        protected bool transparent;

        public ModVoxel(Mod mod) : base(mod)
        { 
            if(GetModel() == null && Cubivox.GetEnvironment() != EnvType.SERVER)
            {
                // Atlas textures do not exist on the server.
                atlasTexture = Cubivox.GetTextureAtlas().CreateAtlasTexture(GetTexture());
            }

           transparent = GetType().GetCustomAttributes(typeof(Transparent), true).Length > 0;
        }

        public AtlasTexture GetAtlasTexture()
        {
            return atlasTexture;
        }

        public bool IsTransparent()
        {
            return transparent;
        }
    }
}
