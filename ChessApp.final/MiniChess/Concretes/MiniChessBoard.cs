using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using MiniChess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes
{
    public class MiniChessBoard : AChessBoard
    {
        static Object _key = new object();
        static MiniChessBoard miniChess = null;
        public bool canControl(IPiece piece, ICoordinate coordinate)
        {
            if (piece == null) throw new ArgumentNullException("");
            if (piece.currentCoor == null) throw new ArgumentNullException();
            if (coordinate == null) throw new ArgumentNullException();
            if (piece.currentCoor == coordinate) return false;
            if (!piece.canMove(coordinate)) return false;
            if (piece is IPawn)
            {
                if (piece.pieceColor == PieceColor.white)
                {
                    if (Math.Abs(coordinate.x - piece.currentCoor.x) == 1 && coordinate.y - piece.currentCoor.y == 1) return true;
                    else return false;
                }
                else if (piece.pieceColor == PieceColor.black)
                {
                    if (Math.Abs(coordinate.x - piece.currentCoor.x) == 1 && coordinate.y - piece.currentCoor.y == -1) return true;
                    else return false;
                }
                else throw new Exception("");
            }
            if (piece is IKing)
            {
                if (Math.Abs(piece.currentCoor.x - coordinate.x) <= 1 && Math.Abs(piece.currentCoor.y - coordinate.y) <= 1) return true;
                else return false;
            }
            lock (_key)
            {
                if (miniChess == null) { miniChess = new MiniChessBoard(); }
                miniChess.loadPosition(this._currentPosition);
                IPiece? p2 = miniChess.getCell(coordinate.x, coordinate.y).getPiece();
                IPiece? p = miniChess.getCell(piece.currentCoor.x, piece.currentCoor.y).getPiece(); if (p == null) throw new Exception("");

                if (p2 == null) return miniChess.checkMoveIsLegal(p, coordinate);
                if (p.pieceColor == p2.pieceColor) miniChess.getCell(p2.currentCoor.x, p2.currentCoor.y).removePiece();
                return miniChess.checkMoveIsLegal(p, coordinate);

            }
        }
        public bool isMoveLegal(Position _position, ICoordinate current, ICoordinate targetCoor)
        {
            lock (_key)
            {
                if (miniChess == null) { miniChess = new MiniChessBoard(); }
                miniChess.loadPosition(_position);
                return miniChess.isMoveLegal(current, targetCoor);
            }

        }
        public override bool isMoveLegal(ICoordinate current, ICoordinate targetCoor)
        {

            PieceColor whosTurn = _currentPosition.whosTurn;
            IPiece? piece = getCell(current.x, current.y).getPiece();

            if (piece == null) return false;
            if (piece.currentCoor == null) { return false; }
            //if (piece.currentCoor == targetCoor) return false;
            //if (!piece.canMove(targetCoor)) return false;
            if (whosTurn != piece.pieceColor) return false;

            bool tf = checkMoveIsLegal(piece, targetCoor);
            if (!tf) return false;
            else
            {

                Position p = _currentPosition;
                AMove move = null;
                move = generateMove(current, targetCoor);
                move.execute(this);
                this._currentPosition = move._positionAfterMoveExecuted;
                IPiece whiteKing = whitePieces.First(bp => bp is IKing); if (whiteKing.currentCoor == null) throw new Exception("");
                IPiece blackKing = blackPieces.First(bp => bp is IKing); if (blackKing.currentCoor == null) throw new Exception("");
                bool kingCantKill = true;
                if (move.positionAfterMoveExecuted.whosTurn == PieceColor.white) { kingCantKill = whitePieces.Any(p => checkMoveIsLegal(p, blackKing.currentCoor)); }
                if (move.positionAfterMoveExecuted.whosTurn == PieceColor.black) { kingCantKill = blackPieces.Any(p => checkMoveIsLegal(p, whiteKing.currentCoor)); }
                move.getBackMove(this); move = null;
                this._currentPosition = p;
                return kingCantKill ? false : true;
            }
        }
        public override List<AMove> getAvaibleMoves(IPiece piece)
        {
            if (piece.currentCoor == null) throw new Exception("");

            List<AMove> moves = new List<AMove>();
            for (int y = 1; y <= 8; y++)
            {
                for (int x = 1; x <= 8; x++)
                {

                    var targetCoordinate = getCell(x, y);
                    //if (!piece.canMove(targetCoordinate)) continue;
                    if (!isMoveLegal(this._currentPosition, piece.currentCoor, targetCoordinate)) { continue; }
                    AMove move = generateMove(piece.currentCoor, targetCoordinate);
                    moves.Add(move);
                    if (move is PromotionMove<IQueen>)
                    {
                        AMove m;
                        m = new PromotionMove<IRook>((IPawn)piece, targetCoordinate, getTargetPiece(piece, targetCoordinate));
                        moves.Add(m);
                        m = new PromotionMove<IKnight>((IPawn)piece, targetCoordinate, getTargetPiece(piece, targetCoordinate));
                        moves.Add(m);
                        m = new PromotionMove<IBishop>((IPawn)piece, targetCoordinate, getTargetPiece(piece, targetCoordinate));
                        moves.Add(m);
                    }

                }
            }
            return moves;
        }
        /// <summary>
        /// hamlenin legal controlünü sağlamadan bu methodu kullanma!!
        /// </summary>
        /// <param name="current"></param>
        /// <param name="targetCoor"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override AMove generateMove(ICoordinate current, ICoordinate targetCoor)
        {
            lock (_key) if (miniChess == null) miniChess = new MiniChessBoard();

            AMove move;
            IPiece? piece = getCell(current.x, current.y).getPiece();
            if (piece == null) { throw new Exception(""); }
            IPiece? targetPiece = getTargetPiece(piece, targetCoor);
            if (piece is IPawn && piece.type == typeof(IPawn) && (targetCoor.y == 1 || targetCoor.y == 8))
            {
                move = new PromotionMove<IQueen>((IPawn)piece, targetCoor, targetPiece);
            }
            else if (targetPiece != null && targetPiece.pieceColor == piece.pieceColor)
            {
                move = new CastlingMove(piece, targetCoor, targetPiece);
            }
            else move = new SimpleMove(piece, targetCoor, targetPiece);

            {// set ambigous for moveSymbol
                if (piece.pieceColor == PieceColor.white)
                {// check for ambigous piece
                    IPiece? p = whitePieces.FirstOrDefault(p => checkMoveIsLegal(p, targetCoor));
                    if (p != null && p != piece && p.type == piece.type)
                    {
                        if (p.currentCoor.x != piece.currentCoor.x)
                        {
                            if (piece is IPawn) move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                            else move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                        }
                        else move.moveSymbol = piece.currentCoor.y.ToString() + move.moveSymbol;

                    }
                    // set if there is check situation
                    miniChess.loadPosition(_currentPosition);
                    IPiece? _p = miniChess.getCell(current.x, current.y).getPiece(); if (_p == null) throw new Exception("");
                    miniChess.getCell(targetCoor.x, targetCoor.y).addPiece(_p);
                    IPiece king = miniChess.blackPieces.First(x => x is IKing);
                    if (miniChess.whitePieces.Any(x => miniChess.checkMoveIsLegal(x, king.currentCoor))) { move.moveSymbol += "+"; }


                }

                if (piece.pieceColor == PieceColor.black)
                {// check for ambigous piece
                    IPiece? p = blackPieces.FirstOrDefault(p => checkMoveIsLegal(p, targetCoor));
                    if (p != null && p != piece && p.type == piece.type)// check for ambigous piece
                    {
                        if (p.currentCoor.x != piece.currentCoor.x)
                        {
                            if (piece is IPawn) move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                            else move.moveSymbol = CoorExtensions.get(piece.currentCoor.x) + move.moveSymbol;
                        }
                        else move.moveSymbol = piece.currentCoor.y.ToString() + move.moveSymbol;

                    }
                    // set if there is check situation
                    miniChess.loadPosition(_currentPosition);
                    IPiece? _p = miniChess.getCell(current.x, current.y).getPiece(); if (_p == null) throw new Exception("");
                    miniChess.getCell(targetCoor.x, targetCoor.y).addPiece(_p);
                    IPiece king = miniChess.whitePieces.First(x => x is IKing);
                    if (miniChess.blackPieces.Any(x => miniChess.checkMoveIsLegal(x, king.currentCoor))) { move.moveSymbol += "+"; }

                }


            }
            return move;
        }
        /// <summary>
        ///  daha bitmedi sıkıldım. sonra devam edecegim.
        /// </summary>
        public bool isGameEnd
        {
            get
            {
                List<AMove> moves = getAlPossibleMovesForCurrentPosition();
                if (moves.Count == 0)
                {// burada stalamente mi yoksa mate mi onun kararını belirleyecegiz. oncekşi hamlede sah hamlesi varmı diye bakacagız.
                    _game.result = Result.equality; return true;
                }
                else
                {
                    if (moves.Any(m => !(((IMove)m).piece is IKing)))
                    {
                        moves[0].execute(this);
                        if (getAlPossibleMovesForCurrentPosition().Any(m => !(((IMove)m).piece is IKing))) { _game.result = Result.equality; return true; }
                        else
                        {
                            moves[0].getBackMove(this); return false;
                        }
                    }
                }

                return false;
            }
        }

    }
}
