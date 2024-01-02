using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Commands
{
    /// <summary>
    /// An entity that can send commands and recieve messages.
    /// <para>Players and the server console are command senders.</para>
    /// </summary>
    public interface CommandSender
    {
        /// <summary>
        /// Send a message to the Command Sender.
        /// <para>This will be displayed in chat or in the server console.</para>
        /// </summary>
        /// <param name="message">The message to send to the command sender.</param>
        void SendMessage(string message);
    }
}
