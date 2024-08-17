namespace CubivoxCore.Scheduler
{
    /// <summary>
    /// Schedule tasks/actions to be executed on specific threads or at a specific point in time.
    /// 
    /// <para>This class is thread safe.</para>
    /// </summary>
    public abstract class CubivoxScheduler
    {
        protected static CubivoxScheduler mInstance;

        public abstract void RunOnMainThreadImpl(Action action);
        public abstract void RunOnMainThreadSynchronizedImpl(Action action);

        /// <summary>
        /// Execute an action on the main thread.
        /// <para>On the client, the action will execute on the next frame.</para>
        /// <para>On the server, the action will execute on the next tick.</para>
        /// </summary>
        /// <param name="action">The action to execute on the main thread.</param>
        /// <exception cref="NotImplementedException">This will never occur on a normal installation of Cubivox.</exception>
        public static void RunOnMainThread(Action action)
        {
            if(mInstance == null)
            {
                throw new NotImplementedException();
            }

            mInstance.RunOnMainThreadImpl(action);
        }

        /// <summary>
        /// If already on the main thread, execute the action in place immediately, else schedule it to be executed on the main thread.
        /// <para>If not already on the main thread and on the client, the action will execute on the next frame.</para>
        /// <para>If not already on the main thread and on the server, the action will execute on the next tick.</para>
        /// </summary>
        /// <param name="action">The action to execute on the main thread.</param>
        /// <exception cref="NotImplementedException">This will never occur on a normal installation of Cubivox.</exception>
        public static void RunOnMainThreadSynchronized(Action action)
        {
            if(mInstance == null)
            {
                throw new NotImplementedException();
            }

            mInstance.RunOnMainThreadSynchronizedImpl(action);
        }
    }
}
