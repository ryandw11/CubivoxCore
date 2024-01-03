using CubivoxCore.Mods;
using System;

namespace CubivoxCore
{
    public class ControllerKey
    {
        public readonly string controller;
        public readonly string key;

        public ControllerKey(string controller, string key)
        {
            this.controller = controller.ToUpper();
            this.key = key.ToUpper();
        }

        public ControllerKey(Mod mod, string key) : this(mod.GetUppercaseName(), key)
        {}

        public static ControllerKey create(string controller, string key)
        {
            return new ControllerKey(controller.ToUpper(), key.ToUpper());
        }

        public static bool operator ==(ControllerKey controllerKey1, ControllerKey controllerKey2)
        {
            return controllerKey1.controller == controllerKey2.controller && controllerKey1.key == controllerKey2.key;
        }

        public static bool operator !=(ControllerKey controllerKey1, ControllerKey controllerKey2)
        {
            return !(controllerKey1 == controllerKey2);
        }

        public override string ToString() => $"{controller}:{key}";

        public override bool Equals(object obj)
        {
            if (obj is ControllerKey)
            {
                return this == (ControllerKey) obj;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return new { controller, key }.GetHashCode();
        }
    }
}
