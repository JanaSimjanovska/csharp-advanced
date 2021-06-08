using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Entities;
using TimeTracking.Domain.Core.Interfaces;

namespace TimeTracking.Services.Services.Interfaces
{
    public interface IUIService
    {
        List<string> LoginRegisterMenuItems { get; set; }
        List<string> MainMenuItems { get; set; }
        List<string> TrackActivityMenuItems { get; set; }
        List<string> AccountMenuItems { get; set; }
        List<string> UserStatisticsMenuItems { get; set; }
        List<string> BookGenreMenuItems { get; set; }
        List<string> TypeOfHobbyMenuItems { get; set; }
        List<string> TypeOfExerciseMenuItems { get; set; }
        List<string> WorkplaceMenuItems { get; set; }


        int MainMenu();
        int AccountMenu();
        int TrackActivityMenu();
        Activity TrackActivity();
        int ChooseMenu<T>(List<T> items);
        int LoginRegisterMenu();
        User RegisterMenu();
        int StatsMenu();
    }
}
