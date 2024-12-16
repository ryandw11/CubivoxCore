using System;
using CubivoxCore.Serialization;
using CubivoxCore.Worlds;

namespace CubivoxCore
{
    /// <summary>
    /// Represents a position within 3D space.
    /// </summary>
    public class Location : Serializable
    {
        public World world { private set; get; }
        public double x { private set; get; }
        public double y { private set; get; }
        public double z { private set; get; }
        public float pitch { private set; get; }
        public float yaw { private set; get; }

        public Location(World world, double x, double y, double z, float pitch, float yaw)
        {
            this.world = world;
            this.x = x;
            this.y = y;
            this.z = z;
            this.pitch = pitch;
            this.yaw = yaw;
        }

        public Location(World world, double x, double y, double z) : this(world, x, y, z, 0, 0)
        {}

        public Location(double x, double y, double z) : this(null, x, y, z, 0, 0) 
        {}

        public Location(byte[] data) : this(null, 0, 0, 0, 0, 0)
        {
            Deserialize(data);
        }

        public Optional<World> GetWorld()
        {
            return Optional<World>.OfNullable(world);
        }

        public Location Add (double x, double y, double z)
        {
            return new Location(world, this.x + x, this.y + y, this.z + z, pitch, yaw);
        }

        public Location Subtract(double x, double y, double z)
        {
            return new Location(world, this.x - x, this.y - y, this.z - z, pitch, yaw);
        }

        public Location Set(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            return this;
        }

        public Location Set(float pitch, float yaw)
        {
            this.pitch = pitch;
            this.yaw = yaw;
            return this;
        }

        public int GetVoxelX()
        {
            return (int) Math.Floor(x);
        }

        public int GetVoxelY()
        {
            return (int) Math.Floor(y);
        }

        public int GetVoxelZ()
        {
            return (int) Math.Floor(z);
        }

        public static Location operator + (Location loc1, Location loc2)
        {
            return new Location(loc1.world, loc1.x + loc2.x, loc1.y + loc2.y, loc1.z + loc2.z, loc1.pitch, loc1.yaw + loc2.yaw);
        }

        public static Location operator - (Location loc)
        {
            return new Location(loc.world, -loc.x, -loc.y, -loc.z, loc.pitch, loc.yaw);
        }

        public static Location operator - (Location loc1, Location loc2)
        {
            return new Location(loc1.world, loc1.x - loc2.x, loc1.y - loc2.y, loc1.z - loc2.z, loc1.pitch, loc1.yaw - loc2.yaw);
        }

        public static Location operator * (Location loc, double a)
        {
            return new Location(loc.world, a * loc.x, a * loc.y, a * loc.z, loc.pitch, loc.yaw);
        }

        public static Location operator / (Location loc, double a)
        {
            return new Location(loc.world, loc.x / a, loc.y / a, loc.z / a, loc.pitch, loc.yaw);
        }

        public static bool operator ==(Location loc1, Location loc2)
        {
            if( loc1 is null && loc2 is null)
            {
                return true;
            }
            if( loc1 is null || loc2 is null)
            {
                return false;
            }
            return loc1.world == loc2.world && ApproxEqual(loc1.x, loc2.x) && ApproxEqual(loc1.y, loc2.y) && ApproxEqual(loc1.z, loc2.z);
        }

        public static bool operator !=(Location loc1, Location loc2)
        {
            return !(loc1 == loc2);
        }

        public override string ToString() => $"{{Location: ({x}, {y}, {z}); ({pitch}, {yaw}) }}";

        public override int GetHashCode()
        {
            return new { world, x, y, z, pitch, yaw }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Location)
            {
                Location location = (Location)obj;
                return world == location.world && x == location.x && y == location.y && z == location.z && pitch == location.pitch && yaw == location.yaw;
            }

            return false;
        }

        public Location Clone()
        {
            return new Location(world, x, y, z, pitch, yaw);
        }

        private static bool ApproxEqual(double x1, double x2)
        {
            return Math.Abs(x1 - x2) < 0.03;
        }

        public byte[] Serialize()
        {
            using( MemoryStream stream = new MemoryStream() )
            {
                // 32 bytes
                // TODO: Serialize the world
                //stream.Write(world.GetUUid());
                stream.Write(BitConverter.GetBytes(x));
                stream.Write(BitConverter.GetBytes(y));
                stream.Write(BitConverter.GetBytes(z));
                stream.Write(BitConverter.GetBytes(pitch));
                stream.Write(BitConverter.GetBytes(yaw));

                return stream.ToArray();
            }
        }

        public void Deserialize(byte[] data)
        {
            if( data.Length != 32 )
            {
                throw new ArgumentOutOfRangeException("Location data should be 32 bytes in length.");
            }
            using( MemoryStream stream = new MemoryStream(data) )
            {
                byte[] buffer = new byte[8];

                stream.Read(buffer, 0, 8);
                x = BitConverter.ToDouble(buffer);

                stream.Read(buffer, 0, 8);
                y = BitConverter.ToDouble(buffer);

                stream.Read(buffer, 0, 8);
                z = BitConverter.ToDouble(buffer);

                stream.Read(buffer, 0, 4);
                pitch = BitConverter.ToSingle(buffer);

                stream.Read(buffer, 0, 4);
                yaw = BitConverter.ToSingle(buffer);
            }
        }
    }
}