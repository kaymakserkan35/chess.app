using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.Controls.Pieces
{
    internal class PieceControl : PictureBox, IPiece
    {
        protected IPiece piece;
        public Action<PieceControl> onMouseDownOnPiece { get; set; }
        public Action<IPiece> onPieceDragging { get; set; }



        public PieceControl(ICoordinate current, PieceColor color)
        {
            this.Dock = DockStyle.Fill;
            SizeMode = PictureBoxSizeMode.StretchImage;
            this.Margin = new Padding(15, 15, 15, 5);

            this.MouseDown += (s, e) =>
            {
                if (onMouseDownOnPiece != null) onMouseDownOnPiece.Invoke(this);
                this.DoDragDrop(this, DragDropEffects.Move);
            };
            this.MouseUp += (s, e) => { };
        }

        public Type type => piece.type;

        public PieceColor pieceColor => piece.pieceColor;

        char IPiece.symbol { get => piece.symbol; set => piece.symbol = value; }
        ICoordinate? IPiece.currentCoor { get => piece.currentCoor; set => piece.currentCoor = value; }
        public List<AMove> avaibleMoves { get ; set ; }

        public void setImage(Bitmap b)
        {
            this.Image = b;
        }

        bool IPiece.canMove(ICoordinate targetCoor)
        {
            return piece.canMove(targetCoor);
        }

        bool IPiece.canMove(ICoordinate initialCoor, ICoordinate targetCoor)
        {
            return piece.canMove(targetCoor, targetCoor);
        }
    }
}
