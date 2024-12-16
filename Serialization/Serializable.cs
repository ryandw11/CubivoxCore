using System;
using System.Collections.Generic;
using System.Text;

namespace CubivoxCore.Serialization
{
    public interface Serializable
    {
        public byte[] Serialize();
        public void Deserialize(byte[] data);
    }
}
