using System;
using System.Collections.Generic;

namespace ParkingCalculation.Engine.Model
{
    public enum RateType { NONE,EARLY,STANDARD,NITE,WEEKEND}
    public interface IParkingInOutDateAndTime { DateTime EntryDateTime { get; set; } DateTime ExitDateTime { get; set; } }
    public class ParkingInOutDateAndTime : IParkingInOutDateAndTime { public DateTime EntryDateTime { get; set; } public DateTime ExitDateTime { get; set; } }
    public interface IParkingReceipt { string ParkingName { get; set; } Decimal ParkingPrice { get; set; } bool Erred { get; set; } RateType RateType { get; set; } }
    public class ParkingReceipt : IParkingReceipt
    {
        public string ParkingName { get ; set ; }
        public decimal ParkingPrice { get ; set ; }
        public bool Erred { get; set; }
        public RateType RateType { get; set; }
    }
    public class ParkingInOutDateAndTimeDTO
    {
        public IParkingInOutDateAndTime ParkingInOutDateAndTime { get; set; }
        public EntryTimeFrame EntryTimeFrame { get; set; }
        public ExitTimeFrame ExitTimeFrame { get; set; }
        public Decimal ParkingRate { get; set; }
        public IEnumerable<DayOfWeek> DaysOfWeek { get; set; }
        public bool EntryExitConditionMet { get; set; }
    }
    public class EntryTimeFrame
    {
        public TimeSpan EntryCommenceTime { get; set; }
        public TimeSpan EntryFinishTime { get; set; }
    }
    public class ExitTimeFrame
    {
        public TimeSpan ExitCommenceTime { get; set; }
        public TimeSpan ExitFinishTime { get; set; }
    }
}
