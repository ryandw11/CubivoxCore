using System;

namespace CubivoxCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Model : Attribute, PropertyAttribute<string>
    {
        private string model;
        public Model(string model)
        {
            this.model = model;
        }

        public string GetValue()
        {
            return model;
        }
    }
}
