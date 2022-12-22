using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Mods
{
    public interface Mod
    {
        string GetName();
        string GetVersion();
        string[] GetAuthors();
        string GetUppercaseName();
        void OnEnable();
    }
}
