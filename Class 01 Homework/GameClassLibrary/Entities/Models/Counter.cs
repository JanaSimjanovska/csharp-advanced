using System;
using System.Collections.Generic;
using System.Text;

namespace GameClassLibrary.Entities.Models
{
    public class Counter
    {
        public int PlayerWins { get; set; }
        public int AppWins { get; set; }
        public int GamesPlayed { get; set; }
        public Counter()
        {
        }

        public Counter(int gamesPlayed, int playerWins, int appWins)
        {
            GamesPlayed = gamesPlayed;
            PlayerWins = playerWins;
            AppWins = appWins;
        }

        public void Statistics()
        {
            if(GamesPlayed == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nThere is no stats available. No games have been played.");
                Console.ResetColor();

            }

            else
            {
                int playerWinsPercentage = (int)((double)PlayerWins / GamesPlayed * 100);
                int AppWinsPercentage = (int)((double)AppWins / GamesPlayed * 100);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nNumber og games played: {GamesPlayed}");
                Console.WriteLine($"Number of player wins: {PlayerWins}");
                Console.WriteLine($"Number of app wins: {AppWins}");
                Console.WriteLine($"Percentage of player wins: {playerWinsPercentage} %");
                Console.WriteLine($"Percentage of app wins: {AppWinsPercentage} %");
                Console.ResetColor();
            }
            
        }
    }
}
