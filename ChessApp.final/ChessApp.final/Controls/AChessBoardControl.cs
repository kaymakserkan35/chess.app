using ChessApp.final.Controls.Pieces;
using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using ChessApp.final.MiniChess.Concretes.Pieces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChessApp.final.Controls
{
    public abstract partial class AChessBoardControl : UserControl, IChessBoard
    {
        protected Position _currentPosition;
        Position IChessBoard.currentPosition { get => _currentPosition; set => _currentPosition = value; }
        protected Action<IPiece, ICoordinate> onMove;
        protected bool highlighAvaibleMoves = true;
        protected MiniChessBoard miniChessBoard = new MiniChessBoard();
        protected IGame game;

        protected List<IPiece> whitePieces, blackPieces;
        List<CellControl> cells;
        private int colTox(int col) { return (col - 1); }
        private int rowToY(int row) { return (8 - row); }
        private int xToCol(int x) { return (x + 1); }
        private int yToRow(int y) { return 8 - y; }
        public AChessBoardControl()
        {
            InitializeComponent();
            whitePieces = new List<IPiece>();
            blackPieces = new List<IPiece>();
            cells = new List<CellControl>();
            for (int row = 1; row <= 8; row++)
            {
                for (int col = 1; col <= 8; col++)
                {
                    CellControl panel = new CellControl(col, row);
                    if ((col + row) % 2 == 1) panel.BackColor = Color.White;
                    else panel.BackColor = Color.Gray;
                    cells.Add(panel);
                    tableLayoutPanel1.Controls.Add(panel, colTox(col), rowToY(row));
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
                                PawnControl piece = new PawnControl(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'r':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                RookControl piece = new RookControl(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'n':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                KnightControl piece = new KnightControl(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'b':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                BishopControl piece = new BishopControl(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'q':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                QueenControl piece = new QueenControl(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        case 'k':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                KingControl piece = new KingControl(cell, PieceColor.black);
                                cell.addPiece(piece); blackPieces.Add(piece);
                                continue;
                            }
                        /*-----------------------------------------------------------------*/
                        case 'P':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                PawnControl piece = new PawnControl(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'R':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                RookControl piece = new RookControl(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'N':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                KnightControl piece = new KnightControl(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'B':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                BishopControl piece = new BishopControl(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'Q':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                QueenControl piece = new QueenControl(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }
                        case 'K':
                            {
                                ICell cell = ((IChessBoard)this).getCell(x, y);
                                KingControl piece = new KingControl(cell, PieceColor.white);
                                cell.addPiece(piece); whitePieces.Add(piece);
                                continue;
                            }

                        default: continue;

                    }
                }
            }
        }


        public virtual void loadGame(IGame game)
        {
            this.game = game;
            loadPosition(game.getLastPosition());

        }

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
        internal virtual void loadPosition(Position position)
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

        public string getPositionInFenFromBoard()
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

        public virtual List<AMove> getAvaibleMoves(IPiece piece)
        {
            if (piece.currentCoor == null) throw new Exception("");
            List<AMove> moves = new List<AMove>();
            for (int y = 1; y <= 8; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    var targetCoordinate = getCell(x, y);
                    if (!((IChessBoard)this).isMoveLegal(piece.currentCoor, targetCoordinate)) { continue; }
                    AMove move = generateMove(piece.currentCoor, targetCoordinate);
                    moves.Add(move);
                    if (move is PromotionMove<IQueen>)
                    {
                        moves.Add(new PromotionMove<IRook>((IPawn)piece, targetCoordinate, getTargetPiece(piece, targetCoordinate)));
                        moves.Add(new PromotionMove<IKnight>((IPawn)piece, targetCoordinate, getTargetPiece(piece, targetCoordinate)));
                        moves.Add(new PromotionMove<IBishop>((IPawn)piece, targetCoordinate, getTargetPiece(piece, targetCoordinate)));
                    }
                }
            }
            return moves;

        }

        public virtual List<AMove> getAlPossibleMovesForCurrentPosition()
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





        private void forward_Click(object sender, EventArgs e)
        {
            game.next(this);
        }

        private void backward_Click(object sender, EventArgs e)
        {
            game.back(this);
        }

        private void backwardMax_Click(object sender, EventArgs e)
        {
            game.backBack(this);
        }



        private void forwardMax_Click(object sender, EventArgs e)
        {
            game.nextNext(this);
        }
        public IPiece? getTargetPiece(IPiece piece, ICoordinate targetCoor)
        {
            if (piece.currentCoor == null) throw new Exception("");
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
                if (piece.pieceColor == PieceColor.white)
                {
                    if (targetCoor.x == 7) return getCell(8, 1).getPiece();
                    if (targetCoor.x == 3) return getCell(1, 1).getPiece();
                    throw new Exception("");
                }
                else
                {
                    if (targetCoor.x == 7) return getCell(8, 8).getPiece();
                    if (targetCoor.x == 3) return getCell(1, 8).getPiece();
                    throw new Exception("");
                }

            }
            else
            {
                return getCell(targetCoor.x, targetCoor.y).getPiece();
            }
        }


        protected virtual void ChessBoardControl_Load(object sender, EventArgs e)
        {
            if (highlighAvaibleMoves == true)
            {
                List<IPiece> pieces = new List<IPiece>();
                pieces.AddRange(whitePieces); pieces.AddRange(blackPieces);
                foreach (IPiece p in pieces)
                {
                    var piece = (PieceControl)p;
                    piece.onMouseDownOnPiece += (p) =>
                    {
                        IPiece _p = (IPiece)p;

                        _p.avaibleMoves = getAvaibleMoves(p);
                        _p.avaibleMoves.ForEach(x =>
                        {
                            CellControl c = (CellControl)getCell(x.pieceCoorX1, x.pieceCoorY1);
                            c.highlightCell();
                        });

                    };
                }
            }

            foreach (var cell in cells)
            {
                ((CellControl)cell).onPieceDropped += (piece, targetCoordinate) =>
                {

                    if (onMove != null) onMove.Invoke(piece, targetCoordinate);
                    cells.ForEach((cell) =>
                    {
                        if (cell.BackColor == Color.Yellow)
                        {
                            cell.removeHighlightCell();
                        }

                    });

                };
            }


        }

        public ICell getCell(int x, int y)
        {
            return cells.First(c => c.x == x && c.y == y);
        }


        public abstract AMove generateMove(ICoordinate current, ICoordinate targetCoor);
        public abstract bool isMoveLegal(ICoordinate current, ICoordinate targetCoor);
    }
}
