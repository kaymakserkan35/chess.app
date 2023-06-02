using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.Controls
{
    public class ChessBoardControl : AChessBoardControl2
    {

        protected bool legalMoveForKnight(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.type != typeof(IKnight)) throw new Exception();
            if (!piece.canMove(targetCoor)) return false;

            IPiece? p = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (p != null && p.pieceColor == piece.pieceColor) return false;
            return true;
        }
        protected bool legalMoveForRook(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IRook) && piece.type != typeof(IQueen)) throw new Exception();
            if (!piece.canMove(targetCoor)) return false;
            IPiece? targetPiece = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (targetPiece != null && piece.pieceColor == targetPiece.pieceColor) return false;
            if (piece.currentCoor.x == targetCoor.x)
            {
                int x = piece.currentCoor.x;
                int y = piece.currentCoor.y;

                while (y != targetCoor.y)
                {

                    IPiece? p = getCell(x, y).getPiece();
                    if (p != piece && p != null) return false;
                    if (piece.currentCoor.y > targetCoor.y) y--;
                    else y++;
                }
            }
            if (piece.currentCoor.y == targetCoor.y)
            {
                int y = piece.currentCoor.y;
                int x = piece.currentCoor.x;

                while (x != targetCoor.x)
                {

                    IPiece? p = getCell(x, y).getPiece();
                    if (p != piece && p != null) return false;
                    if (piece.currentCoor.x > targetCoor.x) x--;
                    else x++;

                }

            }
            return true;
        }
        protected bool legalMoveForKing(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IKing)) throw new Exception();
            IPiece? targetPiece = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (targetPiece != null && piece.pieceColor == targetPiece.pieceColor) return false;
            int y = piece.currentCoor.y;
            int x = piece.currentCoor.x;
            if (Math.Abs(piece.currentCoor.x - targetCoor.x) == 2)
            {
                if (x < targetCoor.x)
                {
                    if (piece.pieceColor == PieceColor.white && !_currentPosition.ooForWhite) return false;
                    if (piece.pieceColor == PieceColor.black && !_currentPosition.ooForBlack) return false;

                }
                else
                {
                    if (piece.pieceColor == PieceColor.white && !_currentPosition.oooForWhite) return false;
                    if (piece.pieceColor == PieceColor.black && !_currentPosition.oooForBlack) return false;
                }
                if (getCell(targetCoor.x, targetCoor.y).getPiece() != null) return false;
                if (piece.pieceColor == PieceColor.white && blackPieces.Any(p => checkMoveIsLegal(p, getCell(piece.currentCoor.x, y)))) return false;
                if (piece.pieceColor == PieceColor.black && whitePieces.Any(p => checkMoveIsLegal(p, getCell(piece.currentCoor.x, y)))) return false;

                while (x != targetCoor.x)
                {
                    if (piece.pieceColor == PieceColor.white)
                    {
                        if (blackPieces.Any(p => checkMoveIsLegal(p, getCell(x, y)))) return false;
                    }
                    if (piece.pieceColor == PieceColor.black)
                    {
                        if (whitePieces.Any(p => checkMoveIsLegal(p, getCell(x, y)))) return false;
                    }

                    IPiece? p = getCell(x, y).getPiece();
                    if (p != piece && p != null) return false;

                    if (piece.currentCoor.x > targetCoor.x) x--;
                    else x++;
                }



            }





            return true;
        }
        protected bool legalMoveForBishop(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IBishop) && piece.type != typeof(IQueen)) throw new Exception();
            IPiece? targetPiece = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (targetPiece != null && targetPiece.pieceColor == piece.pieceColor) return false;

            int x = piece.currentCoor.x;
            int y = piece.currentCoor.y;

            while (x != targetCoor.x)
            {
                IPiece? p = getCell(x, y).getPiece();
                if (p != piece && p != null) return false;

                if (piece.currentCoor.x > targetCoor.x) x--;
                else x++;
                if (piece.currentCoor.y > targetCoor.y) y--;
                else y++;

            }

            return true;
        }
        protected bool legalMoveForQuuen(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.currentCoor.x == targetCoor.x || piece.currentCoor.y == targetCoor.y)
                return legalMoveForRook(piece, targetCoor);
            else return legalMoveForBishop(piece, targetCoor);

        }
        protected bool legalMoveForPawn(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IPawn)) throw new Exception();
            if (piece.currentCoor.x == targetCoor.x)
            {
                int y = piece.currentCoor.y;
                while (y != targetCoor.y)
                {
                    if (y > targetCoor.y) y--; else y++;
                    IPiece? p = getCell(piece.currentCoor.x, y).getPiece();
                    if (p != null) return false;
                }
            }
            else
            {
                IPiece? p = getCell(targetCoor.x, targetCoor.y).getPiece();
                if (p != null && piece.pieceColor == p.pieceColor) return false;
                if (p != null && piece.pieceColor != p.pieceColor) return true;
                if (p == null)
                {
                    if (_currentPosition.enpassent == null) return false;
                    else
                    {
                        int[] xy = CoorExtensions.get(_currentPosition.enpassent);
                        ICoordinate coor = getCell(xy[0], xy[1]);
                        if (coor.x != targetCoor.x) return false;
                        if (piece.pieceColor == PieceColor.white && targetCoor.y - 1 != coor.y) return false;
                        if (piece.pieceColor == PieceColor.black && targetCoor.y + 1 != coor.y) return false;

                    }
                }
            }
            return true;

        }
        protected bool checkMoveIsLegal(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == targetCoor) return false;
            if (!piece.canMove(targetCoor)) return false;
            if (piece.type == typeof(IPawn)) return legalMoveForPawn(piece, targetCoor);
            if (piece.type == typeof(IRook)) return legalMoveForRook(piece, targetCoor);
            if (piece.type == typeof(IBishop)) return legalMoveForBishop(piece, targetCoor);
            if (piece.type == typeof(IQueen)) return legalMoveForQuuen(piece, targetCoor);
            if (piece.type == typeof(IKnight)) return legalMoveForKnight(piece, targetCoor);
            if (piece.type == typeof(IKing)) return legalMoveForKing(piece, targetCoor);
            throw new Exception("");
        }
        public override AMove generateMove(ICoordinate current, ICoordinate targetCoor)
        {
            AMove move;
            IPiece? piece = getCell(current.x, current.y).getPiece();
            if (piece == null) { throw new Exception(""); }
            IPiece? targetPiece = getTargetPiece(piece, targetCoor);
            if (piece is IPawn && piece.type == typeof(IPawn) && (targetCoor.y == 1 || targetCoor.y == 8))
            {
                move = new PromotionMove<IQueen>((IPawn)piece, targetCoor, targetPiece);
            }

            else if (targetPiece != null && targetPiece.pieceColor == piece.pieceColor)
            {
                move = new CastlingMove(piece, targetCoor, targetPiece);
            }
            else move = new SimpleMove(piece, targetCoor, targetPiece);

            {


                if (piece.pieceColor == PieceColor.white)
                {// check for ambigous piece
                    IPiece? p = whitePieces.FirstOrDefault(p => checkMoveIsLegal(p, targetCoor));
                    if (p != null && p != piece && p.type == piece.type)
                    {
                        if (p.currentCoor.x != piece.currentCoor.x)
                        {
                            if (piece is IPawn) move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                            else move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                        }
                        else
                        {
                            move.moveSymbol = piece.currentCoor.y.ToString() + move.moveSymbol;
                        }

                    }
                    /* IPiece king = blackPieces.First(p => p is IKing);
                       if (whitePieces.Any(x => checkMoveIsLegal(x, king.currentCoor))) { move.moveSymbol += "+"; }
                      */

                }

                if (piece.pieceColor == PieceColor.black)
                {// check for ambigous piece
                    IPiece? p = blackPieces.FirstOrDefault(p => checkMoveIsLegal(p, targetCoor));
                    if (p != null && p != piece && p.type == piece.type)// check for ambigous piece
                    {
                        if (p.currentCoor.x != piece.currentCoor.x)
                        {
                            if (piece is IPawn) move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                            else move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                        }
                        else
                        {
                            move.moveSymbol = piece.currentCoor.y.ToString() + move.moveSymbol;
                        }
                    }
                    /*
                     IPiece king = whitePieces.First(p => p is IKing);
                     if (blackPieces.Any(x => checkMoveIsLegal(x, king.currentCoor))) { move.moveSymbol += "+"; }
                     */

                }


            }
            return move;
        }

        public override bool isMoveLegal(ICoordinate current, ICoordinate targetCoor)
        {
            return base.isMoveLegal(current, targetCoor);


        }

        protected override void ChessBoardControl_Load(object sender, EventArgs e)
        {
            base.ChessBoardControl_Load(sender, e);
            

        }
    }
}

