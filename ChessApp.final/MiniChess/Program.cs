using ChessApp.final.MiniChess.Concretes.MoveTypes;
using ChessApp.final.MiniChess.Concretes;

class Program
{
    public static void Main()
    {
        Thread thread1 = new Thread(() =>
        {
            MiniChessBoard miniChessBoard = new MiniChessBoard();
            Game game = new Game(miniChessBoard, null, null);
            miniChessBoard.loadGame(game);


            AMove lastMove = null;
            List<AMove> moves = miniChessBoard.getAlPossibleMovesForCurrentPosition();
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int a = random.Next(0, moves.Count);
                lastMove = moves[a];

                game.makeMove(lastMove);
                Console.WriteLine(lastMove.moveSymbol);
                Console.WriteLine(game.getLastPosition().useThisMethodJustWannaSeePositionInCode());

                //Thread.Sleep(100);
                moves = miniChessBoard.getAlPossibleMovesForCurrentPosition();
                if (moves.Count == 0) break;
            }
        });
        Thread thread2 = new Thread(() =>
        {
            MiniChessBoard miniChessBoard = new MiniChessBoard();
            Game game = new Game(miniChessBoard, null, null);
            miniChessBoard.loadGame(game);


            AMove lastMove = null;
            List<AMove> moves = miniChessBoard.getAlPossibleMovesForCurrentPosition();
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int a = random.Next(0, moves.Count);
                lastMove = moves[a];

                game.makeMove(lastMove);
                Console.WriteLine(lastMove.moveSymbol);
                Console.WriteLine(game.getLastPosition().useThisMethodJustWannaSeePositionInCode());

                //Thread.Sleep(100);
                moves = miniChessBoard.getAlPossibleMovesForCurrentPosition();
                if (moves.Count == 0) break;
            }
        });
        Thread thread3 = new Thread(() =>
        {
            MiniChessBoard miniChessBoard = new MiniChessBoard();
            Game game = new Game(miniChessBoard, null, null);
            miniChessBoard.loadGame(game);


            AMove lastMove = null;
            List<AMove> moves = miniChessBoard.getAlPossibleMovesForCurrentPosition();
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int a = random.Next(0, moves.Count);
                lastMove = moves[a];

                game.makeMove(lastMove);
                Console.WriteLine(lastMove.moveSymbol);
                Console.WriteLine(game.getLastPosition().useThisMethodJustWannaSeePositionInCode());

                //Thread.Sleep(100);
                moves = miniChessBoard.getAlPossibleMovesForCurrentPosition();
                if (moves.Count == 0) break;
            }
        });



        thread1.Start();
        //thread2.Start();
       // thread3.Start();

    }

}