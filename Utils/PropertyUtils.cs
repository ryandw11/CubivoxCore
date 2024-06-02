using CubivoxCore.Attributes;
using CubivoxCore.Exceptions;
using System;
using System.Reflection;

namespace CubivoxCore.Utils
{
    /// <summary>
    /// Utility for property attributes.
    /// 
    /// <para>This is mainly for internal use only.</para>
    /// </summary>
    internal sealed class PropertyUtils
    {
        public static S RequiredProperty<T, S>(Type classType) where T : PropertyAttribute<S>
        {
            object[] attributes = classType.GetCustomAttributes(typeof(T), true);

            if (attributes.Length < 1)
            {
                throw new MissingPropertyExcaption($"The {classType.Name} property attribute is required for this class!");
            }
            PropertyAttribute<S> propertyAttribute = (PropertyAttribute<S>) attributes[0];

            return propertyAttribute.GetValue();
        }

        public static S Property<T, S>(Type classType) where T : PropertyAttribute<S>
        {
            object[] attributes = classType.GetCustomAttributes(typeof(T), true);

            if (attributes.Length < 1)
            {
                return default;
            }
            PropertyAttribute<S> propertyAttribute = (PropertyAttribute<S>)attributes[0];

            return propertyAttribute.GetValue();
        }
    }
}
