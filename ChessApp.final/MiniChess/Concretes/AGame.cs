using ChessApp.final.MiniChess.Abstractions;
using ChessApp.final.MiniChess.Concretes.MoveTypes;
using MiniChess.Abstractions;
using static ChessApp.final.MiniChess.Concretes.MoveTypes.AMove;

namespace ChessApp.final.MiniChess.Concretes
{
    public abstract class AGame : IGame
    {
       
        public IPlayer playerWhite { get; }

        public IPlayer playerBlack { get; }
        Result IGame.result { get; set; }

        protected AMove lastExecutedMove;
        protected IChessBoard chessBoard;
        public AGame(IChessBoard chessBoard, Player? playerWhite, Player? playerBlack)
        {
            this.chessBoard = chessBoard;
            //lastExecutedMove = new EmtyMove();
            if (playerWhite != null) this.playerWhite = playerWhite;
            else
            {
                //machine..
                this.playerWhite = new Player();
            }
            if (playerBlack != null) this.playerBlack = playerBlack;
            else
            {   //machine..
                this.playerBlack = new Player();
            }
        }

        private EmtyMove getFirstNode()
        {

            AMove m = lastExecutedMove;
            while (!(m is EmtyMove))
            {
                m = m.previous;
            };
            return (EmtyMove)m;

        }
        private string getAllLines(AMove firstNode)
        {
            string res = "";
            AMove m = firstNode;
            while (m.next != null)
            {
                res += m.moveSymbol + " ";
                if (m.variants.Count != 0)
                {
                    res += "\n" + "[";
                    foreach (var vr in m.variants) res += getAllLines(vr);
                    res += "]" + "\n";
                }
                m = m.next;
            }
            {
                // for last move !
                res += m.moveSymbol;
                if (m.variants.Count != 0)
                {
                    res += "\n" + "[";
                    foreach (var vr in m.variants) res += getAllLines(vr);
                    res += "]" + "\n";
                }
                res += ";";
            }
            return res;
        }
        public string getAllLines()
        {
            return getAllLines(getFirstNode());
        }


        /// <summary>
        /// oyuna hamle eklenir. satranc tahtası yapılan hamle ile degistirilir.
        /// </summary>
        /// <param name="move"> legal bir hamle olmak zorundadır.</param>
        public void makeMove(AMove move)
        {
            move.execute(chessBoard);
            addMove(move);
            chessBoard.currentPosition = lastExecutedMove._positionAfterMoveExecuted;
            




        }
        /// <summary>
        /// hamle varynta eklenecek ise varyanta eklenir. yoksa ana varyanta eklenir. hamle.next hamle.previous bağantıları yapılır.
        /// </summary>
        /// <param name="move"></param>
        private void addMove(AMove move)
        {

            if (lastExecutedMove.next == null)
            {
                lastExecutedMove.next = move;
                move.previous = lastExecutedMove;
                lastExecutedMove = move;
                /*-------------------------------*/
                // position atamaları move generator  icinde yapılmaktadır

            }
            else
            {
                AMove moveForVariants = lastExecutedMove.next;
                if (!moveForVariants.variants.Any(m => m.pieceCoorX0 == move.pieceCoorX0 && m.pieceCoorY0 == move.pieceCoorY0))
                {
                    moveForVariants.variants.Add(move);
                    move.previous = lastExecutedMove;
                    lastExecutedMove = move;
                    // position atamaları move generator  icinde yapılmaktadır

                }
                else lastExecutedMove = moveForVariants.variants.First(m => m.pieceCoorX0 == move.pieceCoorX0 && m.pieceCoorY0 == move.pieceCoorY0);

            }

        }

        public void back(IChessBoard chessBoard)
        {

            if (lastExecutedMove is EmtyMove) return;
            lastExecutedMove.getBackMove(chessBoard);
            lastExecutedMove = lastExecutedMove.previous;

            chessBoard.currentPosition = lastExecutedMove._positionAfterMoveExecuted;
        }
        public void next(IChessBoard chessBoard)
        {
            if (lastExecutedMove.next == null) return;
            lastExecutedMove.next.execute(chessBoard);
            lastExecutedMove = lastExecutedMove.next;
            chessBoard.currentPosition = lastExecutedMove._positionAfterMoveExecuted;

        }
        public void backBack(IChessBoard chessBoard)
        {
            while (!(lastExecutedMove is EmtyMove)) back(chessBoard);
        }
        public void nextNext(IChessBoard chessBoard)
        {
            while (lastExecutedMove.next != null) next(chessBoard);
        }

        public Position getLastPosition()
        {
            return lastExecutedMove._positionAfterMoveExecuted;
        }

      
    }
}
