using CubivoxCore.Attributes;
using CubivoxCore.Voxels;

namespace CubivoxCore.Worlds
{
    /// <summary>
    /// This determines how voxels added when a lock is being held should be treated.
    /// </summary>
    public enum BulkEditBehavior
    {
        /// <summary>
        /// Any placed voxels from the start to the end of the bulk edit will be overwritten.
        /// </summary>
        OVERWRITE,
        /// <summary>
        /// Ignore (prevent) any voxels that are placed when the bulk edit is locked.
        /// </summary>
        IGNORE,
        /// <summary>
        /// Queue up the changes to apply them after the edit has been completed. (The voxels will also be placed while the lock is held).
        /// </summary>
        QUEUE
    }
}
