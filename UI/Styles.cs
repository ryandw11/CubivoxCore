namespace CubivoxCore.UI
{
    /// <summary>
    /// This class is used to position and style a UI element.
    /// 
    /// <para>This class is the equivalent to Unity UIToolkit's IStyle interface.
    /// This class is used to modify the styling of the underlying UIToolkit element.</para>
    /// <para>Valid style keys can be found here in the Unity documentation: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/UIElements.IStyle.html </para>
    /// </summary>
    public abstract class Styles
    {
        public abstract void SetStyle(string key, float value);
        public abstract void SetStyle(string key, Length value);
        public abstract void SetStyle(string key, Color value);
        public abstract void SetStyle(string key, string value);

        /// <summary>
        /// Get a style.
        /// <para>Ensure T matches the type associated with the property. Note: all style properties support being a string.</para>
        /// </summary>
        /// <typeparam name="T">The type to get the style as.</typeparam>
        /// <param name="key">The property key. (See Unity documentation for a full list).</param>
        /// <returns>The property value as type T.</returns>
        /// <exception cref="ArgumentException">If key is not a valid property, or T is not a valid type for the property.</exception>
        public abstract T GetStyle<T>(string key);

        /// <summary>
        /// Get or set a style property in string form.
        /// </summary>
        /// <param name="key">The property key to get/set. (See Unity documentation for a full list).</param>
        /// <returns>The property value as a string.</returns>
        /// <exception cref="ArgumentException">If key is not a valid property.</exception>
        public string this[string key]
        {
            get => GetStyle<string>(key);
            set => SetStyle(key, value);
        }
    }
}
