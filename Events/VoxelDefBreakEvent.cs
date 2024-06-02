using CubivoxCore.Players;
using CubivoxCore.Voxels;

namespace CubivoxCore.Events
{
    public delegate void VoxelDefBreakEventDelegate(VoxelDefBreakEvent evt);

    /// <summary>
    /// A local event that triggers whenever a specific voxel is broken by a Player. This event is
    /// used by a specific <see cref="VoxelDef"/> to know when a voxel of its type was broken.
    /// 
    /// <para>Only voxels that are broken by players will trigger this event.</para>
    /// </summary>
    public class VoxelDefBreakEvent
    {
        /// <summary>
        /// The player that breaks the voxel.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// The location of the destoryed Voxel.
        /// </summary>
        public Location Location { get; private set; }

        /// <summary>
        /// If the event is canceled.
        /// </summary>
        public bool IsCancelled { get; private set; }

        public VoxelDefBreakEvent(Player player, Location location)
        {
            Player = player;
            Location = location;
        }

        /// <summary>
        /// Cancel the event.
        /// </summary>
        public void Cancel()
        {
            IsCancelled = true;
        }
    }
}
