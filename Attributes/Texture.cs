using CubivoxCore.Texturing;

namespace CubivoxCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Texture : Attribute, PropertyAttribute<string>
    {
        private TextureRoot root;
        private string texture;

        public Texture(string texture)
        {
            root = TextureRoot.EMBEDDED;
            this.texture = texture;
        }

        public Texture(TextureRoot textureRoot, string texture)
        {
            root = textureRoot;
            this.texture = texture;
        }

        public string GetValue()
        {
            return texture;
        }

        public TextureRoot GetRoot()
        {
            return root;
        }
    }
}
