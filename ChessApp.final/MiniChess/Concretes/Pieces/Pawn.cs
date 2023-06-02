using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes.Pieces
{
    public class Pawn : APiece, IPawn
    {
        public Pawn(ICoordinate currentCoor, PieceColor pieceColor) : base(currentCoor, pieceColor)
        {
            symbol = pieceColor == PieceColor.white ? 'P' : 'p';
        }


        public override bool canMove(ICoordinate targetCoor)
        {
            if(currentCoor==null) return false;
            return canMove(currentCoor, targetCoor);
        }

        public override bool canMove(ICoordinate initialCoor, ICoordinate targetCoor)
        {
            if (initialCoor == null) return false;

            if (type == typeof(IPawn))
            {
                int deltaX, deltaY;
                deltaX = targetCoor.x - initialCoor.x;
                deltaY = targetCoor.y - initialCoor.y;

                if (pieceColor == PieceColor.white)
                {
                    if (deltaX == 0)
                    {
                        if (deltaY == 1) return true;
                        if (initialCoor.y == 2 && deltaY == 2) return true;
                    }
                    if (Math.Abs(deltaX) == 1 && deltaY == 1) return true;

                }
                if (pieceColor == PieceColor.black)
                {
                    if (deltaX == 0)
                    {
                        if (deltaY == -1) return true;
                        if (initialCoor.y == 7 && deltaY == -2) return true;
                    }
                    if (Math.Abs(deltaX) == 1 && deltaY == -1) return true;
                }
                return false;
            }
            else if (type == typeof(IRook))
            {
                int deltaX, deltaY;
                deltaX = targetCoor.x - initialCoor.x;
                deltaY = targetCoor.y - initialCoor.y;
                if (deltaX * deltaY == 0) return true;
                else return false;
            }
            else if (type == typeof(IKnight))
            {
                int difX = currentCoor.x - targetCoor.x;
                int difY = currentCoor.y - targetCoor.y;
                difX = Math.Abs(difX);
                difY = Math.Abs(difY);

                if (difX * difY == 2) return true;
                else return false;
            }
            else if (type == typeof(IBishop))
            {
                int difX = targetCoor.x - currentCoor.x;
                int difY = targetCoor.y - currentCoor.y;

                difX = Math.Abs(difX);
                difY = Math.Abs(difY);
                if (difX == difY) return true;
                else return false;
            }
            else if (type == typeof(IQueen))
            {
                int difX = targetCoor.x - currentCoor.x;
                int difY = targetCoor.y - currentCoor.y;

                bool asRook = difX * difY == 0 ? true : false;
                bool asBishop = Math.Abs(difX) == Math.Abs(difY) ? true : false;

                if (asRook || asBishop) return true;
                else return false;
            }
            else throw new Exception("piece type is incorrect!");
        }

        public void dePromote()
        {
            if (type == typeof(IPawn)) return;
            type = typeof(IPawn);
            symbol = pieceColor == PieceColor.white ? 'P' : 'p';
        }

        public void promote<T>() where T : IPiece
        {
            // if (type != typeof(IPawn)) throw new Exception("");
            type = typeof(T);
            if (type == typeof(IQueen)) { symbol = pieceColor == PieceColor.white ? 'Q' : 'q'; return; }
            if (type == typeof(IRook)) { symbol = pieceColor == PieceColor.white ? 'R' : 'r'; return; }
            if (type == typeof(IBishop)) { symbol = pieceColor == PieceColor.white ? 'B' : 'b'; return; }
            if (type == typeof(IKnight)) { symbol = pieceColor == PieceColor.white ? 'N' : 'n'; return; }
            else  new Exception("");
        }
    }
}
