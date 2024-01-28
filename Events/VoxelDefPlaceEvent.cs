using CubivoxCore.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Events
{
    public delegate void VoxelDefPlaceEventDelegate(VoxelDefPlaceEvent evt);
    public class VoxelDefPlaceEvent
    {
        public Player Player { get; private set; }
        public Location Location { get; private set; }
        public bool IsCancelled { get; private set; }

        public VoxelDefPlaceEvent(Player player, Location location)
        {
            Player = player;
            Location = location;
        }

        public void Cancel()
        {
            IsCancelled = true;
        }
    }
}
