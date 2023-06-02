using ChessApp.final.Controls.Pieces;
using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.Controls
{
    internal class CellControl : Panel, ICell
    {
        ICell cell;
        public Action<IPiece> onPieceEntered { get; set; }
        public Action<IPiece, ICoordinate> onPieceDropped { get; set; }
        public CellControl(int col, int row)
        {
            cell = new Cell(col, row);
            AllowDrop = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0, 0, 0, 0);
            this.DragDrop += (s, e) =>
            {
                IPiece piece = getPieceFromDragEventArgs(e);
                e.Effect = DragDropEffects.All;
                if (onPieceDropped != null) onPieceDropped.Invoke(piece, this);
            };
            this.DragEnter += (s, e) =>
            {
                IPiece piece = getPieceFromDragEventArgs(e);
                e.Effect = DragDropEffects.All;
                if (onPieceEntered != null) onPieceEntered.Invoke(piece);

            };

        }




        public int x => cell.x;

        public int y => cell.y;

        public string notation { get => cell.notation; protected set { } }

        public void addPiece(IPiece piece)
        {
            cell.addPiece(piece);
            this.Controls.Add((PieceControl)piece);
        }

        public IPiece? getPiece()
        {
            cell.getPiece();
            if (this.Controls.Count != 0)
            {
                return this.Controls[0] as PieceControl;
            }
            return null;
        }

        public void removePiece()
        {
            cell.removePiece();
            this.Controls.Clear();
        }
        private Type[] getPiecesTypes()
        {

            Type[] types = new Type[6];
            types[0] = typeof(PawnControl);
            types[1] = typeof(RookControl);
            types[2] = typeof(KnightControl);
            types[3] = typeof(BishopControl);
            types[4] = typeof(QueenControl);
            types[5] = typeof(KingControl);
            return types;
        }
        internal void highlightCell()
        {
            this.BackColor = Color.Yellow;
        }
        internal void removeHighlightCell()
        {
            if ((x + y) % 2 == 1)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.Gray;
            }
        }

        private PieceControl getPieceFromDragEventArgs(DragEventArgs e)
        {
            PieceControl control = null;
            Type[] piecesTypes = getPiecesTypes();
            for (int i = 0; i < getPiecesTypes().Length; i++)
            {
                control = ((PieceControl)e.Data.GetData(piecesTypes[i]));
                if (control != null) break;
            }
            return control;

        }
    }
}
