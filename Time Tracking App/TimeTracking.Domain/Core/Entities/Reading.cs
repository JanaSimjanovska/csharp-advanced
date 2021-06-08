using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Enums;
using TimeTracking.Domain.Core.Interfaces;

namespace TimeTracking.Domain.Core.Entities
{
    public class Reading : Activity, IReading
    {
        public TypeOfLiterature LiteratureType { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        public Reading()
        {
        }

        public Reading(TimeSpan duration, TypeOfLiterature literatureType, string title, string author, int pages) : base(duration)
        {
            Type = TypeOfActivity.Reading;
            Title = title;
            Author = author;
            Pages = pages;
            LiteratureType = literatureType;

        }
        public override string Print()
        {
            string elapsedTime = String.Format("{0:00} hours {1:00} minutes {2:00} seconds", (int)Duration.TotalHours, (int)Duration.TotalMinutes, (int)Duration.TotalSeconds);

            return $"\nType of activity: {Type}\n" +
                $"Type of literature: {LiteratureType}\n" +
                $"Title: \"{Title}\" by {Author}\n" +
                $"Number of pages: {Pages}\n" +
                $"Duration: {elapsedTime}";
        }
    }
}
