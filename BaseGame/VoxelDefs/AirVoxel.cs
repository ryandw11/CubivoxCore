﻿using CubivoxCore.Events.Local;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Utils;
using CubivoxCore.Voxels;

namespace CubivoxCore.BaseGame.VoxelDefs
{
    /// <summary>
    /// This voxel is used to represent "Air", "Void", or "Empty Space" within Cubivox.
    /// </summary>
    public sealed class AirVoxel : VoxelDef
    {
        /// <returns>Will always return null.</returns>
        public AtlasTexture GetAtlasTexture()
        {
            return null;
        }

        public ControllerKey GetControllerKey()
        {
            return Voxels.AIR;
        }

        public Mod GetMod()
        {
            return Cubivox.GetInstance();
        }

        /// <returns>Always returns null.</returns>
        public string GetModel()
        {
            return null;
        }

        public string GetName()
        {
            return "air";
        }

        /// <returns>Always returns null.</returns>
        public string GetTexture()
        {
            return null;
        }

        /// <returns>Always returns true.</returns>
        public bool IsTransparent()
        {
            return true;
        }

        /// <summary>
        /// Internal; Not implemented.
        /// </summary>
        public VoxelDefPlaceEventDelegate _PlaceEvent { get; set; }
        /// <summary>
        /// Internal; Not implemented.
        /// </summary>
        public VoxelDefBreakEventDelegate _BreakEvent { get; set; }
    }
}
