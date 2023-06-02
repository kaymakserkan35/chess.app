using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.Controls.Pieces
{
    internal class PawnControl : PieceControl, IPawn
    {
        public PawnControl(ICoordinate current, PieceColor color) : base(current, color)
        {
            this.piece = new Pawn(current, color);
            if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whitePawn);
            else Image = new Bitmap(ChessPieces.blackPawn);
        }

        public void dePromote()
        {
            ((IPromotable)piece).dePromote();
            if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whitePawn);
            else Image = new Bitmap(ChessPieces.blackPawn);
        }

        public void promote<T>() where T : IPiece
        {
            ((IPromotable)piece).promote<T>();
            if (type == typeof(IQueen))
            {
                if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteQuuen);
                else Image = new Bitmap(ChessPieces.blackQuuen);
            }
            else if (type == typeof(IRook))
            {
                if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteRook);
                else Image = new Bitmap(ChessPieces.blackRook);
            }
            else if (type == typeof(IBishop))
            {
                if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteBishop);
                else Image = new Bitmap(ChessPieces.blackBishop);
            }
            else if (type == typeof(IKnight))
            {
                if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteKnight);
                else Image = new Bitmap(ChessPieces.blackKnight);
            }
            else throw new Exception("");

        }
    }
    internal class BishopControl : PieceControl, IBishop
    {
        public BishopControl(ICoordinate current, PieceColor color) : base(current, color)
        {
            piece = new Bishop(current, color);
            if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteBishop);
            else Image = new Bitmap(ChessPieces.blackBishop);
        }
    }
    internal class KingControl : PieceControl, IKing
    {
        public KingControl(ICoordinate current, PieceColor color) : base(current, color)
        {
            piece = new King(current, color);
            if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteKing);
            else Image = new Bitmap(ChessPieces.blackKing);
        }
    }
    internal class KnightControl : PieceControl, IKnight
    {
        public KnightControl(ICoordinate current, PieceColor color) : base(current, color)
        {
            piece = new Knight(current, color);
            if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteKnight);
            else Image = new Bitmap(ChessPieces.blackKnight);
        }
    }
    internal class QueenControl : PieceControl, IQueen
    {
        public QueenControl(ICoordinate current, PieceColor color) : base(current, color)
        {
            piece = new Queen(current, color);
            if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteQuuen);
            else Image = new Bitmap(ChessPieces.blackQuuen);
        }
    }
    internal class RookControl : PieceControl, IRook
    {
        public RookControl(ICoordinate current, PieceColor color) : base(current, color)
        {
            piece = new Rook(current, color);
            if (pieceColor == PieceColor.white) this.Image = new Bitmap(ChessPieces.whiteRook);
            else Image = new Bitmap(ChessPieces.blackRook);
        }
    }
}
