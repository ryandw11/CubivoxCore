using CubivoxCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Worlds.Generation
{
    public abstract class WorldGenerator
    {
        public readonly string Key;
        public readonly string Name;

        public WorldGenerator()
        {
            Name name = (Name)GetType().GetCustomAttributes(typeof(Name), true)[0];
            this.Name = name.GetValue();

            Key key = (Key)GetType().GetCustomAttributes(typeof(Key), true)[0];
            this.Key = key.GetValue();
        }

        public abstract void GenerateChunk(int chunkX, int chunkY, int chunkZ, ChunkData chunkData);
    }
}
