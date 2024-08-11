using System;

namespace CubivoxCore.Mods
{
    /// <summary>
    /// Represents the file that describes a mod. 
    /// </summary>
    [Serializable]
    public class ModDescriptionFile
    {

        public string ModName;
        public string MainClass;
        public string Description;
        public string Version;
        public string[] Authors;
    }
}
