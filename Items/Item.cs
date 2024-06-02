using CubivoxCore.Mods;

namespace CubivoxCore.Items
{
    /// <summary>
    /// An item is an object in Cubivox that can be: placed, held, or used, by a player.
    /// 
    /// <para>A Voxel counts as an item since they can technically be held.</para>
    /// 
    /// <para>Mods should define new items using <see cref="ModItem"/>.</para>
    /// </summary>
    public interface Item : Identifiable
    {

        /// <summary>
        /// The file path to the texture of an item.
        /// </summary>
        /// <returns>The texture of an item.</returns>
        string GetTexture();

        /// <summary>
        /// The file path to the model of an item.
        /// </summary>
        /// <returns>The model of an item.</returns>
        string GetModel();

        /// <summary>
        /// The mod instance that the item belongs to.
        /// </summary>
        /// <returns>The mode instance that the item belongs to.</returns>
        Mod GetMod();
    }
}
