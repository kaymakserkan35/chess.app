using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Abstractions.Pieces
{

    public enum PieceColor
    {
        white, black
    }

    public interface IPromotable
    {

        void promote<T>() where T : IPiece;
        void dePromote();
    }

    public interface IPawn : IPiece, IPromotable
    {

    }
    public interface IRook : IPiece
    {
    }
    public interface IKnight : IPiece
    {
    }
    public interface IBishop : IPiece
    {
    }
    public interface IQueen : IPiece
    {
    }
    public interface IKing : IPiece
    {
    }
}
