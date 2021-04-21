using System;
using System.Collections.Generic;
using System.Text;
using GameClassLibrary.Entities.Enums;
using GameClassLibrary.Entities.Models;
using System.Linq;

namespace GameMethods
{
    public static class RockPaperScissorsMethods
    {
        #region Main Menu Text

        public static void MainMenuText()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===============================================");
            Console.WriteLine("======== ROCK - PAPER - SCISSORS GAME =========");
            Console.WriteLine("===============================================\n");
            Console.WriteLine("Choose one of the following numbers:");
            Console.WriteLine("[1] PLAY");
            Console.WriteLine("[2] STATS");
            Console.WriteLine("[3] EXIT GAME");
            Console.WriteLine("\n===============================================");
            Console.WriteLine("===============================================");
            Console.ResetColor();
        }

        #endregion


        #region Main Menu

        public static Counter MainMenu(Counter statsCounter)
        {
           while (true)
           {
                MainMenuText();

                int userChoice = int.Parse(Console.ReadLine());




                switch (userChoice)
                {
                    case 1:
                        Play(statsCounter);
                        return statsCounter;
                    case 2:
                        Stats(statsCounter);
                        statsCounter.AppWins = 0;
                        statsCounter.PlayerWins = 0;
                        statsCounter.GamesPlayed = 0;
                        return statsCounter;
                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n=========================================================================");
                        Console.WriteLine("Thank you for playing :) Let someone else have a go :) Until next time :)");
                        Console.WriteLine("=========================================================================\n");

                        Console.ResetColor();


                        Console.WriteLine("\nPress enter to go back to main menu");

                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong key pressed!");
                            Console.WriteLine("Press enter to go back to main menu");
                        }

                        Console.Clear();

                        statsCounter.AppWins = 0;
                        statsCounter.PlayerWins = 0;
                        statsCounter.GamesPlayed = 0;
                        return statsCounter;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOops. Looks like you didn't enter 1, 2 or 3... Please try again.");
                        Console.ResetColor();
                        break;
                }

                return statsCounter;
            }
            
        }

        #endregion


        #region Game Menu Text

        public static void GameMenuText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===============================================\n");
            Console.WriteLine("Choose one of the following numbers:");
            Console.WriteLine("[1] ROCK");
            Console.WriteLine("[2] PAPER");
            Console.WriteLine("[3] SCISSORS");
            Console.WriteLine("\n===============================================");
            Console.ResetColor();
        }

        #endregion


        #region User's turn choice
        public static Choice UsersTurn()
        {
            while (true)
            {
                try
                {

                    Choice rockPaperOrScissors = new Choice();

                    int userChoice = int.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    switch (userChoice)
                    {
                        case 1:

                            Console.Clear();
                            rockPaperOrScissors = (Choice)1;
                            Console.WriteLine($"You chose {Choice.Rock}.");
                            Console.ResetColor();
                            return rockPaperOrScissors;


                        case 2:

                            Console.Clear();
                            rockPaperOrScissors = (Choice)2;
                            Console.WriteLine($"You chose {Choice.Paper}.");
                            Console.ResetColor();
                            return rockPaperOrScissors;


                        case 3:

                            Console.Clear();
                            rockPaperOrScissors = (Choice)3;
                            Console.WriteLine($"You chose {Choice.Scissors}.");
                            Console.ResetColor();
                            return rockPaperOrScissors;


                        default:

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nOops. Looks like you didn't enter 1, 2 or 3... Please try again.");
                            GameMenuText();
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Looks like you didn't enter the correct number... Please try again.");
                    GameMenuText();
                }

            }
        }

        #endregion


        #region App's turn choice
        public static Choice AppsTurn()
        {

            Console.WriteLine("Please wait... The app is choosing...");


            Random random = new Random();

            Choice appsChoice = (Choice)random.Next(1, 4);


            Console.ForegroundColor = ConsoleColor.Magenta;

            switch (appsChoice)
            {
                case (Choice)1:
                    Console.WriteLine($"The app chose {Choice.Rock}.");
                    Console.ResetColor();
                    break;

                case (Choice)2:
                    Console.WriteLine($"The app chose {Choice.Paper}.");
                    Console.ResetColor();
                    break;

                case (Choice)3:
                    Console.WriteLine($"The app chose {Choice.Scissors}.");
                    Console.ResetColor();
                    break;
               
            }

            return appsChoice;

        }

        #endregion


        #region Rock-Paper-Scissors - Behind the scenes

        public static Counter WinnerLoser(Choice usersChoice, Choice appsChoice, Counter statsCounter)
        {
            //int playerWinsCounter = 0;
            //int appWinsCounter = 0;
            //int gamesPlayedCounter = 0;

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (usersChoice)
            {
                case (Choice)1:


                    if(appsChoice == (Choice)1)
                        Console.WriteLine("IT'S A TIE. Both the player and the app chose rock.");

                    else if(appsChoice == (Choice)2)
                    {
                        statsCounter.AppWins += 1;
                        Console.WriteLine("Paper covers rock. The app won! Better luck next time :(");
                    }

                    else
                    {
                        statsCounter.PlayerWins += 1;
                        Console.WriteLine("Rock crushes scissors. YOU WIN :) YAAAAY!");
                    }

                    Console.ResetColor();


                    statsCounter.GamesPlayed += 1;

                    return statsCounter;

                case (Choice)2:


                    if (appsChoice == (Choice)1)
                    {
                        statsCounter.PlayerWins += 1;
                        Console.WriteLine("Paper covers rock. YOU WIN :) YAAAAY!");
                    }

                    else if (appsChoice == (Choice)2)
                        Console.WriteLine("IT'S A TIE. Both the player and the app chose paper.");

                    else
                    {
                        statsCounter.AppWins += 1;
                        Console.WriteLine("Scissors cuts paper. The app won. Better luck next time :(");
                    }

                    Console.ResetColor();

                    statsCounter.GamesPlayed += 1;                   

                    return statsCounter;

                case (Choice)3:


                    if (appsChoice == (Choice)1)
                    {
                        statsCounter.AppWins += 1;
                        Console.WriteLine("Rock crushes scissors. The app won. Better luck next time :(");
                    }

                    else if (appsChoice == (Choice)2)
                    {
                        statsCounter.PlayerWins += 1;
                        Console.WriteLine("Scissors cuts paper. YOU WIN :) YAAAAY!");
                    }

                    else
                        Console.WriteLine("IT'S A TIE. Both the player and the app chose scissors.");

                    Console.ResetColor();

                    statsCounter.GamesPlayed += 1;


                    return statsCounter;

                default:
                    Console.ResetColor();
                    Console.WriteLine("Oops! Something went wrong... Please try again");
                    return statsCounter;

            }
        }

        #endregion


        #region Play method

        public static Counter Play(Counter statsCounter)
        {
            Console.Clear();


            GameMenuText();
          
            statsCounter = WinnerLoser(UsersTurn(), AppsTurn(), statsCounter);

            Console.WriteLine("\nPress enter to go back to main menu");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) 
            {
                Console.Clear();
                Console.WriteLine("Wrong key pressed!");
                Console.WriteLine("Press enter to go back to main menu");
            }

            Console.Clear();
            return statsCounter;
        }
        #endregion


        #region Statistics method

        public static void Stats(Counter statsCounter)
        {
            Console.Clear();
            statsCounter.Statistics(); 

            Console.WriteLine("\nPress enter to go back to main menu");

            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Wrong key pressed!");
                Console.WriteLine("Press enter to go back to main menu");
            }

            Console.Clear();
        }

        #endregion

    }
}
