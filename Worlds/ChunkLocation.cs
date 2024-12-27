using CubivoxCore.Utils;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// Stores the location for a chunk.
    /// 
    /// <para>Chunks operate in a different coordinate system than voxels.</para>
    /// </summary>
    public sealed class ChunkLocation
    {
        public static readonly int CHUNK_SIZE = 16;

        public World? World { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public ChunkLocation(World? world, int x, int y, int z)
        {
            World = world;
            X = x;
            Y = y;
            Z = z;
        }

        public ChunkLocation(Location location)
        {
            World = location.world;
            X = location.GetVoxelX() / CHUNK_SIZE;
            Y = location.GetVoxelY() / CHUNK_SIZE;
            Z = location.GetVoxelZ() / CHUNK_SIZE;
        }

        /// <summary>
        /// Convert to the voxel coordinate system.
        /// </summary>
        /// <returns>The location in voxel coordinates.</returns>
        public Location ToLocation()
        {
            return new Location(X * CHUNK_SIZE, Y * CHUNK_SIZE, Z * CHUNK_SIZE);
        }

        public static ChunkLocation operator +(ChunkLocation loc1, ChunkLocation loc2)
        {
            return new ChunkLocation(loc1.World, loc1.X + loc2.X, loc1.Y + loc2.Y, loc1.Z + loc2.Z);
        }

        public static ChunkLocation operator -(ChunkLocation loc)
        {
            return new ChunkLocation(loc.World, -loc.X, -loc.Y, -loc.Z);
        }

        public static ChunkLocation operator -(ChunkLocation loc1, ChunkLocation loc2)
        {
            return new ChunkLocation(loc1.World, loc1.X - loc2.X, loc1.Y - loc2.Y, loc1.Z - loc2.Z);
        }

        public static bool operator ==(ChunkLocation loc1, ChunkLocation loc2)
        {
            if (loc1 is null && loc2 is null)
            {
                return true;
            }
            if (loc1 is null || loc2 is null)
            {
                return false;
            }
            return loc1.World == loc2.World && loc1.X == loc2.X && loc1.Y == loc2.Y && loc1.Z == loc2.Z;
        }

        public static bool operator !=(ChunkLocation loc1, ChunkLocation loc2)
        {
            return !(loc1 == loc2);
        }

        public static bool operator ==(ChunkLocation loc1, Location loc2)
        {
            if (loc1 is null && loc2 is null)
            {
                return true;
            }
            if (loc1 is null || loc2 is null)
            {
                return false;
            }
            var chunkLoc2 = new ChunkLocation(loc2);
            return loc1 == chunkLoc2;
        }

        public static bool operator !=(ChunkLocation loc1, Location loc2)
        {
            return !(loc1 == loc2);
        }

        public override string ToString() => $"{{ChunkLocation: ({X}, {Y}, {Z}); }}";

        public override int GetHashCode()
        {
            return new { World, X, Y, Z }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is ChunkLocation)
            {
                ChunkLocation location = (ChunkLocation)obj;
                return World == location.World && X == location.X && Y == location.Y && Z == location.Z;
            }

            return false;
        }
    }
}
