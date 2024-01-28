using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Events
{
    /// <summary>
    /// Manages the events for mods.
    /// 
    /// <para>An instance of the EventManager can be obtained from <see cref="Cubivox.GetEventManager"/>. Extended the <see cref="Event"/> class to create custom events.</para>
    /// </summary>
    public interface EventManager
    {
        /// <summary>
        /// Register an event with the EventManager.
        /// </summary>
        /// <typeparam name="T">The type of event to register.</typeparam>
        /// <param name="evt">The event handler method.</param>
        void RegisterEvent<T>(Action<T> evt) where T : Event;

        /// <summary>
        /// Trigger a specific event.
        /// 
        /// <para>If the event is cancelled, the execution of event handlers will stop.</para>
        /// </summary>
        /// <param name="evt">The event class to trigger.</param>
        /// <returns>If the event was cancelled.</returns>
        bool TriggerEvent(Event evt);
    }
}
