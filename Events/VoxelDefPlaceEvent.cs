using CubivoxCore.Players;
using CubivoxCore.Voxels;

namespace CubivoxCore.Events
{
    public delegate void VoxelDefPlaceEventDelegate(VoxelDefPlaceEvent evt);

    /// <summary>
    /// A local event that triggers whenever a specific voxel is placed by a Player. This event is
    /// used by a specific <see cref="VoxelDef"/> to know when a voxel of its type was placed.
    /// 
    /// <para>Only voxels that are placed by players will trigger this event.</para>
    /// </summary>
    public class VoxelDefPlaceEvent
    {
        /// <summary>
        /// The player the placed the voxel.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// The location of the placed voxel.
        /// </summary>
        public Location Location { get; private set; }

        /// <summary>
        /// If the event was cancelled.
        /// </summary>
        public bool IsCancelled { get; private set; }

        public VoxelDefPlaceEvent(Player player, Location location)
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
