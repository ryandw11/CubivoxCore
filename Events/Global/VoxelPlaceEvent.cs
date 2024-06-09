using CubivoxCore.Players;
using CubivoxCore.Voxels;

namespace CubivoxCore.Events.Global
{
    /// <summary>
    /// The global event for when any voxel is placed by a Player.
    /// 
    /// <para>This event is only triggered when a Player places a voxel.</para>
    /// </summary>
    public class VoxelPlaceEvent : CancellableEvent
    {
        /// <summary>
        /// The player that placed the voxel.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// The voxel that was placed.
        /// </summary>
        public Voxel Voxel { get; private set; }

        public VoxelPlaceEvent(Player player, Voxel voxel)
        {
            Player = player;
            Voxel = voxel;
        }
    }
}
