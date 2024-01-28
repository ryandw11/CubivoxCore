using CubivoxCore.BaseGame;
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
        string GetName();
        string GetVersion();
        string[] GetAuthors();
        string GetUppercaseName();
        string GetDescription();
        void OnEnable();
        void LoadItemsStage(ItemRegistry registry);
        void LoadGeneratorsStage(GeneratorRegistry registry);
    }
}
