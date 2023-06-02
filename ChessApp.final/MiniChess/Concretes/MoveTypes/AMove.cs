using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes.MoveTypes
{
    public abstract class AMove : IMove
    {
        public AMove() { variants = new List<AMove>(); }
        public IPosition positionAfterMoveExecuted => _positionAfterMoveExecuted;
        IPiece IMove.piece { get { return _piece; } }
        IPiece? IMove.targetPiece => _targetPiece;
        protected IPiece _piece;
        protected IPiece? _targetPiece;
        protected int targetPieceX, targetPieceY;
        public int pieceCoorX0;
        public int pieceCoorX1;
        public int pieceCoorY0;
        public int pieceCoorY1;
        internal Position _positionAfterMoveExecuted;

        internal AMove(IPiece piece, ICoordinate targetCoor, IPiece? targetPiece)
        {
            if (piece.currentCoor == null) throw new Exception("");
            variants = new List<AMove>();
            _piece = piece;
            pieceCoorX0 = piece.currentCoor.x;
            pieceCoorX1 = targetCoor.x;
            pieceCoorY0 = piece.currentCoor.y;
            pieceCoorY1 = targetCoor.y;
            if (targetPiece != null)
            {
                if (targetPiece.currentCoor == null) throw new Exception("");
                _targetPiece = targetPiece;
                targetPieceX = targetPiece.currentCoor.x;
                targetPieceY = targetPiece.currentCoor.y;
            }
            else
            {
                targetPieceX = pieceCoorX1;
                targetPieceY = pieceCoorY1;
            }

        }

        public AMove previous { get; set; }

        public AMove next { get; set; }

        public List<AMove> variants { get; }

        public string moveSymbol { get; set; }



        private void setcastleRights(Position positionForWhiteOrBlack)
        {


            bool oooCastlForWhite = positionForWhiteOrBlack.oooForWhite;
            bool oooCastlForBlack = positionForWhiteOrBlack.oooForBlack;
            bool oocastleForWhite = positionForWhiteOrBlack.ooForWhite;
            bool oocastleForWBlack = positionForWhiteOrBlack.ooForBlack;

            if (oooCastlForWhite || oocastleForWhite)
            {
                if (_piece.type == typeof(IKing) && _piece.pieceColor == PieceColor.white)
                {
                    positionForWhiteOrBlack.ooForWhite = false;
                    positionForWhiteOrBlack.oooForWhite = false;
                }

            }
            if (oooCastlForBlack || oocastleForWBlack)
            {
                if (_piece.type == typeof(IKing) && _piece.pieceColor == PieceColor.black)
                {
                    positionForWhiteOrBlack.ooForBlack = false;
                    positionForWhiteOrBlack.oooForBlack = false;
                }

            }
            if (positionForWhiteOrBlack.ooForWhite) positionForWhiteOrBlack.ooForWhite = _piece is IRook && pieceCoorX0 == 8 && pieceCoorY0 == 1 ? false : true;
            if (positionForWhiteOrBlack.oooForWhite) positionForWhiteOrBlack.oooForWhite = _piece is IRook && pieceCoorX0 == 1 && pieceCoorY0 == 1 ? false : true;
            if (positionForWhiteOrBlack.ooForBlack) positionForWhiteOrBlack.ooForBlack = _piece is IRook && pieceCoorX0 == 8 && pieceCoorY0 == 8 ? false : true;
            if (positionForWhiteOrBlack.oooForBlack) positionForWhiteOrBlack.oooForBlack = _piece is IRook && pieceCoorX0 == 1 && pieceCoorY0 == 8 ? false : true;

        }

        /// <summary>
        /// hamle ile satranc tahtası degistirilir. olusan position bu nesne icine kayıt edilir. ve position.next, position.previous bağlantıları yapılır.
        /// </summary>
        /// <param name="chessBoard"></param>
        public virtual void execute(IChessBoard chessBoard)
        {

            if (_targetPiece != null) { chessBoard.getCell(targetPieceX, targetPieceY).removePiece(); _targetPiece.currentCoor = null; }
            chessBoard.getCell(pieceCoorX0, pieceCoorY0).removePiece();
            ICell cell = chessBoard.getCell(pieceCoorX1, pieceCoorY1);
            cell.addPiece(_piece);
            _piece.currentCoor = cell;
            /*-------------------------------------------------*/
            string fen = chessBoard.getPositionInFenFromBoard();
            _positionAfterMoveExecuted = chessBoard.currentPosition.copyInShallowForNextPosition(fen);
            if (_piece is IKing || _piece is IRook) setcastleRights(_positionAfterMoveExecuted);

            if (_piece is IPawn && Math.Abs(pieceCoorY1 - pieceCoorY0) == 2)
            {
                _positionAfterMoveExecuted.enpassent = (_piece.pieceColor == PieceColor.white) ? CoorExtensions.get(pieceCoorX1, pieceCoorY1 - 1) : CoorExtensions.get(pieceCoorX1, pieceCoorY1 + 1);
            }
            else _positionAfterMoveExecuted.enpassent = null;
            /*--------------------------------------------------*/

            chessBoard.currentPosition.nextPosition = _positionAfterMoveExecuted;
            _positionAfterMoveExecuted.previousPosition = chessBoard.currentPosition;

        }

        public virtual void getBackMove(IChessBoard chessBoard)
        {
            chessBoard.getCell(pieceCoorX1, pieceCoorY1).removePiece();
            if (_targetPiece != null)
            {
                ICell tC = chessBoard.getCell(targetPieceX, targetPieceY);
                tC.addPiece(_targetPiece);
                _targetPiece.currentCoor = tC;
            }

            ICell cell = chessBoard.getCell(pieceCoorX0, pieceCoorY0);
            cell.addPiece(_piece);
            _piece.currentCoor = cell;




        }
        /// <summary>
        /// baslangıc konumu icin bos hamle. eger fen verilmez ise normal tas dizilimi. verilirse ona gore... 
        /// </summary>
        public class EmtyMove : AMove
        {
            public EmtyMove(string fen)
            {
                _positionAfterMoveExecuted = new Position(fen);
            }
            public EmtyMove()
            {
                _positionAfterMoveExecuted = new Position();
            }

            public EmtyMove(IPiece piece, ICoordinate targetCoor, IPiece? targetPiece) : base(piece, targetCoor, targetPiece)
            {
            }
            public override void execute(IChessBoard chessBoard)
            {
                //base.execute(chessBoard);
            }
            public override void getBackMove(IChessBoard chessBoard)
            {
                //base.getBackMove(chessBoard);
            }
        }

    }
    /// <summary>
    /// Nxf3, xf3  , e4 , Qc2 gibi hamleler... enpassent hamleleri dahil....
    /// </summary>
    public class SimpleMove : AMove
    {
        public SimpleMove(IPiece piece, ICoordinate targetCoor, IPiece? targetPiece) : base(piece, targetCoor, targetPiece)
        {

            if (!(piece is IPawn)) moveSymbol += piece.symbol.ToString().ToUpper();
            if (targetPiece != null) moveSymbol += "x";
            moveSymbol += targetCoor.notation;

        }
    }

}
