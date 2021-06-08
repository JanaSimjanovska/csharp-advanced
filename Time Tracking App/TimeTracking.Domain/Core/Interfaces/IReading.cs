using System;
using System.Collections.Generic;
using System.Text;
using TimeTracking.Domain.Core.Enums;

namespace TimeTracking.Domain.Core.Interfaces
{
    public interface IReading
    {

        string Title { get; set; }

        string Author { get; set; }

        TypeOfLiterature LiteratureType { get; set; }

        int Pages { get; set; }

    }
}
