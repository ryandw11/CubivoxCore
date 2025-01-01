namespace CubivoxCore
{
    /// <summary>
    /// Represents a color for use in Cubivox.
    /// <para>A color can be reprsented as a string:</para>
    /// <code>var stringColor = "rgba(red, green, blue, alpha)"</code>
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// The red value ranging from 0 to 1.
        /// </summary>
        public float R {  get; set; }

        /// <summary>
        /// The blue value ranging from 0 to 1.
        /// </summary>
        public float G { get; set; }

        /// <summary>
        /// The green value ranging from 0 to 1.
        /// </summary>
        public float B { get; set; }

        /// <summary>
        /// The alpha value ranging from 0 to 1.
        /// </summary>
        public float A { get; set; }

        /// <summary>
        /// Create a color object using float values.
        /// </summary>
        /// <param name="r">The red value (0 - 1)</param>
        /// <param name="g">The green value (0 - 1)</param>
        /// <param name="b">The blue value (0 - 1)</param>
        /// <param name="a">The alpha value (0 - 1)</param>
        public Color(float r, float g, float b, float a = 1)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Create a color object using byte values.
        /// </summary>
        /// <param name="r">The red value (0 - 255)</param>
        /// <param name="g">The green value (0 - 255)</param>
        /// <param name="b">The blue value (0 - 255)</param>
        /// <param name="a">The alpha value (0 - 255)</param>
        public Color(byte r, byte g, byte b, byte a = 255)
        {
            R = ((float)r) /255;
            G = ((float)g) / 255;
            B = ((float)b) / 255;
            A = ((float)a) / 255;
        }

        private static readonly string PREFIX = "rgba(";
        private static readonly string SUFFIX = ")";

        /// <summary>
        /// Convert the color to a string.
        /// </summary>
        /// <returns>The color as a string.</returns>
        public override string ToString()
        {
            return $"{PREFIX}{R},{G},{B},{A}{SUFFIX}";
        }

        /// <summary>
        /// Create a color object from a string.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The converted color object.</returns>
        /// <exception cref="ArgumentException">If the string s is malformed.</exception>
        public static Color FromString(string s)
        {
            s = s.Trim().ToLower();
            if (!s.StartsWith(PREFIX) || !s.EndsWith(SUFFIX))
            {
                throw new ArgumentException("Unable to parse color string, missing prefix or suffix.");
            }
            s = s.Replace(PREFIX, "").Replace(SUFFIX, "");
            string[] components = s.Split(',');
            if(components.Length != 3 && components.Length != 4)
            {
                throw new ArgumentException($"Invalid number of components, expected 3 or 4, but recieved {components.Length}.");
            }

            float[] rgba = new float[4];
            rgba[3] = 1;

            int i = 0;
            foreach(var component in components)
            {
                string comp = component.Replace(",", "").Trim();
                if( !float.TryParse(comp, out rgba[i]) )
                {
                    throw new ArgumentException($"Invalid component at index {i}, expected a float or byte.");
                }
                if (rgba[i] > 1)
                {
                    // Convert byte to float values.
                    rgba[i] = ((int)Math.Floor(rgba[i]))/255f;
                }

                if (rgba[i] > 1 || rgba[i] < 0)
                {
                    throw new ArgumentException($"Invalid component at index {i}, expected a value from range (0-1) or (0-255)");
                }
                ++i;
            }

            return new Color(rgba[0], rgba[1], rgba[2], rgba[3]);
        }
    }
}
