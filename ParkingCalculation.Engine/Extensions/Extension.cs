using System;
using System.Collections.Generic;
using System.Globalization;

namespace ParkingCalculation.Engine
{
    public static class Extension
    {
        const string entryFormat = @".\s+(?<inputDate>[0-9]{2}\\[0-9]{2}\\[0-9]{4}\s+[0-9]{2}\:[0-6]{2})",format = "d/M/yyyy H:m";
        public static List<DayOfWeek> Weekdays
        {
            get {
                return new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            }
        }
        public static List<DayOfWeek> WeekEnds
        {
            get {
                return new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
            }
        }
        public static bool TimeBetween(this DateTime dateTime, TimeSpan commenceTime, TimeSpan finishTime)
        {
            TimeSpan theTime = dateTime.TimeOfDay;
            if (commenceTime < finishTime) return commenceTime <= theTime && theTime <= finishTime;
            return !(finishTime < theTime && theTime < commenceTime);
        }
        public static DateTime DateValidated(this string strDate)
        {
            DateTime date;
            CultureInfo culture = CultureInfo.InvariantCulture; DateTimeStyles styles = DateTimeStyles.None;
            if (DateTime.TryParseExact(strDate, format, culture, styles, out date))
                return date;
            return date;
        }
    }
}
