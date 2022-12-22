using CubivoxCore.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.BaseGame
{
    public class Voxel
    {
        private Location location;
        private ModVoxel modVoxel;

        public Voxel(Location location, ModVoxel modVoxel)
        {
            if (location == null)
                throw new ArgumentNullException("location", "The location of a Voxel cannot be null!");
            if (modVoxel == null)
                throw new ArgumentNullException("modVoxel", "The modVoxel cannot be null!");

            this.location = location;
            this.modVoxel = modVoxel;
        }
    }
}
