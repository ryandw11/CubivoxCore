using CubivoxCore.BaseGame;
using CubivoxCore.Console;
using CubivoxCore.Events;
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
        protected Logger Logger { get; private set; }

        public CubivoxMod() { }

        public CubivoxMod(ModDescriptionFile modDescriptionFile, Logger logger) 
        { 
            this.modDescriptionFile = modDescriptionFile;
            Logger = logger;
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

        public virtual void LoadGeneratorsStage(GeneratorRegistry registry)
        {
        }

        public virtual void LoadItemsStage(ItemRegistry registry)
        {
        }

        public abstract void OnEnable();

        public Logger GetLogger()
        {
            return Logger;
        }

        protected void RegisterEvent<T>(Action<T> evt) where T : Event
        {
            Cubivox.GetEventManager().RegisterEvent(evt);
        }
    }
}
