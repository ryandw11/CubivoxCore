using System;
using System.Collections.Generic;
using System.Text;

namespace CubivoxCore
{
    /// <summary>
    /// Represents a cube area within voxel space.
    /// </summary>
    public sealed class Cuboid
    {
        public Location MinCorner { get; private set; }
        public Location MaxCorner { get; private set; }

        /// <summary>
        /// Create a cuboid from two corners.
        /// </summary>
        /// <param name="loc1">The first corner.</param>
        /// <param name="loc2">The second corner.</param>
        public Cuboid(Location loc1, Location loc2)
        {
            MinCorner = new Location(
                Math.Min(loc1.x, loc2.x),
                Math.Min(loc1.y, loc2.y),
                Math.Min(loc1.z, loc2.z)
            );

            MaxCorner = new Location(
                Math.Max(loc1.x, loc2.x),
                Math.Max(loc1.y, loc2.y),
                Math.Max(loc1.z, loc2.z)
            );
        }

        /// <summary>
        /// Check if the Cuboid contains a location.
        /// </summary>
        /// <param name="loc">The location to check.</param>
        /// <returns>If the location contains a cuboid.</returns>
        public bool Contains(Location loc)
        {
            return loc.x >= MinCorner.x && loc.x <= MaxCorner.x &&
                   loc.y >= MinCorner.y && loc.y <= MaxCorner.y &&
                   loc.z >= MinCorner.z && loc.z <= MaxCorner.z;
        }

        /// <summary>
        /// Check if this Cuboid overlaps another cubvoid.
        /// </summary>
        /// <param name="other">The other cuboid.</param>
        /// <returns>If the Cuboids overlap.</returns>
        public bool Overlaps(Cuboid other)
        {
            // If one cuboid is completely to the left, right, below, or above the other, they don't overlap.
            return !(other.MaxCorner.x < MinCorner.x || other.MinCorner.x > MaxCorner.x ||
                     other.MaxCorner.y < MinCorner.y || other.MinCorner.y > MaxCorner.y ||
                     other.MaxCorner.z < MinCorner.z || other.MinCorner.z > MaxCorner.z);
        }

        /// <summary>
        /// Check if other is completely contained within this cuboid.
        /// </summary>
        /// <param name="other">The other cuboid to check.</param>
        /// <returns>If other is completely contained within this cuboid.</returns>
        public bool Contains(Cuboid other)
        {
            return other.MinCorner.x >= MinCorner.x && other.MaxCorner.x <= MaxCorner.x &&
                   other.MinCorner.y >= MinCorner.y && other.MaxCorner.y <= MaxCorner.y &&
                   other.MinCorner.z >= MinCorner.z && other.MaxCorner.z <= MaxCorner.z;
        }

        /// <summary>
        /// The clamps the input Cuboid to fit inside this cubiod.
        /// 
        /// <para>For example, if this cuboid is ((0, 0, 0), (17, 17, 17)), and a cuboid of ((3, 3, 3), (20, 20, 20)) is inputed,
        /// the resulting Cuboid would be ((3, 3, 3), (17, 17, 17)). </para>
        /// </summary>
        /// <param name="other">The other cuboid to clamp within the bounds of this cuboid.</param>
        /// <returns>The clamped cuboid.</returns>
        public Cuboid Clamp(Cuboid other)
        {
            // Clamp the MinCorner of the other cuboid to the bounds of the current cuboid
            Location clampedMin = new Location(
                Math.Clamp(other.MinCorner.X, MinCorner.X, MaxCorner.X),
                Math.Clamp(other.MinCorner.Y, MinCorner.Y, MaxCorner.Y),
                Math.Clamp(other.MinCorner.Z, MinCorner.Z, MaxCorner.Z)
            );

            // Clamp the MaxCorner of the other cuboid to the bounds of the current cuboid
            Location clampedMax = new Location(
                Math.Clamp(other.MaxCorner.X, MinCorner.X, MaxCorner.X),
                Math.Clamp(other.MaxCorner.Y, MinCorner.Y, MaxCorner.Y),
                Math.Clamp(other.MaxCorner.Z, MinCorner.Z, MaxCorner.Z)
            );

            return new Cuboid(clampedMin, clampedMax);
        }

        public static Cuboid operator +(Cuboid current, Cuboid other)
        {
            var minCorner = new Location(
                Math.Min(current.MinCorner.x, other.MinCorner.x),
                Math.Min(current.MinCorner.y, other.MinCorner.y),
                Math.Min(current.MinCorner.z, other.MinCorner.z)
            );

            var maxCorner = new Location(
                Math.Max(current.MaxCorner.x, other.MaxCorner.x),
                Math.Max(current.MaxCorner.y, other.MaxCorner.y),
                Math.Max(current.MaxCorner.z, other.MaxCorner.z)
            );

            return new Cuboid(minCorner, maxCorner);
        }

    }
}
