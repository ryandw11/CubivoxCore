using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Events
{
    public class Event
    {
    }

    public class CancellableEvent : Event
    {
        private bool canceled;

        public bool IsCanceled()
        {
            return canceled;
        }

        public void Cancel()
        {
            canceled = true;
        }
    }
}
