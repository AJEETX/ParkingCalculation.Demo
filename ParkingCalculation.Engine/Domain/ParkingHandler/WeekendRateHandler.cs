using System;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Handler
{
    interface IWeekendParkingRateHandler : IParkingRateHandler { }
    class WeekendRateHandler : ParkingRateHandler, IWeekendParkingRateHandler
    {
        TimeSpan entryCommenceTime = new TimeSpan(18, 00, 0), entryFinishTime = new TimeSpan(00, 00, 0); //
        TimeSpan exitCommenceTime = new TimeSpan(00, 00, 0), exitFinishTime = new TimeSpan(06, 00, 0); //
        Decimal WeekendParkingRate = 10;string weekendRateName = "Weekend Rate";
        RateType weekendType = RateType.WEEKEND;

        public override decimal ParkingRate { get { return WeekendParkingRate; } }
        public override string ParkingName { get { return weekendRateName; } }
        public override RateType RateType { get { return weekendType; } }

        public override IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime)
        {
            var parkingInOutDateAndTime = new ParkingInOutDateAndTime{
                EntryDateTime = entryDateAndTime,ExitDateTime = exitDateAndTime
            };
            var entryTimeFrame = new EntryTimeFrame{
                EntryCommenceTime = entryCommenceTime, EntryFinishTime = entryFinishTime
            };
            var exitTimeFrame = new ExitTimeFrame{
                ExitCommenceTime = exitCommenceTime, ExitFinishTime = exitFinishTime
            };
            var parkingInOutDateAndTimeDTO = new ParkingInOutDateAndTimeDTO{
                EntryTimeFrame = entryTimeFrame, ExitTimeFrame = exitTimeFrame, ParkingInOutDateAndTime = parkingInOutDateAndTime,
                ParkingRate = ParkingRate ,DaysOfWeek = Extension.WeekEnds
            }; return base.ProcessParkingRate(parkingInOutDateAndTimeDTO);
        }
    }
}
