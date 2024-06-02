using CubivoxCore;
using CubivoxCore.Entities;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// Represents an entity that moves within the game.
    /// </summary>
    public interface GameEntity
    {
        /// <summary>
        /// Set the location of the entity.
        /// <para>Player Entities: This method can only be used on the server, except for the local player.</para>
        /// <para>Other Entities: Calling this on the client only moves the entity locally.</para>
        /// </summary>
        /// <param name="location">The location the entity should be moved to.</param>
        void SetLocation(Location location);

        /// <summary>
        /// Get the location of the entity.
        /// <para>Client: Not all entites will have a location available for retrevial, a null check should be performed.</para>
        /// <para>Server: A location is always guarenteed, this method will never return null.</para>
        /// </summary>
        /// <returns>The location of the entity (Client Side: null is possible)</returns>
        Location GetLocation();

        /// <summary>
        /// If the game entity is considered to be "alive" or "living".
        /// </summary>
        /// <returns>If the entity is considered to be living.</returns>
        bool IsLiving();

        /// <summary>
        /// Get the type of the entity.
        /// </summary>
        /// <returns>The type of the entity.</returns>
        Entity GetEntityType();
    }
}
