namespace CubivoxCore.UI
{
    /// <summary>
    /// This represents a length for use by a style property in <see cref="Styles"/>.
    /// 
    /// <para>Properties that use a length can also be set in string form:</para>
    /// <code>var pixelLength = "20px";</code>
    /// <code>var percentLength = "20%";</code>
    /// </summary>
    public struct Length
    {
        /// <summary>
        /// The value of the length.
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// The unit of measurement that <see cref="Value"/> is in.
        /// </summary>
        public LengthUnit Unit { get; set; }

        /// <summary>
        /// Convert the length as a string.
        /// </summary>
        /// <returns>The length as a string.</returns>
        public override string ToString()
        {
            string suffix = Unit == LengthUnit.Pixel ? "px" : "%";
            return Value.ToString() + suffix;
        }

        /// <summary>
        /// Convert a string to a Length.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The string as a Length object.</returns>
        /// <exception cref="ArgumentException">If the string is malformed.</exception>
        public static Length FromString(string value)
        {
            var length = new Length();
            if (value.EndsWith("%"))
            {
                value = value.Replace("%", "");
                float val;
                if( !float.TryParse(value, out val) )
                {
                    throw new ArgumentException("Failed to parse Length string.");
                }
                length.Value = val;
                length.Unit = LengthUnit.Percent;
            }
            else if (value.EndsWith("px"))
            {
                value = value.Replace("px", "");
                float val;
                if (!float.TryParse(value, out val))
                {
                    throw new ArgumentException("Failed to parse Length string.");
                }
                length.Value = val;
                length.Unit = LengthUnit.Pixel;
            }

            return length;
        }
    }

    /// <summary>
    /// The unit of measurement that a <see cref="Length"/> value is in.
    /// </summary>
    public enum LengthUnit
    {
        Pixel,
        Percent
    }
}
