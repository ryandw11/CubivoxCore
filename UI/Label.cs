using CubivoxCore.Chat;

namespace CubivoxCore.UI
{
    /// <summary>
    /// This represents a Label from Unity's UIToolkit.
    /// 
    /// <para>This label can be displayed as an element on the HUD.</para>
    /// <para>Create a label using <see cref="Hud.CreateLabel"/>.</para>
    /// </summary>
    public interface Label : Element
    {
        /// <summary>
        /// The text of the label. This does support formatted text if <see cref="SupportsRichText"/> is set to true.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// If <see cref="Text"/> supports formatted strings, like <see cref="RichStringExtension.Color(string, string)"/>.
        /// </summary>
        public bool SupportsRichText { get; set; }
    }
}
