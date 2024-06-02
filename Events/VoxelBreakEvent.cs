using CubivoxCore.Players;
using CubivoxCore.Voxels;

namespace CubivoxCore.Events
{

    /// <summary>
    /// The global event for when any voxel is destroyed by a Player.
    /// 
    /// <para>This event is only triggered when a Player breaks a voxel.</para>
    /// </summary>
    public class VoxelBreakEvent : CancellableEvent
    {
        /// <summary>
        /// The player that broke the voxel.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// The voxel that was broken.
        /// </summary>
        public Voxel Voxel { get; private set; }

        public VoxelBreakEvent(Player player, Voxel voxel)
        {
            Player = player;
            Voxel = voxel;
        }
    }
}
