using CubivoxCore.Attributes;
using CubivoxCore.BaseGame.Texturing;
using CubivoxCore.Events;

namespace CubivoxCore.BaseGame
{
    public interface VoxelDef : Item
    {
        /// <summary>
        /// Internal Use Only
        /// </summary>
        VoxelDefBreakEventDelegate _BreakEvent { get; set; }
        /// <summary>
        /// Internal Use Only
        /// </summary>
        VoxelDefPlaceEventDelegate _PlaceEvent {  get; set; }

        AtlasTexture GetAtlasTexture();
        bool IsTransparent();
    }
}
