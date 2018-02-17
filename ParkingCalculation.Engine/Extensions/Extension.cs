using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingCalculation.Engine
{
    public static class Extension
    {
        const string entryFormat = @".\s+(?<inputDate>[0-9]{2}\\[0-9]{2}\\[0-9]{4}\s+[0-9]{2}\:[0-6]{2})";
        public static List<DayOfWeek> Weekdays
        {
            get
            {
                return new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            }
        }
        public static List<DayOfWeek> WeekEnds
        {
            get
            {
                return new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
            }
        }
        public static bool TimeBetween(this DateTime dateTime, TimeSpan commenceTime, TimeSpan finishTime)
        {
            TimeSpan theTime = dateTime.TimeOfDay;
            if (commenceTime < finishTime) return commenceTime <= theTime && theTime <= finishTime;
            return !(finishTime < theTime && theTime < commenceTime);
        }
        public static DateTime ValidFormat(this string time)
        {
            string format = "d/M/yyyy H:m";
            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTimeStyles styles = DateTimeStyles.None; DateTime timeOutput;
            bool dateIsValid = DateTime.TryParseExact(time, format, culture, styles, out timeOutput);

            return (dateIsValid)?timeOutput:DateTime.MinValue;
        }
        public static bool DateIsValid(this string time)
        {
            string format = "d/M/yyyy H:m";bool valid = true;
            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTimeStyles styles = DateTimeStyles.None; DateTime timeOutput;
            return valid=DateTime.TryParseExact(time, format, culture, styles, out timeOutput);
        }
    }
}
