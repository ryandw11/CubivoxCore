namespace CubivoxCore.Events
{
    /// <summary>
    /// The generic class that all "Global" events inherit from.
    /// 
    /// <para>Global events are events that are broadcasted to every single mod when an generic action is done.</para>
    /// </summary>
    public class Event
    {
    }


    /// <summary>
    /// The generic class that all cancellable global events inherit from.
    /// </summary>
    public class CancellableEvent : Event
    {
        private bool canceled;

        /// <summary>
        /// Check if the event is canceled.
        /// </summary>
        /// <returns>If the event is canceled.</returns>
        public bool IsCanceled()
        {
            return canceled;
        }

        /// <summary>
        /// Cancel the event.
        /// </summary>
        public void Cancel()
        {
            canceled = true;
        }
    }
}
