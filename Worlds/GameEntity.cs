using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CubivoxCore;
using CubivoxCore.BaseGame;

namespace CubivoxCore.Worlds
{
    public interface GameEntity
    {
        Location GetLocation();
        bool IsLiving();
        Entity GetEntityType();
    }
}
