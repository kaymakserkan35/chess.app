using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Abstractions
{
    public interface IPosition
    {
        PieceColor whosTurn { get; }
        string? enpassent { get; }
        string fen { get; }
        string useThisMethodJustWannaSeePositionInCode();
        bool ooForWhite { get; }
        bool oooForWhite { get; }
        bool ooForBlack { get; }
        bool oooForBlack { get; }

    }
}
