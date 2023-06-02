using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes
{
    public abstract class APiece : IPiece
    {
        private char _symbol;
        public char symbol
        {
            get { return _symbol; }
            set
            {
                // if (!(this is IPromotable)) { throw new InvalidOperationException(); }
                // else 
                { _symbol = value; }
            }
        }
        private Type _type;
        public Type type
        {
            get { return _type; }
            internal set
            {
                if (!(this is IPromotable)) { throw new InvalidOperationException(); }
                if ((value is IPiece)) { throw new InvalidOperationException(); }
                if (value == typeof(IKing)) { throw new InvalidOperationException(); }

                else if (value != null) { _type = value; }
            }
        }

        public APiece(ICoordinate currentCoor, PieceColor pieceColor)
        {
            this.currentCoor = currentCoor;
            this.pieceColor = pieceColor;
            if (this is IPawn) _type = typeof(IPawn);
            else if (this is IRook) _type = typeof(IRook);
            else if (this is IKnight) _type = typeof(IKnight);
            else if (this is IBishop) _type = typeof(IBishop);
            else if (this is IQueen) _type = typeof(IQueen);
            else if (this is IKing) _type = typeof(IKing);
            else throw new InvalidOperationException();
            avaibleMoves = new List<AMove>();

        }
        public ICoordinate? currentCoor { get; set; }
        public PieceColor pieceColor { get; }
        public List<AMove> avaibleMoves { get; set; }

        public abstract bool canMove(ICoordinate targetCoor);
        public abstract bool canMove(ICoordinate initialCoor, ICoordinate targetCoor);
    }
}
