using CubivoxCore.Chat;
using CubivoxCore.Players;

namespace CubivoxCore.Events.Global
{
    /// <summary>
    /// This event is triggered when a player leaves the server.
    /// 
    /// <para>The leave message broadcasted to other players in the server can be modified here. An empty message is not sent to other players.</para>
    /// </summary>
    public class PlayerLeaveEvent : Event
    {

        public Player Player { get; private set; }

        /// <summary>
        /// The message that is sent to other players in the server when a player leaves.
        /// 
        /// <para>The {0} placeholder is the player's name.</para>
        /// </summary>
        public string Message { get; set; }

        public PlayerLeaveEvent(Player player)
        {
            Player = player;
            Message = "{0} has left the game!".Color("yellow");
        }
    }
}
