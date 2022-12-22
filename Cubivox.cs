using CubivoxCore.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore
{
    internal class Cubivox : Mod
    {
        private static Cubivox instance;

        public Cubivox()
        {
            instance = this;
        }

        public string[] GetAuthors()
        {
            return new string[] { "Ryandw11" };
        }

        public string GetName()
        {
            return "Cubivox";
        }

        public string GetUppercaseName()
        {
            return "CUBIVOX";
        }

        public string GetVersion()
        {
            return "1.0";
        }

        public void OnEnable()
        {
            
        }

        public static Cubivox GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("The cubivox base game has not been initalized yet!");
            }
            return instance;
        }
    }
}
