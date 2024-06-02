using CubivoxCore.Attributes;

namespace CubivoxCore.Texturing
{
    /// <summary>
    /// Represents a texture within a <see cref="TextureAtlas"/>.
    /// 
    /// <para>Texturing APIs only exist on the client.</para>
    /// </summary>
    [ClientOnly]
    public abstract class AtlasTexture
    {
        /// <summary>
        /// The file path to the texture image.
        /// </summary>
        public string Location { protected set; get; }

        /// <summary>
        /// The id of the texture within the atlas.
        /// </summary>
        public int Id { protected set; get; }

        /// <summary>
        /// The x offset of the texture within the atlas.
        /// </summary>
        public float XOffset { protected set; get; }

        /// <summary>
        /// THe y offset of the texture within the atlas.
        /// </summary>
        public float YOffset { protected set; get; }

        protected AtlasTexture(string location)
        {
            Location = location;
        }
    }
}
