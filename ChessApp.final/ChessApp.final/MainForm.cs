

using ChessApp.final.Controls;
using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Abstractions.Pieces;
using ChessApp.final.MiniChess.Concretes;
using ChessApp.final.MiniChess.Concretes.MoveTypes;

namespace ChessApp.final
{
    public partial class MainForm : Form
    {
        AGame game;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            game = new Game(chessBoardControl1, null, null);
            chessBoardControl1.loadGame(game);
            
        }



        private void loadPosition_Click(object sender, EventArgs e)
        {
            string fen = "r1n1k2r/2qb1pp1/1p2p3/p2pP1Np/2pP3P/B1Q3PB/4KP2/RR6 b kq - 5 22";

            chessBoardControl1.loadPosition(new Position(fen));
        }

        private void loadGame_Click(object sender, EventArgs e)
        {
            string fen = "4br2/4br2/1p1p3k/p1pPp1p1/P1Pn2Pp/1PK1BP1P/3N1R2/1B3R2 b - - 39 57";
             game = new Game(fen, chessBoardControl1, null, null);
            chessBoardControl1.loadGame(game);

        }

        private void autoPlay_Click_1(object sender, EventArgs e)
        {

            AMove lastMove = null;


            List<AMove> moves = chessBoardControl1.getAlPossibleMovesForCurrentPosition();
            if (moves.Count == 0) return;
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                lastMove = moves.FirstOrDefault(m => m is CastlingMove);
                if (lastMove == null) lastMove = moves.FirstOrDefault(m => m is PromotionMove<IQueen>);
                if (lastMove == null)
                {
                    int a = random.Next(0, moves.Count);
                    lastMove = moves[a];
                }
                game.makeMove(lastMove);
                Console.WriteLine(lastMove.moveSymbol);
                Console.WriteLine(game.getLastPosition().useThisMethodJustWannaSeePositionInCode());
                //Thread.Sleep(2000);
                moves = chessBoardControl1.getAlPossibleMovesForCurrentPosition();
                if (moves.Count == 0) break;

            }







        }

        private void getAlLines_Click(object sender, EventArgs e)
        {
            Console.WriteLine(game.getAllLines());
        }

        private void positionAnalyses_Click(object sender, EventArgs e)
        {
            string f = "r1n1k2r/2qb1pp1/1p2p3/p2pP1Np/2pP3P/B1Q3PB/4KP2/RR6 b kq - 5 22";
            Position position = new Position(f);
            chessBoardControl1.loadPosition(position);
            MiniChessBoard miniChessBoard = new MiniChessBoard();
            miniChessBoard.loadPosition(position);
            /*-----------------------------*/
            string pos = position.getPositionInString();
            pos += "-";
            for (int i = 0; i < miniChessBoard.Cells.Count; i++)
            {

                ICell cell = miniChessBoard.Cells[i];
                int wht = 0; int blc = 0;

                miniChessBoard.WhitePieces.ForEach(piece =>
                {
                    if (piece.currentCoor == null) return;
                    bool tf = miniChessBoard.canControl(piece, cell);
                    if (tf) wht += 1;

                });
                miniChessBoard.BlackPieces.ForEach(piece =>
                {
                    if (piece.currentCoor == null) return;
                    bool tf = miniChessBoard.canControl(piece, cell);
                    if (tf) blc += 1;

                });
                pos += "(" + cell.notation + ")";
                pos += wht.ToString(); pos += "-";
                pos += "(" + cell.notation + ")";
                pos += blc.ToString(); pos += "-";
            }

            Console.WriteLine(pos);
        }
    }
}