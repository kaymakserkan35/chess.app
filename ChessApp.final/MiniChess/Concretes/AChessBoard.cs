using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using ChessApp.final.MiniChess.Concretes.Pieces;

namespace ChessApp.final.MiniChess.Concretes
{
    public abstract class AChessBoard : IChessBoard
    {
        public List<Cell> Cells => cells;
        protected List<Cell> cells;
        protected List<IPiece> whitePieces, blackPieces;
        public List<IPiece> WhitePieces => whitePieces;
        public List<IPiece> BlackPieces => blackPieces;
        protected Position _currentPosition;
        protected IGame _game;

        public AChessBoard()
        {
            cells = new List<Cell>();
            whitePieces = new List<IPiece> { };
            blackPieces = new List<IPiece> { };
            for (int y = 1; y <= 8; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    cells.Add(new Cell(x, y));
                }
            }
            _currentPosition = new Position();
            string fen = _currentPosition.getPositionInString();
            int count = 0;
            for (int y = 1; y <= 8; y++)
            {

                for (int x = 1; x <= 8; x++)
                {
                    char c = fen[count];
                    count++;
                    switch (c)
                    {
                        case 'p':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Pawn piece = new Pawn(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'r':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Rook piece = new Rook(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'n':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Knight piece = new Knight(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'b':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Bishop piece = new Bishop(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'q':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Queen piece = new Queen(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'k':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                King piece = new King(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        /*-----------------------------------------------------------------*/
                        case 'P':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Pawn piece = new Pawn(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'R':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Rook piece = new Rook(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'N':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Knight piece = new Knight(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'B':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Bishop piece = new Bishop(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'Q':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                Queen piece = new Queen(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'K':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                King piece = new King(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }

                        default: continue;

                    }
                }
            }

        }
        Position IChessBoard.currentPosition { get => _currentPosition; set => _currentPosition = value; }

        private void clearBoard()
        {
            foreach (var cell in cells)
            {
                cell.removePiece();
            }
            List<IPiece> pieces = new List<IPiece>();
            pieces.AddRange(whitePieces);
            pieces.AddRange(blackPieces);
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].currentCoor = null;
            }
        }
        /// <summary>
        /// sadece konum analizi icin kullanılmalıdır. satarnc tahsasının game nesnesi null dur. hamle yapılamaz! bunu sadece paket ici kullanmak gereklidir.
        /// final de method internal method a çekilmelidir.
        /// </summary>
        /// <param name="position"></param>
        public void loadPosition(Position position)
        {
            clearBoard();
            _currentPosition = position;
            string fen = position.getPositionInString();
            int count = 0;
            for (int y = 1; y <= 8; y++)
            {

                for (int x = 1; x <= 8; x++)
                {
                    char c = fen[count];
                    count++;
                    switch (c)
                    {
                        case 'p':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPawn piece = (IPawn)blackPieces.First(x => x.currentCoor == null && x is IPawn);
                                piece.dePromote();
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'P':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPawn piece = (IPawn)whitePieces.First(x => x.currentCoor == null && x is IPawn);
                                piece.dePromote();
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'r':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = blackPieces.FirstOrDefault(x => x.currentCoor == null && x is IRook);
                                if (piece == null) { piece = blackPieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IRook>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'n':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = blackPieces.FirstOrDefault(x => x.currentCoor == null && x is IKnight);
                                if (piece == null) { piece = blackPieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IKnight>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'b':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = blackPieces.FirstOrDefault(x => x.currentCoor == null && x is IBishop);
                                if (piece == null) { piece = blackPieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IBishop>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'q':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = blackPieces.FirstOrDefault(x => x.currentCoor == null && x is IQueen);
                                if (piece == null) { piece = blackPieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IQueen>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'k':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = blackPieces.First(x => x.currentCoor == null && x is IKing);
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'R':
                            {

                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = whitePieces.FirstOrDefault(x => x.currentCoor == null && x is IRook);
                                if (piece == null) { piece = whitePieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IRook>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'N':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = whitePieces.FirstOrDefault(x => x.currentCoor == null && x is IKnight);
                                if (piece == null) { piece = whitePieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IKnight>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'B':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = whitePieces.FirstOrDefault(x => x.currentCoor == null && x is IBishop);
                                if (piece == null) { piece = whitePieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IBishop>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'Q':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = whitePieces.FirstOrDefault(x => x.currentCoor == null && x is IQueen);
                                if (piece == null) { piece = whitePieces.First(x => x.currentCoor == null && x is IPawn); ((IPawn)piece).promote<IQueen>(); }
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        case 'K':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                IPiece? piece = whitePieces.First(x => x.currentCoor == null && x is IKing);
                                cell.addPiece(piece); piece.currentCoor = cell;
                                continue;
                            }
                        default: continue;
                    }
                }
            }
        }

        /// <summary>
        /// bu method hamle sırasının kimde olup olamdığına bakmaksızın, taşın oynanabilir olup olmadığına bakmaktadır.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="targetCoor"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool checkMoveIsLegal(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == targetCoor) return false;
            if (!piece.canMove(targetCoor)) return false;
            if (piece.type == typeof(IPawn)) return legalMoveForPawn(piece, targetCoor);
            if (piece.type == typeof(IRook)) return legalMoveForRook(piece, targetCoor);
            if (piece.type == typeof(IBishop)) return legalMoveForBishop(piece, targetCoor);
            if (piece.type == typeof(IQueen)) return legalMoveForQuuen(piece, targetCoor);
            if (piece.type == typeof(IKnight)) return legalMoveForKnight(piece, targetCoor);
            if (piece.type == typeof(IKing)) return legalMoveForKing(piece, targetCoor);
            throw new Exception("");
        }

        public ICell getCell(int x, int y)
        {
            ICell cell = cells.First((cell) => { return cell.x == x && cell.y == y; });
            return cell;
        }
        #region LegalMove
        protected bool legalMoveForKnight(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.type != typeof(IKnight)) throw new Exception();
            if (!piece.canMove(targetCoor)) return false;

            IPiece? p = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (p != null && p.pieceColor == piece.pieceColor) return false;
            return true;
        }
        protected bool legalMoveForRook(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IRook) && piece.type != typeof(IQueen)) throw new Exception();
            if (!piece.canMove(targetCoor)) return false;
            IPiece? targetPiece = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (targetPiece != null && piece.pieceColor == targetPiece.pieceColor) return false;
            if (piece.currentCoor.x == targetCoor.x)
            {
                int x = piece.currentCoor.x;
                int y = piece.currentCoor.y;

                while (y != targetCoor.y)
                {

                    IPiece? p = getCell(x, y).getPiece();
                    if (p != piece && p != null) return false;
                    if (piece.currentCoor.y > targetCoor.y) y--;
                    else y++;
                }
            }
            if (piece.currentCoor.y == targetCoor.y)
            {
                int y = piece.currentCoor.y;
                int x = piece.currentCoor.x;

                while (x != targetCoor.x)
                {

                    IPiece? p = getCell(x, y).getPiece();
                    if (p != piece && p != null) return false;
                    if (piece.currentCoor.x > targetCoor.x) x--;
                    else x++;

                }

            }
            return true;
        }
        protected bool legalMoveForKing(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IKing)) throw new Exception();
            IPiece? targetPiece = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (targetPiece != null && piece.pieceColor == targetPiece.pieceColor) return false;
            int y = piece.currentCoor.y;
            int x = piece.currentCoor.x;
            if (Math.Abs(piece.currentCoor.x - targetCoor.x) == 2)
            {
                if (x < targetCoor.x)
                {
                    if (piece.pieceColor == PieceColor.white && !_currentPosition.ooForWhite) return false;
                    if (piece.pieceColor == PieceColor.black && !_currentPosition.ooForBlack) return false;

                }
                else
                {
                    if (piece.pieceColor == PieceColor.white && !_currentPosition.oooForWhite) return false;
                    if (piece.pieceColor == PieceColor.black && !_currentPosition.oooForBlack) return false;
                }
                if (getCell(targetCoor.x, targetCoor.y).getPiece() != null) return false;
                if (piece.pieceColor == PieceColor.white && blackPieces.Any(p => checkMoveIsLegal(p, getCell(piece.currentCoor.x, y)))) return false;
                if (piece.pieceColor == PieceColor.black && whitePieces.Any(p => checkMoveIsLegal(p, getCell(piece.currentCoor.x, y)))) return false;

                while (x != targetCoor.x)
                {
                    if (piece.pieceColor == PieceColor.white)
                    {
                        if (blackPieces.Any(p => checkMoveIsLegal(p, getCell(x, y)))) return false;
                    }
                    if (piece.pieceColor == PieceColor.black)
                    {
                        if (whitePieces.Any(p => checkMoveIsLegal(p, getCell(x, y)))) return false;
                    }

                    IPiece? p = getCell(x, y).getPiece();
                    if (p != piece && p != null) return false;

                    if (piece.currentCoor.x > targetCoor.x) x--;
                    else x++;
                }
                if (targetCoor.x < piece.currentCoor.x && (getCell(2, y).getPiece() != null)) return false;

            }


            return true;
        }
        protected bool legalMoveForBishop(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IBishop) && piece.type != typeof(IQueen)) throw new Exception();
            IPiece? targetPiece = getCell(targetCoor.x, targetCoor.y).getPiece();
            if (targetPiece != null && targetPiece.pieceColor == piece.pieceColor) return false;

            int x = piece.currentCoor.x;
            int y = piece.currentCoor.y;

            while (x != targetCoor.x)
            {
                IPiece? p = getCell(x, y).getPiece();
                if (p != piece && p != null) return false;

                if (piece.currentCoor.x > targetCoor.x) x--;
                else x++;
                if (piece.currentCoor.y > targetCoor.y) y--;
                else y++;

            }

            return true;
        }
        protected bool legalMoveForQuuen(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.currentCoor.x == targetCoor.x || piece.currentCoor.y == targetCoor.y)
                return legalMoveForRook(piece, targetCoor);
            else return legalMoveForBishop(piece, targetCoor);

        }
        protected bool legalMoveForPawn(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
            if (piece.type != typeof(IPawn)) throw new Exception();
            if (piece.currentCoor.x == targetCoor.x)
            {
                int y = piece.currentCoor.y;
                while (y != targetCoor.y)
                {
                    if (y > targetCoor.y) y--; else y++;
                    IPiece? p = getCell(piece.currentCoor.x, y).getPiece();
                    if (p != null) return false;
                }
            }
            else
            {
                IPiece? p = getCell(targetCoor.x, targetCoor.y).getPiece();
                if (p != null && piece.pieceColor == p.pieceColor) return false;
                if (p != null && piece.pieceColor != p.pieceColor) return true;
                if (p == null)
                {
                    if (_currentPosition.enpassent == null) return false;
                    else
                    {
                        int[] xy = CoorExtensions.get(_currentPosition.enpassent);
                        ICoordinate coor = getCell(xy[0], xy[1]);
                        if (coor.x != targetCoor.x) return false;
                        if (piece.pieceColor == PieceColor.white && targetCoor.y != coor.y) return false;
                        if (piece.pieceColor == PieceColor.black && targetCoor.y != coor.y) return false;

                    }
                }
            }
            return true;

        }

        #endregion

        public void loadGame(IGame game)
        {
            _game = game;
            loadPosition(game.getLastPosition());
        }

        string IChessBoard.getPositionInFenFromBoard()
        {
            string fen = "";
            for (int y = 8; y > 0; y--)
            {
                int sum = 0;
                for (int x = 1; x <= 8; x++)
                {
                    IPiece? piece = getCell(x, y).getPiece();
                    if (piece == null)
                    {
                        sum += 1;
                    }
                    else
                    {
                        if (sum != 0) { fen += sum.ToString(); sum = 0; }
                        fen += piece.symbol;
                    }
                }
                if (sum != 0) { fen += sum.ToString(); sum = 0; }
                if (y != 1) fen += "/";

            }
            return fen;
        }



        public List<AMove> getAlPossibleMovesForCurrentPosition()
        {
            List<AMove> moves = new List<AMove>();
            if (this._currentPosition.whosTurn == PieceColor.white)
            {
                for (int i = 0; i < whitePieces.Count; i++)
                {
                    IPiece p = whitePieces[i]; if (p.currentCoor == null) continue;
                    moves.AddRange(getAvaibleMoves(whitePieces[i]));
                }
            }
            else
            {
                for (int i = 0; i < blackPieces.Count; i++)
                {
                    IPiece p = blackPieces[i]; if (p.currentCoor == null) continue;
                    moves.AddRange(getAvaibleMoves(blackPieces[i]));
                }
            }
            return moves;
        }

        public abstract bool isMoveLegal(ICoordinate current, ICoordinate targetCoor);
        public IPiece? getTargetPiece(IPiece piece, ICoordinate targetCoor)
        {

            if (piece.currentCoor == null) throw new Exception("");
            if (!piece.canMove(piece.currentCoor, targetCoor)) throw new Exception();
            if (piece.type == typeof(IPawn) && piece is IPawn && piece.currentCoor.x != targetCoor.x)
            {
                IPiece? p = getCell(targetCoor.x, targetCoor.y).getPiece();
                if (p != null) return p;
                else
                {
                    if (_currentPosition.enpassent != null)
                    {
                        int[] xy = CoorExtensions.get(_currentPosition.enpassent);
                        ICoordinate c;
                        if (piece.pieceColor == PieceColor.white) c = getCell(xy[0], xy[1] - 1);
                        else c = getCell(xy[0], xy[1] + 1);
                        IPiece? p2 = getCell(c.x, c.y).getPiece();
                        if (p2 != null) return p2;
                        else throw new Exception("");

                    }
                    else throw new Exception("");
                }
            }
            if (piece is IKing && Math.Abs(targetCoor.x - piece.currentCoor.x) == 2)
            {
                IPiece? p;
                if (piece.pieceColor == PieceColor.white)
                {
                    if (targetCoor.x == 7) p = getCell(8, 1).getPiece();
                    else if (targetCoor.x == 3) p = getCell(1, 1).getPiece();
                    else throw new Exception("");

                }
                else
                {
                    if (targetCoor.x == 7) p = getCell(8, 8).getPiece();
                    else if (targetCoor.x == 3) p = getCell(1, 8).getPiece();
                    else throw new Exception("");
                }
                if (p == null) throw new Exception("");
                if (p.type != typeof(IRook)) throw new Exception("");
                return p;
            }
            else return getCell(targetCoor.x, targetCoor.y).getPiece();
        }

        public abstract AMove generateMove(ICoordinate current, ICoordinate targetCoor);
        public abstract List<AMove> getAvaibleMoves(IPiece piece);
    }
}
