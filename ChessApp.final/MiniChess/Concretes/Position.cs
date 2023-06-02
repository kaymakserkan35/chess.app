using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes
{
    public class Position : APosition
    {
        public Position? nextPosition { get; internal set; }
        public Position previousPosition { get; internal set; }

        public List<Position> variants;

        public Position() : base()
        {
            variants = new List<Position>();
        }
        public Position(string fen) : base(fen)
        {
            variants = new List<Position>();

        }

        internal override Position copyInShallowForNextPosition(string fen)
        {
            Position p = new Position()
            {
                ooForBlack = ooForBlack,
                ooForWhite = ooForWhite,
                oooForBlack = oooForBlack,
                oooForWhite = oooForWhite,
                whosTurn = whosTurn == PieceColor.white ? PieceColor.black : PieceColor.white,
            };
            p.setFenPosition(fen);
            return p;

        }


        /// <summary> x -> difference in two variants. o same! </summary>
        /// <returns>oooooxxxxoooooxxooxooxoxxoooooooxxxxoooo</returns>
        static public string getDifferenceOfPositions(Position current, Position next)
        {
            string resultFen = "";
            string fenCurrent = current.getPositionInString();
            string fenNext = next.getPositionInString();
            if (fenNext.Length != 64 || fenCurrent.Length != 64) throw new Exception();
            int count = 0;
            for (int y = 1; y <= 8; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    char cCurrent = fenCurrent[count];
                    char cNext = fenNext[count];
                    count++;
                    if (cNext.Equals(cCurrent))
                    {
                        resultFen += 'o';
                    }
                    else
                    {
                        resultFen += 'x';
                    }


                }
            }
            return resultFen;

        }


    }
}
