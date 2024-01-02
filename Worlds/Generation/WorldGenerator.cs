using CubivoxCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Worlds.Generation
{
    public abstract class WorldGenerator
    {
        protected readonly string key;
        protected readonly string name;

        public WorldGenerator()
        {
            Name name = (Name)GetType().GetCustomAttributes(typeof(Name), true)[0];
            this.name = name.GetValue();

            Key key = (Key)GetType().GetCustomAttributes(typeof(Key), true)[0];
            this.key = key.GetValue();
        }

        public abstract void GenerateChunk(int chunkX, int chunkY, int chunkZ, ChunkData chunkData);
    }
}
