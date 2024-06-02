using CubivoxCore.Console;
using CubivoxCore.Items;
using CubivoxCore.Worlds.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Mods
{
    /// <summary>
    /// Represents a mod for Cubivox.
    /// 
    /// <para>It is recommended that mods use <see cref="CubivoxMod"/> for their implementation.</para>
    /// </summary>
    public interface Mod
    {
        /// <summary>
        /// Get the name of a mod.
        /// </summary>
        /// <returns>The name of a mod.</returns>
        string GetName();

        /// <summary>
        /// Ge thte version string of a mod.
        /// </summary>
        /// <returns>The version string of the mod.</returns>
        string GetVersion();

        /// <summary>
        /// Get the list of authors.
        /// </summary>
        /// <returns>An array of the mod authors.</returns>
        string[] GetAuthors();

        /// <summary>
        /// Get the uppercased name of the mod.
        /// </summary>
        /// <returns>The name of the mod in all uppercase.</returns>
        string GetUppercaseName();

        /// <summary>
        /// The description of the mod.
        /// </summary>
        /// <returns>The description of the mod.</returns>
        string GetDescription();

        /// <summary>
        /// This method is called when the mod is first enabled.
        /// </summary>
        void OnEnable();

        /// <summary>
        /// The loading stage where items should be registered to Cubivox.
        /// </summary>
        /// <param name="registry">The item registry instance.</param>
        void LoadItemsStage(ItemRegistry registry);

        /// <summary>
        /// The loading stage where world generators should be registered to Cubivox.
        /// 
        /// <para>This will only be called on the server.</para>
        /// </summary>
        /// <param name="registry">The generator registry instance.</param>
        void LoadGeneratorsStage(GeneratorRegistry registry);

        /// <summary>
        /// Get the logger for the mod.
        /// </summary>
        /// <returns>The logger for the mod.</returns>
        Logger GetLogger();
    }
}
