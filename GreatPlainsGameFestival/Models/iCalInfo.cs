using System;
using DDay.iCal;


namespace GreatPlainsGameFestival.Models
{
    public class iCalInfo
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Location { get; set; }
        public GeographicLocation Geo { get; set; }
        public string Url { get; set; }
    }
}