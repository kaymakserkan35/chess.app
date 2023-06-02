using ChessApp.final.MiniChess.Concretes;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using MiniChess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Abstractions
{
    public interface IGame
    {
        public Result result { get; internal set; }
        string getAllLines();
        void makeMove(AMove move);

        IPlayer playerWhite { get; }
        IPlayer playerBlack { get; }
        public void back(IChessBoard chessBoard);
        public void next(IChessBoard chessBoard);
        public void backBack(IChessBoard chessBoard);
        public void nextNext(IChessBoard chessBoard);
        public Position getLastPosition();
    }
}
