using System;

using CubivoxCore.Attributes;
using CubivoxCore.Events;
using CubivoxCore.Items;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;

namespace CubivoxCore.Voxels
{
    /// <summary>
    /// Define a new Voxel type that can be placed in the world.
    /// 
    /// <para>Mods should extend this class to create new voxels.</para>
    /// </summary>
    public class ModVoxel : ModItem, VoxelDef
    {
        protected AtlasTexture atlasTexture;
        protected bool transparent;

        public ModVoxel(Mod mod) : base(mod)
        {
            if (GetModel() == null && Cubivox.GetEnvironment() != EnvType.SERVER)
            {
                // Atlas textures do not exist on the server.
                atlasTexture = Cubivox.GetTextureAtlas().CreateAtlasTexture(GetTexture());
            }

            transparent = GetType().GetCustomAttributes(typeof(Transparent), true).Length > 0;
        }

        public AtlasTexture GetAtlasTexture()
        {
            return atlasTexture;
        }

        public bool IsTransparent()
        {
            return transparent;
        }

        public VoxelDefPlaceEventDelegate _PlaceEvent { get; set; }
        /// <summary>
        /// This event is triggered whenever a player places a defined voxel.
        /// 
        /// <para>Use the <see cref="ClientOnly"/> or <see cref="ServerOnly"/> attributes to limit the event to trigger only on the client or the server.</para>
        /// </summary>
        public event VoxelDefPlaceEventDelegate PlaceEvent
        {
            add
            {
                if (value.Method.GetCustomAttributes(typeof(ClientOnly), true).Length > 0)
                {
                    if (Cubivox.GetEnvironment() == EnvType.CLIENT)
                    {
                        _PlaceEvent += value;
                    }
                }
                else if (value.Method.GetCustomAttributes(typeof(ServerOnly), true).Length > 0)
                {
                    if (Cubivox.GetEnvironment() == EnvType.SERVER)
                    {
                        _PlaceEvent += value;
                    }
                }
                else
                {
                    _PlaceEvent += value;
                }
            }
            remove { _PlaceEvent -= value; }
        }

        public VoxelDefBreakEventDelegate _BreakEvent { get; set; }
        /// <summary>
        /// This event is triggered whenever a player breaks a defined voxel.
        /// 
        /// <para>Use the <see cref="ClientOnly"/> or <see cref="ServerOnly"/> attributes to limit the event to trigger only on the client or the server.</para>
        /// </summary>
        public event VoxelDefBreakEventDelegate BreakEvent
        {
            add
            {
                if (value.Method.GetCustomAttributes(typeof(ClientOnly), true).Length > 0)
                {
                    if (Cubivox.GetEnvironment() == EnvType.CLIENT)
                    {
                        _BreakEvent += value;
                    }
                }
                else if (value.Method.GetCustomAttributes(typeof(ServerOnly), true).Length > 0)
                {
                    if (Cubivox.GetEnvironment() == EnvType.SERVER)
                    {
                        _BreakEvent += value;
                    }
                }
                else
                {
                    _BreakEvent += value;
                }
            }
            remove { _BreakEvent -= value; }
        }
    }
}
