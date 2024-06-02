using CubivoxCore.Commands;
using CubivoxCore.Permissions;
using CubivoxCore.Worlds;

namespace CubivoxCore.Players
{
    /// <summary>
    /// The interface that represents an entity that is controlled by a user.
    /// </summary>
    public interface Player : GameEntity, CommandSender, Permissible
    {
        /// <summary>
        /// Get the UUID of the player.
        /// </summary>
        /// <returns>The UUID of the player.</returns>
        Guid GetUUID();

        /// <summary>
        /// Get the name of the player.
        /// </summary>
        /// <returns>The name of the player.</returns>
        string GetName();

        /// <summary>
        /// Disconnect the user from the server.
        /// <para>You can only disconnect the local player when running client-side.</para>
        /// </summary>
        /// <param name="reason">The reason to be displayed for the disconnection.</param>
        void Kick(string reason);
    }
}
