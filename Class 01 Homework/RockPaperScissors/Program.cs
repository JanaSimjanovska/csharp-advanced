using System;
using GameMethods;
using GameClassLibrary.Entities.Enums;
using GameClassLibrary.Entities.Models;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // There should be a menu with three options:
            // - Play
            //      a. The user picks rock paper or scissors option
            //      b. The application picks rock paper scissors on random
            //      c. The user pick and the application pick are shown on the screen
            //      d. The application shows the winner
            //      e. The application saves 1 score to the user or the computer in the background
            //      f. When the user hits enter it returns to the main menu
            // - Stats
            //      a. It shows how many wins the user and how many wins the computer has
            //      b. It shows percentage of the wins and loses of the user
            //      c. When the user hits enter it returns to the main menu
            // - Exit
            //      a. It closes the application

            Counter statsCounter = new Counter();
            

            while (true)
            {
                try
                {

                    RockPaperScissorsMethods.MainMenu(statsCounter);
                   

                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOops. Looks like something went wrong.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("NVM. Just give it another shot :)");
                    Console.ResetColor();

                }
            }

            
        }



    }
}
