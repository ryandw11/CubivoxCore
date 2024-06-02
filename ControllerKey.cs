using CubivoxCore.Mods;
using System;

namespace CubivoxCore
{
    /// <summary>
    /// A ControllerKey is string pair used to identify different objects within Cubivox.
    /// 
    /// <para>A Controller is the name of the mod that the object belongs to and a Key is the key for that object.</para>
    /// </summary>
    public sealed class ControllerKey
    {
        /// <summary>
        /// The controller
        /// <para>This value will be UPPERCASE.</para>
        /// </summary>
        public readonly string Controller;

        /// <summary>
        /// The key
        /// <para>This value will be UPPERCASE.</para>
        /// </summary>
        public readonly string Key;

        /// <summary>
        /// Create a controller key.
        /// 
        /// <para>In most cases <see cref="ControllerKey(Mod, string)"/> should be used.</para>
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="key">The key.</param>
        public ControllerKey(string controller, string key)
        {
            Controller = controller.ToUpper();
            Key = key.ToUpper();
        }

        public ControllerKey(Mod mod, string key) : this(mod.GetUppercaseName(), key)
        {}

        public static ControllerKey Create(string controller, string key)
        {
            return new ControllerKey(controller.ToUpper(), key.ToUpper());
        }

        public static bool operator ==(ControllerKey controllerKey1, ControllerKey controllerKey2)
        {
            return controllerKey1.Controller == controllerKey2.Controller && controllerKey1.Key == controllerKey2.Key;
        }

        public static bool operator !=(ControllerKey controllerKey1, ControllerKey controllerKey2)
        {
            return !(controllerKey1 == controllerKey2);
        }

        public override string ToString() => $"{Controller}:{Key}";

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
            return new { Controller, Key }.GetHashCode();
        }
    }
}
