using CubivoxCore.Chat;
using CubivoxCore.Players;

namespace CubivoxCore.Events.Global
{
    /// <summary>
    /// This event is triggered when a player joins the server. This event cannot be canceled. Instead you should kick a player to prevent them from joining.
    /// 
    /// <para>The join message broadcasted to other players in the server can be modified here. An empty message is not sent to other players.</para>
    /// </summary>
    public class PlayerJoinEvent : Event
    {
        public Player Player { get; private set; }

        /// <summary>
        /// The message that is sent to other players in the server when a player joins.
        /// 
        /// <para>The {0} placeholder is the player's name.</para>
        /// </summary>
        public string Message { get; set; }

        public PlayerJoinEvent(Player player)
        {
            Player = player;
            Message = "{0} has joined the game!".Color("Yellow");
        }
    }
}
