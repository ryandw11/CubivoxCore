using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Console
{
    public interface Logger
    {
        void Info(string message);
        void Debug(string message);
        void Warn(string message);
        void Error(string message);
    }
}
