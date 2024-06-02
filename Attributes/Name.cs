using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubivoxCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Name : Attribute, PropertyAttribute<string>
    {
        private string name;
        public Name(string name)
        {
            this.name = name;
        }

        public string GetValue()
        {
            return name;
        }
    }
}
