using CubivoxCore.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.BaseGame
{
    public interface Voxel
    {
        Location GetLocation();
        ModVoxel GetModVoxel();
        void SetModVoxel(ModVoxel modVoxel);
        Chunk GetChunk();
    }
}
