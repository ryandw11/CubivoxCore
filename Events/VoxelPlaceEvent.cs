using CubivoxCore.BaseGame;
using CubivoxCore.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Events
{
    public class VoxelPlaceEvent : CancellableEvent
    {
        public Player Player { get; private set; }
        public Voxel Voxel { get; private set; }

        public VoxelPlaceEvent(Player player, Voxel voxel)
        {
            Player = player;
            Voxel = voxel;
        }
    }
}
