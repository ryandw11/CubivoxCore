using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Key : Attribute, PropertyAttribute<string>
    {
        private string key;
        public Key(string key)
        {
            this.key = key;
        }

        public string GetValue()
        {
            return key;
        }
    }
}
