using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02ClassLibrary
{
    public static class Task02StaticClassForExtensionMethods
    {
        public static string GetFirstLetter(this string inputString)
        {
            if(inputString == "")
            {
                return "Sorry, input string must contain at least one letter.";
            }

            string resultString = inputString.Substring(0, 1);

            return resultString;
        }

        public static string GetLastLetter(this string inputString)
        {
            if (inputString == "")
            {
                return "Sorry, input string must contain at least one letter.";
            }

            string resultString = inputString.Substring(inputString.Length - 1);

            return resultString;
        }

        public static bool CheckIfEven(this int inputInt)
        {
            if (inputInt % 2 == 0)
            {
                return true;
            }
            else
                return false;
        }

        public static List<T> GetNFirst<T>(this List<T> listToCheck, int inputInt)
        {

            if (inputInt > listToCheck.Count)
            {
                throw new Exception();
            }

            listToCheck = listToCheck.Take(inputInt).ToList();
            listToCheck.ForEach(x => Console.WriteLine(x));
            return listToCheck;
        }
    }
}
