namespace CubivoxCore.Texturing
{
    /// <summary>
    /// The root location of a texture resource.
    /// </summary>
    public enum TextureRoot
    {
        /// <summary>
        /// Texture is included within the Cubivox Client.
        /// </summary>
        CUBIVOX,
        /// <summary>
        /// Texture is an embedded resource within the mod's assembly.
        /// </summary>
        EMBEDDED
    }
}
