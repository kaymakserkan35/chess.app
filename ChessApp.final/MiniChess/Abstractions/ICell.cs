using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Abstractions
{
    public interface ICell : ICoordinate
    {
        //IPiece? piece { get; set; } 
        public void addPiece(IPiece piece);
        public void removePiece();
        public IPiece? getPiece();
    }
}
