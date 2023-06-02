using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Abstractions
{
    public interface IPiece
    {
        Type type { get; }
        char symbol { get;  set; }
        public abstract bool canMove(ICoordinate targetCoor);
        public abstract bool canMove(ICoordinate initialCoor, ICoordinate targetCoor);
        public ICoordinate? currentCoor { get; set; }
        public PieceColor pieceColor { get; }
        public List<AMove>? avaibleMoves { get;  set; }
    }
}
