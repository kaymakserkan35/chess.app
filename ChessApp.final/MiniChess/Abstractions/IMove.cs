using ChessApp.final.MiniChess.Concretes.MoveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Abstractions
{
    public interface IMove
    {
        AMove previous { get; internal set; }
        AMove next { get; internal set; }
        List<AMove> variants { get; }
        IPiece piece { get; }
        IPiece? targetPiece { get; }
        IPosition positionAfterMoveExecuted { get; }
        string moveSymbol { get; }

        abstract void execute(IChessBoard chessBoard);
        abstract void getBackMove(IChessBoard chessBoard);
    }
}
