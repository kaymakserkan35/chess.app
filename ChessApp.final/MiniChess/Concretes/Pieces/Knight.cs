using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes.Pieces
{
    public class Knight : APiece, IKnight
    {
        public Knight(ICoordinate currentCoor, PieceColor pieceColor) : base(currentCoor, pieceColor)
        {
            symbol = pieceColor == PieceColor.white ? 'N' : 'n';
        }

        public override bool canMove(ICoordinate targetCoor)
        {
            return canMove(currentCoor, targetCoor);
        }

        public override bool canMove(ICoordinate initialCoor, ICoordinate targetCoor)
        {
            if (initialCoor == null) return false;
            int difX = initialCoor.x - targetCoor.x;
            int difY = initialCoor.y - targetCoor.y;
            difX = Math.Abs(difX);
            difY = Math.Abs(difY);

            if (difX * difY == 2) return true;
            else return false;
        }
    }
}
