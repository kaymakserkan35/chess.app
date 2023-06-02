using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Concretes;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using ChessPositionAnalyses;
using Microsoft.VisualBasic.FileIO;
using System.Formats.Asn1;
using System.Text;

class Program
{
    static MiniChessBoard miniChessBoard = new MiniChessBoard();


    public static void Main()
    {
        DataPreperator dataPreperator = new DataPreperator();
        List<string[]> lines = dataPreperator.readCsvFile("chessDataSample");
        lines = dataPreperator.analyseAndInitiateDatabase(lines, "chessDataSampleExpanded");
        dataPreperator.writeToDatabase("chessDataSampleExpanded", lines);

    }

}