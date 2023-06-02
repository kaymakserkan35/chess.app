using ChessApp.final.MiniChess.Concretes;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChessApp.final.MiniChess.Abstractions
{
    public interface IChessBoard
    {
        public Position currentPosition { get; set; }
        public void loadGame(IGame game);
        public string getPositionInFenFromBoard();
        public List<AMove> getAvaibleMoves(IPiece piece);
        public List<AMove> getAlPossibleMovesForCurrentPosition();
        public bool isMoveLegal(ICoordinate current, ICoordinate targetCoor);
        public ICell getCell(int x, int y);
        public IPiece? getTargetPiece(IPiece piece, ICoordinate targetCoor);

    }
}
