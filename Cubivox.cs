﻿using CubivoxCore.BaseGame;
using CubivoxCore.Mods;

using System;

namespace CubivoxCore
{
    /// <summary>
    /// The Mod that represents the Cubivox game itself.
    /// <br/>
    /// This is special and implemented by both the Client and Server.
    /// <br/>
    /// This class contains all the important components of Cubivox, such as the <see cref="ItemRegistry"/>.
    /// </summary>
    public abstract class Cubivox : Mod
    {
        protected static Cubivox instance;
        protected ItemRegistry itemRegistry;

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

        public abstract void OnEnable();
        public abstract EnvType GetEnvType();

        public static Cubivox GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("The cubivox base game has not been initalized yet!");
            }
            return instance;
        }

        public static ItemRegistry GetItemRegistry()
        {
            return GetInstance().itemRegistry;
        }

        public static EnvType GetEnvironment()
        {
            return GetInstance().GetEnvType();
        }
    }
}
