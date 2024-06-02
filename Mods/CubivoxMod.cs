using CubivoxCore.Console;
using CubivoxCore.Events;
using CubivoxCore.Items;
using CubivoxCore.Worlds.Generation;
using System;

namespace CubivoxCore.Mods
{
    /// <summary>
    /// The base class for Cubivox mods.
    /// 
    /// <para>Extend this class to create a mod for Cubivox.</para>
    /// </summary>
    public abstract class CubivoxMod : Mod
    {
        private ModDescriptionFile modDescriptionFile;
        /// <summary>
        /// The Logger for the mod.
        /// </summary>
        protected Logger Logger { get; private set; }

        public CubivoxMod() { }

        /// <summary>
        /// This constructor is called by Cubivox to instantiate the mod.
        /// 
        /// <para>Important: Do not perform any Cubivox API calls in the constructor. Use <see cref="OnEnable"/> and the loading stages instead.</para>
        /// </summary>
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

        /// <summary>
        /// Register an event handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="evt">The event handler to register.</param>
        protected void RegisterEvent<T>(Action<T> evt) where T : Event
        {
            Cubivox.GetEventManager().RegisterEvent(evt);
        }
    }
}
