using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TimeTracking.Domain.Core.Entities;
using TimeTracking.Services.Helpers;
using TimeTracking.Services.Services.Implementations;
using TimeTracking.Services.Services.Interfaces;
using Activity = TimeTracking.Domain.Core.Entities.Activity;

namespace TimeTracking.App
{
    class Program
    {
        private static IUserService<User> _userService = new UserService<User>();
        private static IUIService _uiService = new UIService();
        private static User _currentUser;

        public static void Seed()
        {
            if (_userService.IsDbEmpty())
            {
                _userService.Register(new User("Test", "Testovski", 25, "username", "Passw0rd"));
            }
        }


        static void Main(string[] args)
        {

            try
            {
                Seed();

                while (true)
                {

                    if (_currentUser != null)
                    {
                        AttemptsChecker.AttemptsCounter = 1;
                        int mainMenuItemChoice = _uiService.MainMenu();

                        switch (mainMenuItemChoice)
                        {
                            case 1:
                                _userService.UpdateActivityList(_currentUser.Id, _uiService.TrackActivity());

                                break;
                            case 2:
                                Console.Clear();
                                int accMenuChoice = _uiService.AccountMenu();

                                switch (accMenuChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter new First name:");
                                        _userService.ChangeFirstName(_currentUser.Id, Console.ReadLine());
                                        break;
                                    case 2:
                                        Console.WriteLine("Enter new Last name:");
                                        _userService.ChangeLastName(_currentUser.Id, Console.ReadLine());
                                        break;
                                    case 3:
                                        Console.WriteLine("Enter old password:");
                                        string oldPass = Console.ReadLine();
                                        Console.WriteLine("Enter new password:");
                                        string newPass = Console.ReadLine();
                                        _userService.ChangePassword(_currentUser.Id, oldPass, newPass);
                                        break;
                                    case 4:
                                        _userService.DeactivateAccount(_currentUser.Id);
                                        _currentUser = null;
                                        break;
                                    case 5:
                                        Console.Clear();
                                        break;
                                }
                                break;
                            case 3:
                                _userService.DisplayStats(_currentUser.Id, _uiService.StatsMenu());
                                break;
                            case 4:
                                MessageHelper.Color($"Thank you for using our app! Until next time {_currentUser.Username} :)", ConsoleColor.DarkCyan);
                                _currentUser = null;
                                MessageHelper.PressAnyKey();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        int loginChoice = _uiService.LoginRegisterMenu();
                        if (loginChoice == 1)
                        {
                            Console.WriteLine("Enter username:");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter password:");
                            string password = Console.ReadLine();

                            _currentUser = _userService.Login(username, password);
                            
                        }
                        else
                        {
                            _currentUser = _userService.Register(_uiService.RegisterMenu());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }



            Console.ReadLine();
        }
    }
}
