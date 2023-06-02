using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPositionAnalyses
{
    internal class DataPreperator
    {
        internal List<string[]> readCsvFile(string name)
        {
            List<string[]> lines = new List<string[]>();
            string url = Directory.GetCurrentDirectory();
            url = Path.GetFullPath(Path.Combine(url, @"..\..\..\..\"));
            name = name + ".csv";
            url = Path.Combine(url + @"\" + name);
            using (TextFieldParser parser = new TextFieldParser(url))
            {
                parser.Delimiters = new string[] { "," };
                parser.TextFieldType = FieldType.Delimited;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    lines.Add(fields);
                }
            }
            return lines;
        }


        internal List<string[]> analyseAndInitiateDatabase(List<string[]> lines, string databaseName)
        {
            List<string[]> rows = new List<string[]>();
            databaseName = databaseName + ".csv";
            lines.RemoveAt(0);
            MiniChessBoard miniChessBoard = new MiniChessBoard();
            int count = 0;
            foreach (string[] line in lines)
            {
                if (count == 20000) return rows;
                count++;
                Position position = new Position(line[0]);
                miniChessBoard.loadPosition(position);
                List<string> headers = new List<string>();
                List<string> row = new List<string>();
                headers.Add("evaluation");
                row.Add(line[1]);




                foreach (IPiece p in miniChessBoard.WhitePieces)
                {
                    headers.Add("a1-" + getOriginalSymbol(p) + "-h8");
                    string res = "";
                    foreach (var cell in miniChessBoard.Cells)
                    {

                        if (p.currentCoor == null) { res += "X"; break; }
                        else if (p.currentCoor == cell) res += p.symbol;
                        else if (miniChessBoard.checkMoveIsLegal(p, cell)) res += ("3");
                        else if (miniChessBoard.canControl(p, cell)) res += ("2");
                        else if (p.canMove(cell)) res += ("1");
                        else res += ("0");
                    }
                    row.Add(res);

                }



                foreach (IPiece p in miniChessBoard.BlackPieces)
                {
                    headers.Add("a1-" + getOriginalSymbol(p) + "-h8");
                    string res = "";
                    foreach (var cell in miniChessBoard.Cells)
                    {

                        if (p.currentCoor == null) { res += "X"; break; }
                        else if (p.currentCoor == cell) res += p.symbol;
                        else if (miniChessBoard.checkMoveIsLegal(p, cell)) res += ("3");
                        else if (miniChessBoard.canControl(p, cell)) res += ("2");
                        else if (p.canMove(cell)) res += ("1");
                        else res += ("0");
                    }
                    row.Add(res);

                }





                headers.Add("whosTurn"); row.Add(position.whosTurn.ToString());

                int r = 0;
                headers.Add("shortCastleForWhite"); r = (position.ooForWhite) ? 1 : 0; row.Add(r.ToString());
                headers.Add("longCastleForWhite"); r = (position.oooForWhite) ? 1 : 0; row.Add(r.ToString());
                headers.Add("shortCastleForBlack"); r = (position.ooForBlack) ? 1 : 0; row.Add(r.ToString());
                headers.Add("longCastleForBlack"); r = (position.oooForBlack) ? 1 : 0; row.Add(r.ToString());

                rows.Add(row.ToArray());

                /*
                string? enpassent = position.enpassent;
                int[]? xy = null;
                if (enpassent != null) xy = CoorExtensions.get(enpassent);
                foreach (var cell in miniChessBoard.Cells)
                {
                    headers.Add("enpassent" + cell.notation);
                    if (enpassent != null && cell.x == xy[0] && cell.y == xy[1]) row.Add("1");
                    else row.Add("0");

                }
                */
                /*---------------------------------------------------------*/
                StringBuilder headerOutput = new StringBuilder();
                headerOutput.AppendLine(string.Join(",", headers.ToArray()));

                string url = Directory.GetCurrentDirectory();
                url = Path.GetFullPath(Path.Combine(url, @"..\..\..\..\"));

                url = Path.Combine(url + @"\" + databaseName) ;
                if (!File.Exists(url))
                {
                    // Create the CSV file
                    using (StreamWriter sw = File.CreateText(url))
                    {
                        sw.WriteLine(headerOutput.ToString());
                    }
                }

            }
            return rows;

        }
        public void writeToDatabase(string databaseName, List<string[]> rows)
        {
            foreach (var row in rows)
            {
                StringBuilder rowOutput = new StringBuilder();
                rowOutput.AppendLine(string.Join(",", row.ToArray()));

                string url = Directory.GetCurrentDirectory();
                url = Path.GetFullPath(Path.Combine(url, @"..\..\..\..\"));

                url = Path.Combine(url + databaseName) + ".csv";
                //if (!File.Exists(url)) throw new Exception("");

                File.AppendAllText(url, rowOutput.ToString());
            }



        }
        private string getOriginalSymbol(IPiece piece)
        {
            if (piece is IPawn && piece.pieceColor == PieceColor.white) return "P";
            if (piece is IPawn && piece.pieceColor == PieceColor.black) return "p";
            if (piece is IRook && piece.pieceColor == PieceColor.white) return "R";
            if (piece is IRook && piece.pieceColor == PieceColor.black) return "r";
            if (piece is IKnight && piece.pieceColor == PieceColor.white) return "N";
            if (piece is IKnight && piece.pieceColor == PieceColor.black) return "n";
            if (piece is IBishop && piece.pieceColor == PieceColor.white) return "B";
            if (piece is IBishop && piece.pieceColor == PieceColor.black) return "b";
            if (piece is IQueen && piece.pieceColor == PieceColor.white) return "Q";
            if (piece is IQueen && piece.pieceColor == PieceColor.black) return "q";
            if (piece is IKing && piece.pieceColor == PieceColor.white) return "K";
            if (piece is IKing && piece.pieceColor == PieceColor.black) return "k";
            throw new Exception("");
        }
    }
}
