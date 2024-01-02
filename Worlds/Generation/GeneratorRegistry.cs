using CubivoxCore.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Worlds.Generation
{
    public interface GeneratorRegistry
    {
        void RegisterWorldGenerator(Mod mod, WorldGenerator worldGenerator);
        WorldGenerator GetDefaultWorldGenerator();
        WorldGenerator GetWorldGenerator(ControllerKey controllerKey);
    }
}
