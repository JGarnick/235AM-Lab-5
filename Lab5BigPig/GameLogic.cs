using System;
using static Lab5BigPig.GameActivity;

namespace Lab5BigPig
{
    class GameLogic
    {
        int dieResult = 0;
        Random rand = new Random();

        
        public int RollDice()
        {
            dieResult = rand.Next(1,9); //Roll the dice! 1-8
            return dieResult;  
        }

        public Player EndTurn(Player p1, Player p2) //Change whose turn it currently is
        {
            if(p1.IsTurn)
            {
                p1.IsTurn = false;
                if(!p2.ScoreLimitReached)
                    p2.IsTurn = true;
                else
                    p2.IsTurn = false;
            }
            else
            {
                p2.IsTurn = false;
                if (!p1.ScoreLimitReached)
                    p1.IsTurn = true;
                else
                    p1.IsTurn = false;
            }
            var winner = DeterminWinner(p1, p2);
            if (winner != null)
                return winner;
            else
                return null;

        }

        public void NewGame(Player p1, Player p2)
        {
            int turn = rand.Next(2); //randomly choose whose turn it is
            if (turn == 0)
            {
                p1.IsTurn = true;
                p2.IsTurn = false;
            }
                
            else
            {
                p2.IsTurn = true;
                p1.IsTurn = false;
            }
                

            p1.Score = 0;
            p2.Score = 0;
        }
        public void AddPoints(int points, Player player)
        {
            player.Score += points;
        }

        
        public Player DeterminWinner(Player p1, Player p2)
        {
            if(!p1.IsTurn && !p2.IsTurn)
            {
                if (p1.Score >= 100 || p2.Score >= 100)
                {
                    if (p1.Score > p2.Score)
                        return p1;
                    else
                        return p2;
                }
            }
            
            return null; 
        }

    }
}