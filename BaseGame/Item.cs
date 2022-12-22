using CubivoxCore.Mods;

namespace CubivoxCore.BaseGame
{
    public interface Item : Identifiable
    {
        string GetTexture();
        string GetModel();
        Mod GetMod();
    }
}
