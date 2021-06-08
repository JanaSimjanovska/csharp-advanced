using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracking.Services.Helpers
{
	public static class MessageHelper
	{
		public static void Color(string message, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}

		public static void PressAnyKey()
		{
			Console.WriteLine("\nPress any key");
			char anyKey = Console.ReadKey(true).KeyChar;
		}
	}


}
