namespace CubivoxCore.Chat
{
    /// <summary>
    /// Easily embed rich text information within strings.
    /// 
    /// <code>
    /// string message = ("My" + "very".Bold() + "cool message").Color("Red");
    /// </code>
    /// </summary>
    public static class RichStringExtension
    {
        /// <summary>
        /// Set the color of the text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color">Can be the name of a color ("Red") or its hexadecimal format.</param>
        /// <returns>The formated string.</returns>
        public static string Color(this string text, string color)
        {
            return $"<color=\"{color}\">{text}</color>";
        }

        /// <summary>
        /// Italicize the specified text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The formated string.</returns>
        public static string Italic(this string text)
        {
            return $"<i>{text}</i>";
        }

        /// <summary>
        /// Bold the specified text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The formated string.</returns>
        public static string Bold(this string text)
        {
            return $"<b>{text}</b>";
        }

        /// <summary>
        /// Underline the specified text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The formated string.</returns>
        public static string Underline(this string text)
        {
            return $"<u>{text}</u>";
        }
    }
}
