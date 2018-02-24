using System;
using ParkingCalculation.Engine.Model;
using System.Linq;
namespace ParkingCalculation.Engine.Handler
{
    interface IEarlyBirdIParkingRateHandler : IParkingRateHandler {  }

    class EarlyBirdRateHandler : ParkingRateHandler, IEarlyBirdIParkingRateHandler
    {
        TimeSpan entryCommenceTime = new TimeSpan(6, 30, 0), entryFinishTime = new TimeSpan(9, 30, 0); //
        TimeSpan exitCommenceTime = new TimeSpan(15, 30, 0), exitFinishTime = new TimeSpan(23, 30, 0); //
        Decimal EarlyBirdParkingRate = 13;string earlyBirdRateName = "Early Bird Rate";
        RateType earlyBirdType = RateType.EARLY;
        public override int Id { get { return 1; } }

        public override decimal ParkingRate { get { return EarlyBirdParkingRate; } set { EarlyBirdParkingRate = value; } }
        public override string ParkingName { get { return earlyBirdRateName; } }
        public override RateType RateType { get { return earlyBirdType; } }

        public override IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime)
        {
            var entryDay = entryDateAndTime.Date.DayOfWeek;
            var exitDay = exitDateAndTime.Date.DayOfWeek;

            var parkingInOutDateAndTime = new ParkingInOutDateAndTime{
                EntryDateTime = entryDateAndTime, ExitDateTime= exitDateAndTime
            };
            var entryTimeFrame = new EntryTimeFrame{
                EntryCommenceTime = entryCommenceTime, EntryFinishTime = entryFinishTime
            };
            var exitTimeFrame = new ExitTimeFrame{
                ExitCommenceTime = exitCommenceTime, ExitFinishTime = exitFinishTime
            };
            var parkingInOutDateAndTimeDTO = new ParkingInOutDateAndTimeDTO {
                EntryTimeFrame = entryTimeFrame, ExitTimeFrame = exitTimeFrame, ParkingInOutDateAndTime=parkingInOutDateAndTime, ParkingRate= ParkingRate,
                DaysOfWeek =Extension.Weekdays
            };

            if (Extension.Weekdays.Any(w => w.Equals(entryDay)) && Extension.Weekdays.Any(x => x.Equals(entryDay)) && exitDateAndTime.Subtract(entryDateAndTime).Days < 1)
            {
                parkingInOutDateAndTimeDTO.EntryExitConditionMet = true;
            }
            return base.ProcessParkingRate(parkingInOutDateAndTimeDTO);
        }
    }
}
