using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.final.MiniChess.Concretes
{
    public abstract class APosition : IPosition
    {
        protected string[] rowPositions = new string[8];
        public PieceColor whosTurn { get; internal set; }

        public string? enpassent { get; internal set; }

        public string fen
        {
            get
            {
                string res = "";
                for (int i = 0; i < rowPositions.Length; i++)
                {
                    res += rowPositions[i];
                    if (i != rowPositions.Length - 1) res += "/";
                }
                res += " ";
                res += whosTurn == PieceColor.white ? "w" : "b";
                res += " ";
                if ((!ooForWhite && !oooForWhite && !oooForBlack && !oooForBlack)) res += "-";
                else
                {
                    if (ooForWhite) res += "K";
                    if (oooForWhite) res += "Q";
                    if (ooForBlack) res += "k";
                    if (oooForBlack) res += "q";
                }
                res += " ";
                if (enpassent != null) res += enpassent; else res += "-";
                res += " ";
                return res;
            }
        }

        public bool ooForWhite { get; internal set; }

        public bool oooForWhite { get; internal set; }

        public bool ooForBlack { get; internal set; }

        public bool oooForBlack { get; internal set; }

        public APosition()
        {
            rowPositions[0] = "rnbqkbnr";
            rowPositions[1] = "pppppppp";
            rowPositions[2] = "8";
            rowPositions[3] = "8";
            rowPositions[4] = "8";
            rowPositions[5] = "8";
            rowPositions[6] = "PPPPPPPP";
            rowPositions[7] = "RNBQKBNR";
            ooForWhite = true;
            oooForWhite = true;
            ooForBlack = true;
            oooForBlack = true;
            whosTurn = PieceColor.white;

        }
        public APosition(string fenPos)
        {
            setFenPosition(fenPos);
        }
        internal void setFenPosition(string fenPos)
        {
            string[] fields = fenPos.Split(' ');
            rowPositions = fields[0].Split('/').ToArray();
            if (fields.Length == 1) { return; }
            switch (fields[1])
            {
                case "w": whosTurn = PieceColor.white; break;
                case "b": whosTurn = PieceColor.black; break;
            }

            string castleRights = fields[2];
            ooForWhite = castleRights.Contains('K') ? true : false;
            oooForWhite = castleRights.Contains('Q') ? true : false;
            ooForBlack = castleRights.Contains('k') ? true : false;
            oooForBlack = castleRights.Contains('q') ? true : false;
            if (fields[3] != "-")
            {
                if (!(fields[3].Contains('3') || fields[3].Contains('6'))) throw new Exception("");
                enpassent = fields[3]; 
            }
            else enpassent = null;
        }
        /// <summary>useThisMethodJustWannaSeePositionInCode</summary>
        /// <returns>
        /// rnbkweqe
        /// pppppppp
        /// oooooooo
        /// oooooooo
        /// oooooooo
        /// PPPPPPPP
        /// RKBRQKNR
        /// </returns>
        public string useThisMethodJustWannaSeePositionInCode()
        {
            string returningValue = "";
            string[] arr = new string[8];
            for (int y = 7; y >= 0; y--)
            {
                string res = " ";
                string row = rowPositions[y];

                for (int x = 0; x < row.Length; x++)
                {
                    int num = 0;
                    char c = row[x];
                    if (int.TryParse(c.ToString(), out num))
                    {
                        for (int j = 0; j < num; j++)
                        {
                            res += " 0";
                        }
                    }
                    else
                    {
                        res += " " + c;
                    }
                }
                res += " \n";
                arr[y] = res;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                returningValue += arr[i];
            }

            return returningValue;
        }


        /// <summary> 11 -> 88 e kadar string bir sekide konum saglar. 1 ler bos kareleri temsil ediyor. </summary>
        /// <returns> q11r111r1r1r1111q11q1111k1k1n1n1n1 </returns>
        public string getPositionInString()
        {
            string res = "";
            for (int y = 7; y >= 0; y--)
            {
                string row = rowPositions[y];

                for (int x = 0; x < row.Length; x++)
                {
                    int num = 0;
                    char c = row[x];
                    if (int.TryParse(c.ToString(), out num))
                    {
                        for (int j = 0; j < num; j++)
                        {
                            res += "1";
                        }
                    }
                    else
                    {
                        res += c;
                    }
                }

            }
            return res;
        }
        abstract internal APosition copyInShallowForNextPosition(string fen);

    }
}
