using CubivoxCore.Attributes;
using CubivoxCore.Mods;
using CubivoxCore.Texturing;
using CubivoxCore.Utils;

namespace CubivoxCore.Items
{
    /// <summary>
    /// An abstrct implementation of <see cref="Item"/> that provides utilities.
    /// 
    /// <para>Mods should use this class to define new items for their mods.</para>
    /// 
    /// <para>To define the properties of the item, use the <see cref="Key"/>, <see cref="Model"/>, <see cref="Name"/>, and <see cref="Texture"/> attributes.
    /// The <see cref="Name"/> and <see cref="Key"/> attributes are required.</para>
    /// </summary>
    public abstract class ModItem : Item
    {
        protected readonly ControllerKey controllerKey;
        protected readonly Mod mod;
        protected readonly string name;
        protected readonly TextureRoot textureRoot;
        protected string texture;

        public ModItem(Mod mod)
        {
            this.mod = mod;

            name = PropertyUtils.RequiredProperty<Name, string>(GetType());
            controllerKey = new ControllerKey(mod, PropertyUtils.RequiredProperty<Key, string>(GetType()));
            texture = PropertyUtils.Property<Texture, string>(GetType());
            if(GetType().GetCustomAttributes(typeof(Texture), true).Length > 0)
            {
                textureRoot = ((Texture)GetType().GetCustomAttributes(typeof(Texture), true)[0]).GetRoot();
            }
        }

        public TextureRoot GetTextureRoot()
        {
            return textureRoot;
        }

        public string GetTexture()
        {
            return texture;
        }

        public string GetModel()
        {
            Model[] model = (Model[])GetType().GetCustomAttributes(typeof(Model), true);
            if (model.Length < 1) return null;

            return model[0].GetValue();
        }

        public Mod GetMod()
        {
            return mod;
        }

        public string GetName()
        {
            return name;
        }

        public ControllerKey GetControllerKey()
        {
            return controllerKey;
        }
    }
}
