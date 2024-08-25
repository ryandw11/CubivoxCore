using CubivoxCore.Attributes;
using CubivoxCore.Mods;

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
        /// The root location of the texture resource.
        /// </summary>
        public TextureRoot Root { protected set; get; }

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

        private Mod mod;

        protected AtlasTexture(Mod mod, TextureRoot root, string location)
        {
            this.mod = mod;
            Root = root;
            Location = location;
        }

        /// <summary>
        /// Get the embedded resource stream.
        /// </summary>
        /// <returns>The embedded resource stream.</returns>
        /// <exception cref="InvalidOperationException">If the Root of the AtlasTexture is not embedded.</exception>
        public Stream GetEmbeddedResourceStream()
        {
            if(Root != TextureRoot.EMBEDDED)
            {
                throw new InvalidOperationException("Cannot get the resource stream for an object that is not embedded.");
            }

            var modAssembly = mod.GetType().Assembly;
            return modAssembly.GetManifestResourceStream($"{modAssembly.GetName().Name}.resources.{Location}");
        }
    }
}
