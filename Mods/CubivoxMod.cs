using CubivoxCore.BaseGame;
using CubivoxCore.Console;
using CubivoxCore.Worlds.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Mods
{
    /// <summary>
    /// Extend this class to create a mod for Cubivox.
    /// </summary>
    public abstract class CubivoxMod : Mod
    {
        private ModDescriptionFile modDescriptionFile;
        private Logger logger;

        public CubivoxMod() { }

        public CubivoxMod(ModDescriptionFile modDescriptionFile, Logger logger) 
        { 
            this.modDescriptionFile = modDescriptionFile;
            this.logger = logger;
        }

        public string[] GetAuthors()
        {
            return modDescriptionFile.Authors;
        }

        public string GetDescription()
        {
            return modDescriptionFile.Description;
        }

        public string GetName()
        {
            return modDescriptionFile.ModName;
        }

        public string GetUppercaseName()
        {
            return modDescriptionFile.ModName.ToUpper();
        }

        public string GetVersion()
        {
            return modDescriptionFile.Version;
        }

        public void LoadGeneratorsStage(GeneratorRegistry registry)
        {
        }

        public void LoadItemsStage(ItemRegistry registry)
        {
        }

        public abstract void OnEnable();

        public Logger GetLogger()
        {
            return logger;
        }
    }
}
