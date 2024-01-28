using CubivoxCore.BaseGame.Texturing;
using CubivoxCore.Events;
using CubivoxCore.Mods;
using CubivoxCore.Utils;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    public class AirVoxel : VoxelDef
    {
        public static readonly string KEY = "AIR";

        /// <summary>
        /// Not implemented.
        /// </summary>
        public VoxelDefPlaceEventDelegate _PlaceEvent { get; set; }
        /// <summary>
        /// Not implemented.
        /// </summary>
        public VoxelDefBreakEventDelegate _BreakEvent { get; set; }

        public AtlasTexture GetAtlasTexture()
        {
            return null;
        }

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

        public bool IsTransparent()
        {
            return true;
        }
    }
}
