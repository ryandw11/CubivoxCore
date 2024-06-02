namespace CubivoxCore
{
    /// <summary>
    /// Denotes that these objects have a name and can be identified with a <see cref="ControllerKey"/>.
    /// </summary>
    public interface Identifiable
    {
        /// <summary>
        /// The name of the object.
        /// </summary>
        /// <returns>The name of the object.</returns>
        string GetName();

        /// <summary>
        /// The controller key for the object.
        /// </summary>
        /// <returns>The key of the object.</returns>
        ControllerKey GetControllerKey();
    }
}
