using System;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Handler
{
    interface INiteParkingRateHandler : IParkingRateHandler { }
    class NiteRateHandler : ParkingRateHandler, INiteParkingRateHandler
    {
        TimeSpan entryCommenceTime = new TimeSpan(18, 00, 0), entryFinishTime = new TimeSpan(00, 00, 0); //
        TimeSpan exitCommenceTime = new TimeSpan(00, 00, 0), exitFinishTime = new TimeSpan(06, 00, 0); //
        Decimal NiteParkingRate = 6.50M; string niteRateName = "Nite Rate";
        RateType niteType = RateType.NITE;

        public override decimal ParkingRate { get { return NiteParkingRate; } }
        public override string ParkingName { get { return niteRateName; } }
        public override RateType RateType { get { return niteType; } }

        public override IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime)
        {
            var parkingInOutDateAndTime = new ParkingInOutDateAndTime {
                EntryDateTime = entryDateAndTime, ExitDateTime = exitDateAndTime
            };
            var entryTimeFrame = new EntryTimeFrame{
                EntryCommenceTime = entryCommenceTime, EntryFinishTime = entryFinishTime
            };
            var exitTimeFrame = new ExitTimeFrame{
                ExitCommenceTime = exitCommenceTime, ExitFinishTime = exitFinishTime
            };
            var parkingInOutDateAndTimeDTO = new ParkingInOutDateAndTimeDTO{
                EntryTimeFrame = entryTimeFrame, ExitTimeFrame = exitTimeFrame, ParkingInOutDateAndTime = parkingInOutDateAndTime, ParkingRate = ParkingRate
                ,DaysOfWeek = Extension.Weekdays
            }; return base.ProcessParkingRate(parkingInOutDateAndTimeDTO);
        }
    }
}
