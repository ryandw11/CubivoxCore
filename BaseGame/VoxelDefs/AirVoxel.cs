using CubivoxCore.Mods;
using CubivoxCore.Utils;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    public class AirVoxel : VoxelDef
    {
        public static readonly string KEY = "AIR";

        public ControllerKey GetControllerKey()
        {
            return ControllerKeyUtils.CubivoxControllerKey(KEY);
        }

        public Mod GetMod()
        {
            return Cubivox.GetInstance();
        }

        public string GetModel()
        {
            return null;
        }

        public string GetName()
        {
            return "air";
        }

        public string GetTexture()
        {
            return null;
        }
    }
}
