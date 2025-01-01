using CubivoxCore.Attributes;

namespace CubivoxCore.UI
{
    /// <summary>
    /// The HUD represents the heads up display that players see.
    /// 
    /// <para>This is a client only API.</para>
    /// </summary>
    [ClientOnly]
    public interface Hud
    {

        /// <summary>
        /// Add an element to the HUD.
        /// </summary>
        /// <param name="element">The element to add.</param>
        void AddElement(Element element);

        /// <summary>
        /// Remove an element from the HUD.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        void RemoveElement(Element element);

        /// <summary>
        /// Create a label element to place on the HUD.
        /// </summary>
        /// <returns>A label element.</returns>
        Label CreateLabel();
    }
}
