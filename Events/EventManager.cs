using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Events
{
    public interface EventManager
    {
        void RegisterEvent(GenericEventDelegate evt);
        void TriggerEvent(Event evt);
    }
}
