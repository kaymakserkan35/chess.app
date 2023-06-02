using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes.MoveTypes
{
    public class CastlingMove : AMove
    {
        private int rookNewX, rookNewY;

        public CastlingMove(IPiece king, ICoordinate targetCoor, IPiece rook) : base(king, targetCoor, rook)
        {
            if (!(king is IKing) || !(rook.type == typeof(IRook))) throw new ArgumentException("");
            if (rook == null) throw new ArgumentNullException("");
            if (rook.currentCoor == null) throw new Exception("");
            if (pieceCoorX1 == 7) { rookNewX = pieceCoorX1 - 1; rookNewY = pieceCoorY1; moveSymbol = "0-0"; }
            if (pieceCoorX1 == 3) { rookNewX = pieceCoorX1 + 1; rookNewY = pieceCoorY1; moveSymbol = "0-0-0"; }

        }

        public override void execute(IChessBoard chessBoard)
        {
            chessBoard.getCell(pieceCoorX0, pieceCoorY0).removePiece();
            ICell cell = chessBoard.getCell(pieceCoorX1, pieceCoorY1);
            cell.addPiece(_piece); _piece.currentCoor = cell;


            chessBoard.getCell(targetPieceX, targetPieceY).removePiece();
            ICell cellForRook = chessBoard.getCell(rookNewX, rookNewY);
            cellForRook.addPiece(_targetPiece);
            _targetPiece.currentCoor = cellForRook;
            moveSymbol = "0-0";

            /*-----------------------SET POSİTİON-----------------------*/
            string fen = chessBoard.getPositionInFenFromBoard();
            _positionAfterMoveExecuted = chessBoard.currentPosition.copyInShallowForNextPosition(fen);

            if (_piece.pieceColor == PieceColor.white) { _positionAfterMoveExecuted.ooForWhite = false; _positionAfterMoveExecuted.oooForWhite = false; }
            else { _positionAfterMoveExecuted.ooForBlack = false; _positionAfterMoveExecuted.oooForBlack = false; }

            chessBoard.currentPosition.nextPosition = _positionAfterMoveExecuted;
            _positionAfterMoveExecuted.previousPosition = chessBoard.currentPosition;

        }

        public override void getBackMove(IChessBoard chessBoard)
        {
            chessBoard.getCell(pieceCoorX1, pieceCoorY1).removePiece();
            ICell cell = chessBoard.getCell(pieceCoorX0, pieceCoorY0);
            _piece.currentCoor = cell;
            cell.addPiece(_piece);


            {
                chessBoard.getCell(rookNewX, rookNewY).removePiece();
                ICell cellForRook = chessBoard.getCell(targetPieceX, targetPieceY);
                cellForRook.addPiece(_targetPiece); _targetPiece.currentCoor = cellForRook;
                return;
            }

        }
    }
}
