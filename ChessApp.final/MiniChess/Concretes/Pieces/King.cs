using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes.Pieces
{
    public class King : APiece, IKing
    {
        public King(ICoordinate currentCoor, PieceColor pieceColor) : base(currentCoor, pieceColor)
        {
            symbol = pieceColor == PieceColor.white ? 'K' : 'k';
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

            if (pieceColor == PieceColor.white)
            {
                if (initialCoor.y == 1 && initialCoor.x == 5 && Math.Abs(difX) == 2 && difY == 0)
                {
                    return true;
                }
                if (Math.Abs(difX) <= 1 && Math.Abs(difY) <= 1) return true;

            }
            if (pieceColor == PieceColor.black)
            {
                if (initialCoor.y == 8 && initialCoor.x == 5 && Math.Abs(difX) == 2 && difY == 0)
                {
                    return true;
                }
                if (Math.Abs(difX) <= 1 && Math.Abs(difY) <= 1) return true;

            }
            return false;
        }
    }
}
