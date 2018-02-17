using System;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Handler
{
    public class EarlyBirdRateHandler : ParkingRateHandler
    {
        TimeSpan entryCommenceTime = new TimeSpan(6, 30, 0), entryFinishTime = new TimeSpan(9, 30, 0); //
        TimeSpan exitCommenceTime = new TimeSpan(15, 30, 0), exitFinishTime = new TimeSpan(23, 30, 0); //
        Decimal EarlyBirdParkingRate = 13;string earlyBirdRateName = "Early Bird Rate";
        RateType earlyBirdType = RateType.EARLY;
        protected override decimal ParkingRate { get { return EarlyBirdParkingRate; } }

        protected override string ParkingName { get { return earlyBirdRateName; } }
        protected override RateType RateType { get { return earlyBirdType; } }

        public override IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime)
        {
            var parkingInOutDateAndTime = new ParkingInOutDateAndTime{ EntryDateTime=entryDateAndTime, ExitDateTime=exitDateAndTime
            };
            var entryTimeFrame = new EntryTimeFrame{
                EntryCommenceTime = entryCommenceTime, EntryFinishTime = entryFinishTime
            };
            var exitTimeFrame = new ExitTimeFrame{
                ExitCommenceTime = exitCommenceTime, ExitFinishTime = exitFinishTime
            };
            var parkingInOutDateAndTimeDTO = new ParkingInOutDateAndTimeDTO {
                EntryTimeFrame = entryTimeFrame,
                ExitTimeFrame = exitTimeFrame, ParkingInOutDateAndTime=parkingInOutDateAndTime, ParkingRate= ParkingRate, DaysOfWeek=Extension.Weekdays
            }; return base.ProcessParkingRate(parkingInOutDateAndTimeDTO);
        }
    }
}
