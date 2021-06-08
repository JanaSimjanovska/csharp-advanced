using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TimeTracking.Domain.Core.Entities;
using TimeTracking.Domain.Core.Enums;
using TimeTracking.Domain.Core.Interfaces;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Services.Interfaces;
using Activity = TimeTracking.Domain.Core.Entities.Activity;

namespace TimeTracking.Services.Services.Implementations
{
    public class UIService : IUIService
    {
        public List<string> LoginRegisterMenuItems { get; set; }
        public List<string> MainMenuItems { get; set; }
        public List<string> TrackActivityMenuItems { get; set; }
        public List<string> AccountMenuItems { get; set; }
        public List<string> UserStatisticsMenuItems { get; set; }
        public List<string> BookGenreMenuItems { get; set; }
        public List<string> TypeOfHobbyMenuItems { get; set; }
        public List<string> TypeOfExerciseMenuItems { get; set; }
        public List<string> WorkplaceMenuItems { get; set; }

		public int ChooseMenu<T>(List<T> items)
		{
            
            while (true)
			{
				Console.WriteLine("\nEnter a number to choose one of the following:\n");
				for (int i = 0; i < items.Count; i++)
				{
					Console.WriteLine($"{i + 1}) {items[i]}");
				}
				int choice = ValidationHelper.ValidateNumber(Console.ReadLine(), items.Count);
				if (choice == -1)
				{
					MessageHelper.Color("[Error] Input incorrect. Please try again", ConsoleColor.Red);
					MessageHelper.PressAnyKey();
					Console.Clear();
					continue;
				}
				Console.Clear();

				return choice;
			}
		}

        #region Menu Panels
        public int LoginRegisterMenu()
		{
			LoginRegisterMenuItems = new List<string>() { "Log In", "Register" };
			Console.Clear();
			MessageHelper.Color($"\nWelcome to our cool Time Tracking App", ConsoleColor.Green);
			return ChooseMenu(LoginRegisterMenuItems);
		}

		public User RegisterMenu()
        {

			Console.WriteLine("Enter first name (must be at least 2 characters long):");
			string firstName = ValidationHelper.ValidateFirstName(Console.ReadLine());
			Console.WriteLine("Enter last name (must be at least 2 characters long):");
			string lastName = ValidationHelper.ValidateLastName(Console.ReadLine());
			Console.WriteLine("Enter username (must be at least 5 characters long):");
			string username = ValidationHelper.ValidateUsername(Console.ReadLine());
			Console.WriteLine("Enter password (must be at least 6 characters long, must contain at least one capital letter, and at least one number.):");
			string password = ValidationHelper.ValidatePassword(Console.ReadLine());
			Console.WriteLine("Enter age (must be minimum 18, maximum 120, numbers only input):");
			int age = ValidationHelper.ValidateAge(Console.ReadLine());

			User newUser = new User(firstName, lastName, age, username, password);

			return newUser;
		}

		public int MainMenu()
		{
			MainMenuItems = new List<string>() { "Track activity", "Change account info", "View stats", "Log Out" };
			
			return ChooseMenu(MainMenuItems);
		}


		public int AccountMenu()
		{
			AccountMenuItems = new List<string>() { "Change First Name", "Change Last Name", "Change Password", "Deactivate Account", "Back to Main Menu" };
			return ChooseMenu(AccountMenuItems);
		}

		public int StatsMenu()
		{
			UserStatisticsMenuItems = new List<string>() { "Tracked reading stats", "Tracked exercises stats", "Tracked work stats", "Tracked hobbies stats", "All recorded activities stats", "Back to Main Menu" };
			return ChooseMenu(UserStatisticsMenuItems);
		}

		public int TrackActivityMenu()
		{
			TrackActivityMenuItems = new List<string>();
			Console.WriteLine("Choose the type of activity that you tracked -");
			foreach (string activity in Enum.GetNames(typeof(TypeOfActivity)))
			{
				TrackActivityMenuItems.Add(activity);
			}
			return ChooseMenu(TrackActivityMenuItems);
		}

		

		public int BookGenreMenu()
		{

			BookGenreMenuItems = new List<string>();
			foreach (string bookGenre in Enum.GetNames(typeof(TypeOfLiterature)))
			{
				BookGenreMenuItems.Add(bookGenre);
			}
			return ChooseMenu(BookGenreMenuItems);

		}

		public int TypeOfHobbyMenu()
		{

			TypeOfHobbyMenuItems = new List<string>();
			foreach (string hobby in Enum.GetNames(typeof(TypeOfHobby)))
			{
				TypeOfHobbyMenuItems.Add(hobby);
			}
			return ChooseMenu(TypeOfHobbyMenuItems);

		}

		public int ExerciseTypeMenu()
		{
			TypeOfExerciseMenuItems = new List<string>();
			foreach (string exerciseType in Enum.GetNames(typeof(TypeOfExercise)))
			{
				TypeOfExerciseMenuItems.Add(exerciseType);
			}
			return ChooseMenu(TypeOfExerciseMenuItems);

		}

		public int WorkplaceMenu()
		{
			WorkplaceMenuItems = new List<string>();
			foreach (string workplace in Enum.GetNames(typeof(Workplace)))
			{
				WorkplaceMenuItems.Add(workplace);
			}
			return ChooseMenu(WorkplaceMenuItems);

		}
        #endregion

        #region Activity tracking
        public static TimeSpan ToggleStopwatch()
		{
			Console.Clear();
			bool done = false;

			Console.WriteLine("Press 'Enter' to start/stop tracking your activity");
			while (Console.ReadKey(true).Key != ConsoleKey.Enter)
			{
				Console.Clear();
				Console.WriteLine("You didn't press enter");
			}

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			Console.Clear();
			Console.WriteLine("Activity tracking started!");

			while (!done)
			{

				if (Console.ReadKey(true).Key != ConsoleKey.Enter)
				{
					Console.Clear();
					Console.WriteLine("Activity tracking still active. Press enter to stop tracking activity.");
					continue;
				}
				done = true;
				stopWatch.Stop();

			}
            Console.Clear();
			Console.WriteLine("Activity tracking finished!");
			MessageHelper.PressAnyKey();
			return stopWatch.Elapsed;
		}
		
		public Activity TrackActivity()
        {
			int chosenActivity = TrackActivityMenu();
			TimeSpan activityDuration = ToggleStopwatch();

			Activity trackedActivity = null;
			switch (chosenActivity)
            {
				case 1:
					while (true)
					{

						Reading trackedReading = TrackedReading(activityDuration);
						if (trackedReading == null)
						{
							MessageHelper.Color("[Error] Invalid reading info entered! Please try again", ConsoleColor.Red);
							MessageHelper.PressAnyKey();
							continue;
						}
						else
							trackedActivity = trackedReading;
                            return trackedActivity;
                    }

				case 2:
					Exercise trackedExercise = TrackedExercise(activityDuration);
					trackedActivity = trackedExercise;
					return trackedActivity;
				case 3:
					Work trackedWork = TrackedWork(activityDuration);
					trackedActivity = trackedWork;
					return trackedActivity;
				case 4:
					Hobby trackedHobby = TrackedHobby(activityDuration);
					trackedActivity = trackedHobby;
					return trackedActivity;
				default:
					return null;
			}

		}
		
		public Reading TrackedReading(TimeSpan duration)
        {
			Console.Clear();
			Console.WriteLine("What genre was the book you were reading?");
			TypeOfLiterature bookGenre = (TypeOfLiterature)BookGenreMenu();
			Console.WriteLine("Enter the title of the book you were reading: (Can't leave empty)");
			string bookTitle = Console.ReadLine();
			Console.WriteLine("Enter the author of the book you were reading: (Input must be at least 2 characters long)");
			string bookAuthor = ValidationHelper.ValidateString(Console.ReadLine());

            Console.WriteLine("How many pages did you read? (Input must be a number from 1 to 20000)");
			int pagesRead = ValidationHelper.ValidateNumber(Console.ReadLine(), 20000);

			if (bookTitle == "" || bookAuthor == null || pagesRead == -1) return null;
			
			Reading readingTracked = new Reading(duration, bookGenre, bookTitle, bookAuthor, pagesRead);

			return readingTracked;
		}

		public Hobby TrackedHobby(TimeSpan duration)
		{
			Console.Clear();
			Console.WriteLine("What hobby did you track?");
			TypeOfHobby hobbyType = (TypeOfHobby)TypeOfHobbyMenu();
			Hobby hobbyTracked = new Hobby(duration, hobbyType);

			return hobbyTracked;
		}

		public Exercise TrackedExercise(TimeSpan duration)
		{
			Console.Clear();
			Console.WriteLine("What type of exercise did you track?");
			TypeOfExercise exerciseType = (TypeOfExercise)ExerciseTypeMenu();
			Exercise exerciseTracked = new Exercise(duration, exerciseType);

			return exerciseTracked;
		}

		public Work TrackedWork(TimeSpan duration)
		{

			Console.Clear();
			Console.WriteLine("Did you work from home, or the office?");
			Workplace workplace = (Workplace)WorkplaceMenu();
			Work workTracked = new Work(duration, workplace);

			return workTracked;
		}

		#endregion

	}

}
