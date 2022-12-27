using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Commands
{
    public interface CommandSender
    {
        void SendMessage(string message);
    }
}
