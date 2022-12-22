using CubivoxCore.Attributes;
using CubivoxCore.BaseGame;

namespace CubivoxCore.Mods
{
    public abstract class ModItem : Item
    {
        protected readonly ControllerKey controllerKey;
        protected readonly Mod mod;
        protected readonly string name;
        protected string texture;

        public ModItem(Mod mod)
        {
            this.mod = mod;

            Name name = (Name) GetType().GetCustomAttributes(typeof(Name), true)[0];
            this.name = name.GetValue();

            Key key = (Key)GetType().GetCustomAttributes(typeof(Key), true)[0];
            this.controllerKey = new ControllerKey(mod, key.GetValue());

            Texture texture = (Texture) GetType().GetCustomAttributes(typeof(Texture), true)[0];
            this.texture = texture.GetTexture();
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
