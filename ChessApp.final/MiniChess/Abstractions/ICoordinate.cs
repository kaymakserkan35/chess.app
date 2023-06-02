using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Abstractions
{
    public interface ICoordinate
    {
        public string notation { get; }
        int x { get; }
        int y { get; }
       
    }
}
