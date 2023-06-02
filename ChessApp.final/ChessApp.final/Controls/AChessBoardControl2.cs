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
    public abstract class AChessBoardControl2 : AChessBoardControl
    {
        public override abstract AMove generateMove(ICoordinate current, ICoordinate targetCoor);

        protected override void ChessBoardControl_Load(object sender, EventArgs e)
        {
            base.ChessBoardControl_Load(sender, e);
            onMove += (piece, targetCoordinate) =>
            {
                if (piece.currentCoor == null) throw new Exception("");
                bool tf = isMoveLegal(piece.currentCoor, targetCoordinate);
                if (tf)
                {
                    AMove m = generateMove(piece.currentCoor, targetCoordinate);
                    game.makeMove(m);
                }

                Console.WriteLine(_currentPosition.fen);

                Console.WriteLine(_currentPosition.useThisMethodJustWannaSeePositionInCode());


                return;
            };
        }

        internal override void loadPosition(Position position)
        {
            base.loadPosition(position);
            Console.WriteLine("loadPosition executed: Current Position -->");
            Console.WriteLine(_currentPosition.useThisMethodJustWannaSeePositionInCode());
            Console.WriteLine("Current Fen -->" + _currentPosition.fen);
        }
        public override List<AMove> getAlPossibleMovesForCurrentPosition()
        {
            return base.getAlPossibleMovesForCurrentPosition();
        }
        public override List<AMove> getAvaibleMoves(IPiece piece)
        {
            return base.getAvaibleMoves(piece);
        }

        public override void loadGame(IGame game)
        {
            base.loadGame(game);
            Console.WriteLine("loadGame executed: Current Position -->");
            Console.WriteLine(game.getLastPosition().useThisMethodJustWannaSeePositionInCode());
        }

        public override bool isMoveLegal(ICoordinate current, ICoordinate targetCoor)
        {
            miniChessBoard.loadPosition(_currentPosition);
            return miniChessBoard.isMoveLegal(getCell(current.x, current.y), targetCoor);
        }

    }
}
