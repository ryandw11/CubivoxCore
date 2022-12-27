using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CubivoxCore.Commands;
using CubivoxCore.Permissions;
using CubivoxCore.Worlds;

namespace CubivoxCore.Players
{
    public interface Player : GameEntity, CommandSender, Permissible
    {
        Guid GetUUID();
        string GetName();
    }
}
