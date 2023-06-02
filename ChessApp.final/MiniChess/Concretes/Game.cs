using ChessApp.final.MiniChess.Abstractions;
using MiniChess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessApp.final.MiniChess.Concretes.MoveTypes.AMove;

namespace ChessApp.final.MiniChess.Concretes
{
    public class Game : AGame
    {
       
        public Game(IChessBoard chessBoard, Player? playerWhite, Player? playerBlack) : base(chessBoard, playerWhite, playerBlack)
        {
            lastExecutedMove = new EmtyMove();
        }
        public Game(string fenPosition,IChessBoard chessBoard, Player? playerWhite, Player? playerBlack) : base(chessBoard, playerWhite, playerBlack)
        {
            lastExecutedMove = new EmtyMove(fenPosition);
        }
    }
}
