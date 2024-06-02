using CubivoxCore.Voxels;

namespace CubivoxCore.Items
{
    /// <summary>
    /// The item registry is responsible for handeling Item and Voxel defintions for use in the game.
    /// 
    /// <para>This is where new items/voxels are registered and their definitions are obtained.</para>
    /// </summary>
    public interface ItemRegistry
    {
        /// <summary>
        /// Register an item for use.
        /// </summary>
        /// <param name="item">The item defition to register.</param>
        void RegisterItem(Item item);
        
        /// <summary>
        /// Un register an item for use.
        /// </summary>
        /// <param name="item">The item definition to unregister.</param>
        void UnregisterItem(Item item);

        /// <summary>
        /// Get the list of all registered items.
        /// </summary>
        /// <returns>The list of all registered items.</returns>
        List<Item> GetItems();

        /// <summary>
        /// Get the item for a specific ControllerKey.
        /// </summary>
        /// <param name="key">The ControllerKey of the item to get.</param>
        /// <returns>The item defition.</returns>
        Item GetItem(ControllerKey key);

        /// <summary>
        /// Get a VoxelDef for a specific ControllerKey.
        /// 
        /// <para>This method will only get voxel defintions in particalar. <see cref="GetItem(ControllerKey)"/> can also be used to get a voxel definition.</para>
        /// </summary>
        /// <param name="key">The ControllerKey of the voxel definition to get.</param>
        /// <returns>The voxel definition.</returns>
        VoxelDef GetVoxelDefinition(ControllerKey key);
    }
}
