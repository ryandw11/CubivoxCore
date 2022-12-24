using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.BaseGame.Texturing
{
    public class AtlasTexture
    {
        public string location { private set; get; }
        public int id { private set; get; }
        public float xOffset { private set; get; }
        public float yOffset { private set; get; }
        
        public AtlasTexture(string location)
        {
            this.location = location.Replace(".png", "");
        }
    }
}
