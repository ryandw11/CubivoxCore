using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Texture : Attribute
    {
        private string texture;
        public Texture(string texture)
        {
            this.texture = texture;
        }

        public string GetTexture()
        {
            return texture;
        }
    }
}
