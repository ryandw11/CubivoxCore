using System;

namespace CubivoxCore.Events
{
    /// <summary>
    /// Manages the generic events for mods.
    /// 
    /// <para>An instance of the EventManager can be obtained from <see cref="Cubivox.GetEventManager"/>. Extended the <see cref="Event"/> class to create custom generic events.</para>
    /// </summary>
    public interface EventManager
    {
        /// <summary>
        /// Register an generic event handler with the EventManager.
        /// </summary>
        /// <typeparam name="T">The type of event to register.</typeparam>
        /// <param name="evt">The event handler method.</param>
        void RegisterEvent<T>(Action<T> evt) where T : Event;

        /// <summary>
        /// Trigger a specific generic event.
        /// 
        /// <para>If the event is cancelled, the execution of event handlers will stop.</para>
        /// </summary>
        /// <param name="evt">The event class to trigger.</param>
        /// <returns>If the event was cancelled.</returns>
        bool TriggerEvent(Event evt);
    }
}
