using CubivoxCore.Attributes;
using CubivoxCore.BaseGame.Texturing;
using CubivoxCore.Events;

namespace CubivoxCore.BaseGame
{
    public interface VoxelDef : Item
    {
        /// <summary>
        /// This event is triggered whenever a player places to defined voxel.
        /// 
        /// <para>Use the <see cref="ClientOnly"/> or <see cref="ServerOnly"/> attributes to limit the event to trigger only on the client or the server.</para>
        /// <para>Th</para>
        /// </summary>
        internal event VoxelPlaceEvent VoxelPlaceEvent
        {
            add
            {
                if (value.GetType().GetCustomAttributes(typeof(ClientOnly), true).Length > 0 && Cubivox.GetEnvironment() == EnvType.CLIENT)
                {
                    VoxelPlaceEvent += value;
                }
                else if (value.GetType().GetCustomAttributes(typeof(ServerOnly), true).Length > 0 && Cubivox.GetEnvironment() == EnvType.SERVER)
                {
                    VoxelPlaceEvent += value;
                }
                else
                {
                    VoxelPlaceEvent += value;
                }
            }
            remove { VoxelPlaceEvent -= value; }
        }

        AtlasTexture GetAtlasTexture();
        bool IsTransparent();
    }
}
