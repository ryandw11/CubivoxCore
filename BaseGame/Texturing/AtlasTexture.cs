using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.BaseGame.Texturing
{
    public abstract class AtlasTexture
    {
        public string location { protected set; get; }
        public int id { protected set; get; }
        public float xOffset { protected set; get; }
        public float yOffset { protected set; get; }
        
        protected AtlasTexture(string location)
        {
            this.location = location;
        }
    }
}
