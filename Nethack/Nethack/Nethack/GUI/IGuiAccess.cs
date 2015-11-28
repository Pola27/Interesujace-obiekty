using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethack.Core;

namespace Nethack.GUI
{
    public interface IGuiAccess
    {
        public void RenderBoard(Gameboard board, Player player);

    }
}
