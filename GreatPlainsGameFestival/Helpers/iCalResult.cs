using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using GreatPlainsGameFestival.Models;

namespace GreatPlainsGameFestival.Helpers
{
    class iCalResult : FileResult
    {
        private iCalInfo _info;

        public iCalResult(string filename)
            : base("text/calendar")
        {
            this.FileDownloadName = filename;
        }

        public iCalResult(iCalInfo info, string filename)
            : this(filename)
        {
            _info = info;
        }

        protected override void WriteFile(System.Web.HttpResponseBase response)
        {
            iCalendar iCal = new iCalendar();

            var evnt = iCal.Create<Event>();

            evnt.Summary = _info.Name;
            evnt.Start = new iCalDateTime(_info.StartDate);
            evnt.Duration = _info.Duration;
            evnt.GeographicLocation = _info.Geo;
            evnt.Location = _info.Location;
            evnt.Url = new Uri(_info.Url);
                           
            //iCal.Events.Add(evnt);

            var ser = new iCalendarSerializer();
            string result = ser.SerializeToString(iCal);
            //iCalendarSerializer serializer = new iCalendarSerializer(iCal);
            //string result = serializer.SerializeToString();
            response.ContentEncoding = Encoding.UTF8;
            response.Write(result);
        }

    }
}