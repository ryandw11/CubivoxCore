using CubivoxCore.Players;

namespace CubivoxCore.Events.Global
{
    /// <summary>
    /// This event is triggered when a player moves from one point to another. Only the player moving will trigger this event.
    /// 
    /// <para>Canceling this event on the server will move the player back to their previous location.</para>
    /// </summary>
    public class PlayerMoveEvent : CancellableEvent
    {
        public Player Player { get; private set; }
        public Location NewLocation { get; private set; }
        public Location OldLocation { get; private set; }

        public PlayerMoveEvent(Player player, Location newLocation, Location oldLocation)
        {
            Player = player;
            NewLocation = newLocation;
            OldLocation = oldLocation;
        }
    }
}
