using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes.Pieces
{
    public class Queen : APiece, IQueen
    {
        public Queen(ICoordinate currentCoor, PieceColor pieceColor) : base(currentCoor, pieceColor)
        {
            symbol = pieceColor == PieceColor.white ? 'Q' : 'q';
        }

        public override bool canMove(ICoordinate targetCoor)
        {
            return canMove(currentCoor, targetCoor);
        }

        public override bool canMove(ICoordinate initialCoor, ICoordinate targetCoor)
        {
            if (initialCoor == null) return false;
            int difX = targetCoor.x - initialCoor.x;
            int difY = targetCoor.y - initialCoor.y;

            bool asRook = difX * difY == 0 ? true : false;
            bool asBishop = Math.Abs(difX) == Math.Abs(difY) ? true : false;

            if (asRook || asBishop) return true;
            else return false;
        }
    }
}
