using CubivoxCore.Attributes;
using CubivoxCore.Events.Local;
using CubivoxCore.Items;
using CubivoxCore.Texturing;

namespace CubivoxCore.Voxels
{
    /// <summary>
    /// A Voxel Definition is responsible for defining the properties of voxels and how they should act within the world.
    /// 
    /// <para>Voxel Definitions are defined by the Cubivox base game or mods to create new Voxels which can be placed within the world.</para>
    /// </summary>
    public interface VoxelDef : Item
    {
        /// <summary>
        /// Get the atlas texture that Voxels should use.
        /// 
        /// <para>This a client only method and should only be called on the client.</para>
        /// </summary>
        /// <returns>
        ///     <para>Client: The AtlasTexture the voxel should use.</para>
        ///     <para>Server: null</para>
        /// </returns>
        [ClientOnly]
        AtlasTexture GetAtlasTexture();

        /// <summary>
        /// If the voxel has transparency within its texture.
        /// </summary>
        /// <returns>If the voxel has transparency within its texture.</returns>
        bool IsTransparent();

        /// <summary>
        /// The internal break event for a voxel, do not use this, instead use <see cref="ModVoxel.BreakEvent"/> instead.
        /// 
        /// <para>Internal Use Only</para>
        /// </summary>
        VoxelDefBreakEventDelegate _BreakEvent { get; set; }

        /// <summary>
        /// The internal place event for a voxel, do not use this, instead use <see cref="ModVoxel.PlaceEvent"/> instead.
        /// 
        /// <para>Internal Use Only</para>
        /// </summary>
        VoxelDefPlaceEventDelegate _PlaceEvent { get; set; }
    }
}
