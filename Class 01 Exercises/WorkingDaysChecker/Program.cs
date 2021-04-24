using System;
using System.Collections.Generic;
using WorkingDaysCheckerMethods;

namespace WorkingDaysChecker
{
    class Program
    {
        static void Main(string[] args)
        {

            // ### Create a console application that checks if a day is a working day 🔹
            // * The app should request for a user to enter a date as an input or multiple inputs
            // * The app should then open and see if the day is a working day
            // * It should show the user a message whether the date they entered is working or not
            // * Weekends are not working
            // * 1 January, 7 January, 20 April, 1 May, 25 May, 3 August, 8 September, 12 October, 23 October and 8 December are not working days as well
            // * It should ask the user if they want to check another date
            // * Yes - the app runs again
            // * No - the app closes





           



            // Top si raboti, samo smisli dali sakas da ja izgasis skroz otkako kje mu gi izlistas site vneseni datumi na juzerot, ili pa neso kje stais press any key i kje pocne od novo. ISTO TAKA, ne e ic sredena, vidi dali tuk i tamu mozes da stavis nekoj konzol klir, samo vnimavaj da ne izmestis neso, poso toa ednas vekje se desi, i ako imas vreme stai nekoi boicki.


            try
            {
                while (true)
                {
                    List<DateTime> dates = new List<DateTime>();

                    AppMethods.CheckIfItsAWorkingDay(AppMethods.DateValidator(dates));
                }
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops! Something went wrong.");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try again.");
                Console.ResetColor();
            }


            Console.ReadLine();

        }
    }
}
