using ChessApp.final.MiniChess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes
{
    public class Cell : ICell
    {
       
        private IPiece? piece;
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            notation = CoorExtensions.get(x, y); 
        }

        public int x { get; }
        public int y { get; }

        public string notation { get; protected set; }

        public void addPiece(IPiece piece)
        {
            this.piece = piece;
        }

        public IPiece? getPiece()
        {
            if (piece != null) return piece;
            return null;
        }

        public void removePiece()
        {
            piece = null;
        }
    }
}
