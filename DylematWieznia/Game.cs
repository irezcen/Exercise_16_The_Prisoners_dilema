using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class Game
    {
        public static void Run()
        {
            int rounds = 30; // how many rounds
            int score1 = 10; // both players cooperate
            int score2 = 15; // one player betrays - winner
            int score3 = -10; // one player betrays - loser
            int score4 = 0; // both players betray
            // note: it can be shown mathematically that this game is non-trivial if: 
            // 1) score2 > score1 > score4 > score3, AND
            // 2) 2*score1 > score2 + score3


            Player player1 = new Player(new Strategy1());
            Player player2 = new Player(new Strategy2());
            Player player3 = new Player(new Strategy4());
            Player player4 = new Player(new Strategy4());
            Player player5 = new Player(new Strategy5());

            Player p1 = player1;
            Player p2 = player2;


            for (int j = 0; j < 10; j++)
            {
                if (j < 4)
                {
                    p1 = player1;
                }
                if (j >= 4 && j < 7) p1 = player2;
                if (j >= 7 && j < 9) p1 = player3;
                if (j == 9) p1 = player4;

                if (j == 0) p2 = player2;
                if (j == 1 || j == 4) p2 = player3;
                if (j == 2 || j == 5 || j == 7) p2 = player4;
                if (j == 3 || j == 6 || j == 8 || j == 9) p2 = player5;
                for (int i = 0; i < rounds; i++)
                {
                    bool move1 = p1.GetNextMove();
                    bool move2 = p2.GetNextMove();

                    if (move1 && move2) // both players cooperated
                    {
                        // update score
                        p1.Score += score1;
                        p2.Score += score1;
                        // update players' knowledge about their partner
                        p1.PartnerMoves.Add(true);
                        p2.PartnerMoves.Add(true);
                    }
                    else if (move1) // player2 betrayed player1
                    {
                        p1.Score += score3;
                        p2.Score += score2;
                        p1.PartnerMoves.Add(false);
                        p2.PartnerMoves.Add(true);
                    }
                    else if (move2) // player1 betrayed player2
                    {
                        p1.Score += score2;
                        p2.Score += score3;
                        p1.PartnerMoves.Add(true);
                        p2.PartnerMoves.Add(false);
                    }
                    else // both players betrayed
                    {
                        p1.Score += score4;
                        p2.Score += score4;
                        p1.PartnerMoves.Add(false);
                        p2.PartnerMoves.Add(false);
                    }
                }
                p1.PartnerMoves.Clear();
                p2.PartnerMoves.Clear();
            }
            Console.WriteLine("Player1 score: " + player1.Score);
            Console.WriteLine("Player2 score: " + player2.Score);
            Console.WriteLine("Player3 score: " + player3.Score);
            Console.WriteLine("Player4 score: " + player4.Score);
            Console.WriteLine("Player5 score: " + player5.Score);
        }
    }
}
