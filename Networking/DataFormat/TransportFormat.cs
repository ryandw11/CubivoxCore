using CubivoxCore.Exceptions;
using CubivoxCore.Players;
using System;
using System.Collections.Generic;
using System.IO;
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
            // Primitives (non-nullable)
            typeof(bool),
            typeof(byte),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(float),
            typeof(double),

            // Objects (nullable)
            typeof(string),
            typeof(Player),
            typeof(Location)
        };

        /// <summary>
        /// The max size of data that can be sent through a transport.
        /// </summary>
        public static readonly long MaxSize = 1 * (long) Math.Pow(10, 6); // 1MB

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
                        // Primitives
                        case bool b:
                            memoryStream.Write(BitConverter.GetBytes(b));
                            break;
                        case byte b:
                            memoryStream.WriteByte(b);
                            break;
                        case short s:
                            memoryStream.Write(BitConverter.GetBytes(s));
                            break;
                        case int i:
                            memoryStream.Write(BitConverter.GetBytes(i));
                            break;
                        case long l:
                            memoryStream.Write(BitConverter.GetBytes(l));
                            break;
                        case float f:
                            memoryStream.Write(BitConverter.GetBytes(f));
                            break;
                        case double d:
                            memoryStream.Write(BitConverter.GetBytes(d));
                            break;

                        // Objects
                        case string str:
                            {
                                // (1 byte) - (2 bytes) - (str data)
                                byte engaged = (byte)(str == null ? 0 : 1);
                                memoryStream.WriteByte(engaged);
                                if (str != null)
                                {
                                    ushort strSize = (ushort)str.Length;
                                    memoryStream.Write(BitConverter.GetBytes(strSize));
                                    var strData = Encoding.UTF8.GetBytes(str);
                                    memoryStream.Write(strData);
                                }
                            }
                            break;
                        case Player p:
                            {
                                byte engaged = (byte)(p == null ? 0 : 1);
                                memoryStream.WriteByte(engaged);
                                if( p != null )
                                {
                                    byte[] guidData = p.GetUUID().ToByteArray();
                                    memoryStream.Write(guidData);
                                }
                            }
                            break;

                        case Location l:
                            {
                                byte engaged = (byte)(l == null ? 0 : 1);
                                memoryStream.WriteByte(engaged);
                                if (l != null)
                                {
                                    memoryStream.Write(l.Serialize());
                                }
                            }
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

                    // Primitives
                    if (type == typeof(bool))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 1) != 1)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(BitConverter.ToBoolean(primitiveBuffer));
                    }
                    else if (type == typeof(byte))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 1) != 1)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(primitiveBuffer[0]);
                    }
                    else if (type == typeof(short))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 2) != 2)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(BitConverter.ToInt16(primitiveBuffer));
                    }
                    else if (type == typeof(int))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 4) != 4)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(BitConverter.ToInt32(primitiveBuffer));
                    }
                    else if (type == typeof(long))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 8) != 8)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(BitConverter.ToInt64(primitiveBuffer));
                    }
                    else if (type == typeof(float))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 4) != 4)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(BitConverter.ToSingle(primitiveBuffer));
                    }
                    else if (type == typeof(double))
                    {
                        if (memoryStream.Read(primitiveBuffer, 0, 8) != 8)
                        {
                            // End of stream
                            return null;
                        }
                        output.Add(BitConverter.ToDouble(primitiveBuffer));
                    }

                    // Objects
                    else if (type == typeof(string))
                    {
                        bool engaged = memoryStream.ReadByte() == 0 ? false : true;
                        if( !engaged )
                        {
                            output.Add(null);
                        }
                        else
                        {
                            ushort strLength = 0;
                            if( memoryStream.Read(primitiveBuffer, 0, 2) != 2 )
                            {
                                return null;
                            }

                            strLength = BitConverter.ToUInt16(primitiveBuffer);
                            byte[] strData = new byte[strLength];
                            if( memoryStream.Read(strData, 0, strLength) != strLength )
                            {
                                return null;
                            }

                            string str = Encoding.UTF8.GetString(strData);
                            output.Add(str);
                        }
                    }
                    else if (type == typeof(Player))
                    {
                        bool engaged = memoryStream.ReadByte() == 0 ? false : true;
                        if (!engaged)
                        {
                            output.Add(null);
                        }
                        else
                        {
                            byte[] uuid = new byte[16];
                            if( memoryStream.Read(uuid, 0, 16) != 16 )
                            {
                                return null;
                            }
                            Guid guid = new Guid(uuid);
                            output.Add(Cubivox.GetPlayerByUuid(guid));
                        }
                    }
                    else if (type == typeof(Location))
                    {
                        bool engaged = memoryStream.ReadByte() == 0 ? false : true;
                        if (!engaged)
                        {
                            output.Add(null);
                        }
                        else
                        {
                            byte[] locData = new byte[32];
                            if (memoryStream.Read(locData, 0, 32) != 32 )
                            {
                                return null;
                            }
                            output.Add(new Location(locData));
                        }
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

        /// <summary>
        /// Assert that the objects provided in an assert match the types that are expected.
        /// This will also modify the data so that way to type matches what is expected.
        /// This is needed for primitives that convert to and from each other.
        /// </summary>
        /// <param name="types">The expected types (including Player for ServerTransports)</param>
        /// <param name="data">The provided data.</param>
        /// <param name="isServerTransport">If checking a server transport delegate.</param>
        /// <exception cref="ArgumentException">If an issue is found with the provided parameters.</exception>
        public static void AssertTypeMatch(Type[] types, object[] data, bool isServerTransport)
        {
            int typeOffset = 0;
            if( isServerTransport )
            {
                if( types.Length - 1 != data.Length )
                {
                    throw new ArgumentException("Invalid number of parameters.");
                }
                typeOffset = 1;
            }
            else
            {
                if( types.Length != data.Length )
                {
                    throw new ArgumentException("Invalid number of parameters.");
                }
            }

            for( int i = 0; i < data.Length; ++i )
            {
                Type dataType = data[i].GetType();
                Type expectedType = types[i + typeOffset];

                if ((!expectedType.IsAssignableFrom(dataType) || dataType == typeof(object)) && 
                     !CanConvertPrimitive(dataType, expectedType))
                {
                    throw new ArgumentException($"Provided object at index {i} with name {dataType.Name} does not match the expected type {expectedType.Name}.");
                }
                else
                {
                    // Perform a conversion to what is expected.
                    if (expectedType.IsPrimitive)
                    {
                        data[i] = Convert.ChangeType(data[i], expectedType);
                    }
                }
            }
        }

        /// <summary>
        /// Assert that a delegate only has supported types.
        /// </summary>
        /// <param name="types">The parameter types for a delegate.</param>
        /// <exception cref="InvalidTransportTypeException">If there is an invalid type.</exception>
        public static void AssertSupportedTypes(Type[] types)
        {
            foreach( Type type in types )
            {
                if( !SupportedTypes.Contains(type) )
                {
                    throw new InvalidTransportTypeException($"Type {type.Name} is not supported for transports!");
                }
            }
        }

        private static bool CanConvertPrimitive(Type fromType, Type toType)
        {
            TypeCode fromCode = Type.GetTypeCode(fromType);
            TypeCode toCode = Type.GetTypeCode(toType);

            return IsNumericType(fromCode) && IsNumericType(toCode);
        }

        private static bool IsNumericType(TypeCode typeCode)
        {
            return typeCode == TypeCode.Byte || typeCode == TypeCode.Int16 || typeCode == TypeCode.Int32 ||
                   typeCode == TypeCode.Int64 || typeCode == TypeCode.Single || typeCode == TypeCode.Double;
        }
    }
}
