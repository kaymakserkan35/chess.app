using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;

namespace ChessApp.final.MiniChess.Concretes.MoveTypes
{
    public class PromotionMove<T> : AMove where T : IPiece
    {
        Type typePromoted;
        public PromotionMove(IPawn piece, ICoordinate targetCoor, IPiece? targetPiece) : base(piece, targetCoor, targetPiece)
        {
            if (piece.type != typeof(IPawn)) throw new Exception("");
            typePromoted = typeof(T);

            if (targetPiece != null) moveSymbol += "x";
            moveSymbol += targetCoor.notation;
            Type type = typeof(T);
            if (type == typeof(IQueen)) { moveSymbol += "=Q"; }
            else if (type == typeof(IRook)) { moveSymbol += "=R"; }
            else if (type == typeof(IBishop)) { moveSymbol += "=B"; }
            else if (type == typeof(IKnight)) { moveSymbol += "=N"; }
            else throw new Exception("");

        }
        public override void execute(IChessBoard chessBoard)
        {
            chessBoard.getCell(pieceCoorX0, pieceCoorY0).removePiece();
            if (_targetPiece != null)
            {
                chessBoard.getCell(targetPieceX, targetPieceY).removePiece();
                _targetPiece.currentCoor = null;
            }

            ((IPawn)_piece).promote<T>();
            ICell cell = chessBoard.getCell(pieceCoorX1, pieceCoorY1);
            cell.addPiece(_piece); _piece.currentCoor = cell;

            /*-------------------------------------------------------------*/
            string fen = chessBoard.getPositionInFenFromBoard();
            _positionAfterMoveExecuted = chessBoard.currentPosition.copyInShallowForNextPosition(fen);
            chessBoard.currentPosition.nextPosition = _positionAfterMoveExecuted;
            _positionAfterMoveExecuted.previousPosition = chessBoard.currentPosition;

        }
        public override void getBackMove(IChessBoard chessBoard)
        {
            ((IPawn)_piece).dePromote();
            chessBoard.getCell(pieceCoorX1, pieceCoorY1).removePiece();

            if (_targetPiece != null)
            {
                ICell c = chessBoard.getCell(targetPieceX, targetPieceY);
                c.addPiece(_targetPiece); _targetPiece.currentCoor = c;
            }

            ICell cell = chessBoard.getCell(pieceCoorX0, pieceCoorY0);
            cell.addPiece(_piece); _piece.currentCoor = cell;





        }
    }
}
