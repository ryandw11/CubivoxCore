using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Mods
{
    /// <summary>
    /// Represents the file that describes a mod. 
    /// </summary>
    public struct ModDescriptionFile
    {

        public string ModName { get; set; }
        public string MainClass { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string[] Authors { get; set; }
    }
}
