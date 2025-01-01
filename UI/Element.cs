namespace CubivoxCore.UI
{
    /// <summary>
    /// An element is the base of a UI element that can be showed on the HUD.
    /// </summary>
    public interface Element
    {
        public string Name { get; set; }

        /// <summary>
        /// The style of the element. Use this property to change the position, and look of the UI element.
        /// </summary>
        public Styles Style { get; }

        /// <summary>
        /// Add a child element to this element.
        /// </summary>
        /// <param name="element">The child element to add.</param>
        void Add(Element element);
    }
}