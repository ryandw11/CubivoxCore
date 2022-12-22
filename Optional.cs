using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore
{
    public struct Optional<T>
    {
        private T instance;

        private Optional(T value)
        {
            this.instance = value;
        }

        public bool HasValue()
        {
            return instance != null;
        }

        public T Get()
        {
            if (instance == null)
            {
                throw new NullReferenceException("Value is not present.");
            }
            return instance;
        }

        public static Optional<E> Of<E>(E value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("value", "Provided value is null. Use OfNullable instead.");
            }
            return new Optional<E>(value);
        }

        public static Optional<E> OfNullable<E>(E value)
        {
            return new Optional<E>(value);
        }

        public static Optional<E> Empty<E>()
        {
            return new Optional<E>();
        }
    }
}
