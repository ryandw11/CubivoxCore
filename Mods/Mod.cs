using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Mods
{
    /// <summary>
    /// The main interface for all mods to extend from.
    /// </summary>
    public interface Mod
    {
        string GetName();
        string GetVersion();
        string[] GetAuthors();
        string GetUppercaseName();
        void OnEnable();
    }
}
