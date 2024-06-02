using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Texture : Attribute, PropertyAttribute<string>
    {
        private string texture;
        public Texture(string texture)
        {
            this.texture = texture;
        }

        public string GetValue()
        {
            return texture;
        }
    }
}
