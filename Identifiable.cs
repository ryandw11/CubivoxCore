using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore
{
    public interface Identifiable
    {
        string GetName();
        ControllerKey GetControllerKey();
    }
}
