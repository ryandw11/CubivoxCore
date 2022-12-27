using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubivoxCore.BaseGame
{
    public interface Entity : Identifiable
    {
        string GetModel();
        string GetTexture();
    }
}
