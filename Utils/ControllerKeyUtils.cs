namespace CubivoxCore.Utils
{
    /// <summary>
    /// A utility class for ControllerKeys.
    /// </summary>
    public sealed class ControllerKeyUtils
    {
        /// <summary>
        /// The controller for Cubivox.
        /// </summary>
        public static readonly string CUBIVOX_NAME = "CUBIVOX";

        /// <summary>
        /// Construct a CubivoxController key.
        /// </summary>
        /// <param name="key"> The key to construct the controller key from.</param>
        /// <returns>A Cubivox controller key.</returns>
        public static ControllerKey CubivoxControllerKey(string key)
        {
            return new ControllerKey(CUBIVOX_NAME, key);
        }
    }
}
