using System;
using ParkingCalculation.Engine.Model;
using System.Linq;
namespace ParkingCalculation.Engine.Handler
{
    interface IWeekendParkingRateHandler : IParkingRateHandler {  }
    class WeekendRateHandler : ParkingRateHandler, IWeekendParkingRateHandler
    {
        TimeSpan entryCommenceTime = new TimeSpan(00, 00, 0), entryFinishTime = new TimeSpan(23, 59, 59); //
        TimeSpan exitCommenceTime = new TimeSpan(00, 00, 0), exitFinishTime = new TimeSpan(23, 59, 59); //
        Decimal WeekendParkingRate = 10;string weekendRateName = "Weekend Rate";
        RateType weekendType = RateType.WEEKEND;
        public override int Id { get { return 3; } }

        public override decimal ParkingRate { get { return WeekendParkingRate; } set { WeekendParkingRate = value; } }
        public override string ParkingName { get { return weekendRateName; } }
        public override RateType RateType { get { return weekendType; } }

        public override IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime)
        {
            var entryDay = entryDateAndTime.Date.DayOfWeek;
            var exitDay = exitDateAndTime.Date.DayOfWeek;

            var parkingInOutDateAndTime = new ParkingInOutDateAndTime{
                EntryDateTime = entryDateAndTime,ExitDateTime = exitDateAndTime
            };
            var entryTimeFrame = new EntryTimeFrame{
                EntryCommenceTime = entryCommenceTime, EntryFinishTime = entryFinishTime
            };
            var exitTimeFrame = new ExitTimeFrame{
                ExitCommenceTime = exitCommenceTime, ExitFinishTime = exitFinishTime
            };

            ParkingRate = exitDateAndTime.Subtract(entryDateAndTime).TotalDays > 1? ParkingRate * 2:ParkingRate;

            var parkingInOutDateAndTimeDTO = new ParkingInOutDateAndTimeDTO {
                EntryTimeFrame = entryTimeFrame, ExitTimeFrame = exitTimeFrame, ParkingInOutDateAndTime = parkingInOutDateAndTime,
                ParkingRate = ParkingRate ,DaysOfWeek = Extension.WeekEnds,
                EntryExitConditionMet = false
            };

            if (Extension.WeekEnds.Any(w=>w.Equals(entryDay)) && Extension.WeekEnds.Any(x => x.Equals(exitDay)) && exitDateAndTime.Subtract(entryDateAndTime).Days<3){
                parkingInOutDateAndTimeDTO.EntryExitConditionMet = true;
            }
            return base.ProcessParkingRate(parkingInOutDateAndTimeDTO);
        }
    }
}
