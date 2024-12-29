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

        /// <summary>
        /// The world the chunk is in. (May be null).
        /// </summary>
        public World? World { get; private set; }

        /// <summary>
        /// The X coordinate in chunk space.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// The Y coordinate in chunk space.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// The Z coordinate in chunk space.
        /// </summary>
        public int Z { get; private set; }

        /// <summary>
        /// Create a new chunk location using chunk coordinate space.
        /// </summary>
        /// <param name="world">The world the chunk is in.</param>
        /// <param name="x">The x coordinate in chunk space.</param>
        /// <param name="y">The y coordiante in chunk space.</param>
        /// <param name="z">The z coordinate in chunk space.</param>
        public ChunkLocation(World? world, int x, int y, int z)
        {
            World = world;
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Create a chunk location from a voxel space location.
        /// </summary>
        /// <param name="location">The voxel space location to convert.</param>
        public ChunkLocation(Location location)
        {
            World = location.world;
            X = (int)Math.Floor(location.x / CHUNK_SIZE);
            Y = (int)Math.Floor(location.y / CHUNK_SIZE);
            Z = (int) Math.Floor( location.z / CHUNK_SIZE );
        }

        /// <summary>
        /// Convert to the voxel coordinate system.
        /// </summary>
        /// <returns>The location in voxel coordinates.</returns>
        public Location ToLocation()
        {
            return new Location(X * CHUNK_SIZE, Y * CHUNK_SIZE, Z * CHUNK_SIZE);
        }

        /// <summary>
        /// A Cuboid to represent section of the world in voxel space a chunk location takes up.
        /// </summary>
        /// <returns>The cuboid to represent the chunk.</returns>
        public Cuboid AsCuboid()
        {
            var location1 = ToLocation();
            var location2 = new Location(World, location1.x + CHUNK_SIZE - 1, location1.y + CHUNK_SIZE - 1, location1.z + CHUNK_SIZE - 1);

            return new Cuboid(location1, location2);
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
