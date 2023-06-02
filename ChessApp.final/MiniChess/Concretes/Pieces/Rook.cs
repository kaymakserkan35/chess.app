using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes.Pieces
{
    public class Rook : APiece, IRook
    {
        public Rook(ICoordinate currentCoor, PieceColor pieceColor) : base(currentCoor, pieceColor)
        {
            symbol = pieceColor == PieceColor.white ? 'R' : 'r';
        }

        public override bool canMove(ICoordinate targetCoor)
        {
            return canMove(currentCoor, targetCoor);
        }

        public override bool canMove(ICoordinate initialCoor, ICoordinate targetCoor)
        {
            if (initialCoor == null) return false;
            int deltaX, deltaY;
            deltaX = targetCoor.x - initialCoor.x;
            deltaY = targetCoor.y - initialCoor.y;
            if (deltaX * deltaY == 0) return true;
            else return false;
        }
    }
}
