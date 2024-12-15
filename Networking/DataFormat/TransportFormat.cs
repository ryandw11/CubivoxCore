using System;
using System.Collections.Generic;
using System.Text;

namespace CubivoxCore.Networking.DataFormat
{
    /// <summary>
    /// Read/Write data to the transport format.
    /// 
    /// <para>This is mainly for internal use.</para>
    /// </summary>
    public sealed class TransportFormat
    {
        private TransportFormat() { }

        /// <summary>
        /// The supported types that can be used with transports.
        /// </summary>
        public static readonly HashSet<Type> SupportedTypes = new HashSet<Type>
        {
            typeof(int)
        };

        /// <summary>
        /// The max size of data that can be sent through a transport.
        /// </summary>
        public static readonly int MaxSize = 1 * 10 ^ 6; // 1MB

        /// <summary>
        /// Writes supported objects to a byte array format used for transports.
        /// </summary>
        /// <param name="data">The data to write</param>
        /// <returns>The byte array. Will be null if unsupported types are there.</returns>
        public static byte[] WriteObjects(object[] data)
        {
            byte[] output;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                foreach (var obj in data)
                {
                    switch (obj)
                    {
                        case int i:
                            memoryStream.Write(BitConverter.GetBytes(i));
                            break;
                        default:
                            // Error: type not supported
                            return null;
                    }
                }

                output = memoryStream.ToArray();
            }

            return output;
        }

        /// <summary>
        /// Reads objects from a byte array (in the transport format) and spits out the data in object form.
        /// </summary>
        /// <param name="types">The types that make up the data (in order).</param>
        /// <param name="data">The data in byte form</param>
        /// <returns>The data in object form</returns>
        public static List<object> ReadObjects(Type[] types, byte[] data)
        {
            List<object> output = new List<object>();

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                foreach (var type in types)
                {
                    byte[] primitiveBuffer = new byte[8];

                    if (type == typeof(int))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 4) != 4)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(BitConverter.ToInt32(primitiveBuffer));
                    }
                    else
                    {
                        // Error: Unknown type
                        return null;
                    }
                }
            }

            return output;
        }
    }
}
