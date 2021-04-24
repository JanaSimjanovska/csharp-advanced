using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WorkingDaysCheckerMethods
{
    public static class AppMethods
    {
        public static void CheckIfItsAWorkingDay(List<DateTime> enteredDates)
        {
            if (enteredDates.Count == 0) return;
            else
            {
                Console.WriteLine("\nHere are the results for the days you entered:");

                enteredDates.ForEach(x =>
                {
                    Console.WriteLine("\n-----------------------------------------------------------------------------------------------------\n");
                    Console.Write(string.Format("The date you entered is {0:dd-MMMM-yyyy}, {0:dddd}.", x));
                    if ((x.Day == 1 && x.Month == 1) || (x.Day == 7 && x.Month == 1) || (x.Day == 20 && x.Month == 4) || (x.Day == 1 && x.Month == 15) || (x.Day == 25 && x.Month == 5) || (x.Day == 3 && x.Month == 8) || (x.Day == 18 && x.Month == 9) || (x.Day == 12 && x.Month == 10) || (x.Day == 23 && x.Month == 10) || (x.Day == 8 && x.Month == 12))
                    {
                        if (x.DayOfWeek == DayOfWeek.Sunday || x.DayOfWeek == DayOfWeek.Saturday)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine(" This date falls on a holiday, but it's also the weekend, so no work, but also no long weekend this time. That kinda sucks :(\n");
                            Console.ResetColor();

                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(" This date is a holiday, sooo... That means NO WORK! :)\n");
                            Console.ResetColor();

                        }
                    }
                    else if (x.DayOfWeek == DayOfWeek.Sunday || x.DayOfWeek == DayOfWeek.Saturday)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" YAY, IT'S THE WEEKEND! That means NO WORK! :)\n");
                        Console.ResetColor();

                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" Rise and shine :) This is a working day :)\n");
                        Console.ResetColor();
                    }
                });
                Console.WriteLine("\n-----------------------------------------------------------------------------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Thank you for using our app :) Go ahead and let someone else check some dates :)\n ");
                Console.ResetColor();
                PressAnyKey();

            }


        }

        #region Date Validator
        public static List<DateTime> DateValidator(List<DateTime> dates)
        {

            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("Enter day of date you want to check:"); 

                    int dayOfDate = int.Parse(Console.ReadLine());

                    if (dayOfDate < 1 || dayOfDate > 31) // ovie uslovi kako sto primetiv mi se malku vishok, zashto so samiot catch si fakja exception ako ne e validen datumot, duri i pravi edna super plus proverka kako onaa zadacana od nekoj bonus so go imavme so proverka na datumi (na primer i da vnese juzerot dobar broj za den, ko na pr 31, ama za mesec vnese na primer 2, puka exception i toa bas so toj tekst, deka ne postoi datumot, i jas plus si dodadov moj tekst, da e po user friendly), ama jas pak gi staviv ovie, za da ne vnesuva juzerot sve, pa otposle da se proveruva, tuku za odma stom ja utne da mu se prikaze error i precizna poraka sto tocno utnal, pa ako sepak vnese datum kako 31 fevruari, kje si go ishendla catch-ot toa.
                    {
                        Console.WriteLine("Wrong input! The value for the day input must be between 1 and 31.");
                        PressAnyKey();

                        break;
                    }

                    Console.WriteLine("Enter month of date you want to check:");
                    int monthOfDate = int.Parse(Console.ReadLine());

                    if (monthOfDate < 1 || monthOfDate > 12)
                    {
                        Console.WriteLine("Wrong input! The value for the month input must be between 1 and 12.");
                        PressAnyKey();

                        break;
                    }

                    Console.WriteLine("Enter year of date you want to check:");
                    int yearOfDate = int.Parse(Console.ReadLine());

                    if (yearOfDate < 1900 || yearOfDate > 3000)
                    {
                        Console.WriteLine("The year can't be before 1900 and after 3000.\n" +
                            "Please try again.");
                        PressAnyKey();

                        break;
                    }

                    DateTime userDateTime = new DateTime(yearOfDate, monthOfDate, dayOfDate);
                    dates.Add(userDateTime);

                    Console.Clear();
                    RepeatDateValidator(dates);
                    

                    return dates;

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You probably didn't enter a valid number or there is no such date as the one you entered (for example 31 february, 31 june...). Let's see:");
                    Console.WriteLine($"\n{ex.Message}");
                    Console.WriteLine("\nOoops! ");
                    Console.WriteLine("\nTry again.\n");
                    PressAnyKey();
                    Console.ResetColor();
                }
            }
            return dates;
        }


        #endregion

        #region Press any key
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            char anyKey = Console.ReadKey(true).KeyChar;
        }

        #endregion

        #region Ask user if they want to repeat date input
        public static List<DateTime> RepeatDateValidator(List<DateTime> savedDates)
        {
            Console.WriteLine("Would you like to enter another date to check?");
            Console.WriteLine("Press Y if you do and N to continue.");
            ConsoleKeyInfo yesOrNo = Console.ReadKey(true);

            while (true)
            {
              
                while (yesOrNo.Key != ConsoleKey.Y && yesOrNo.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("Press Y if you do and N to continue.");
                    yesOrNo = Console.ReadKey(true);
                }

                if (yesOrNo.Key == ConsoleKey.Y)
                {
                    DateValidator(savedDates);
                    return savedDates;
                }
                    
                else if (yesOrNo.Key == ConsoleKey.N)
                    return savedDates;

                


                return savedDates;
            }

          

        }
        #endregion
    }
}
