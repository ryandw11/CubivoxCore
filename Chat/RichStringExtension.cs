using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.Chat
{
    public static class RichStringExtension
    {
        public static string Color(this string text, string color)
        {
            return $"<color = \"{color}\">{text}</color>";
        }

        public static string Italic(this string text)
        {
            return $"<i>{text}</i>";
        }

        public static string Bold(this string text)
        {
            return $"<b>{text}</b>";
        }

        public static string Underline(this string text)
        {
            return $"<u>{text}</u>";
        }
    }
}
