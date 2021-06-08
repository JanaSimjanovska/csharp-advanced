using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TimeTracking.Services.Helpers
{
	public static class ValidationHelper
	{
		public static Regex OnlyLettersRegEx = new Regex("^[a-zA-Z]+$");
		public static int ValidateNumber(string number, int range)
		{
			int num = 0;
			bool isNumber = int.TryParse(number, out num);
			if (!isNumber) return -1;
			if (num <= 0 || num > range) return -1;
			return num;
		}

        public static string ValidateString(string str)
        {
            if (str.Length < 2) return null;
            int number;
            if (int.TryParse(str, out number)) return null;
            return str;
        }
	
        public static string ValidateUsername(string username)
		{
			if (username.Length < 5) return null;
			return username;

		}
		public static string ValidatePassword(string password) 
		{
			if (password.Length < 6) return null;

			bool isUpper = false;
			foreach(char item in password)
            {
				isUpper = Char.IsUpper(item);
				if (isUpper) return password;
			}
			if (!isUpper) return null;

			int num;
			bool isNum = false;
			foreach (char item in password)
			{
				isNum = int.TryParse(item.ToString(), out num);
				if (isNum) return password;
			}
			if (!isNum) return null;
			return password;
		}

		public static string ValidateFirstName(string firstName)
        {
			if (firstName.Length < 2) return null;
            if (!OnlyLettersRegEx.IsMatch(firstName)) return null;
            return firstName;
		}

		public static string ValidateLastName(string lastName)
		{
			if (lastName.Length < 2) return null;
            if (!OnlyLettersRegEx.IsMatch(lastName)) return null;
            return lastName;
		}

		public static int ValidateAge(string age)
        {
			bool isNum = int.TryParse(age, out int parsedAge);

			if (!isNum) return 0;

			if (parsedAge < 18 || parsedAge > 120) return 0;

			return parsedAge;
        }


	}
}
