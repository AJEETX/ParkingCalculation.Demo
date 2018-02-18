using System;
using System.Linq;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Handler
{
    abstract class ParkingRateHandler
    {
        protected ParkingRateHandler _nextRateHandler;
        protected abstract Decimal ParkingRate { get;  }
        protected abstract string ParkingName { get; }
        protected abstract RateType RateType { get; }
        public abstract IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime);
        public void SetNextHandler(ParkingRateHandler nextHandler) { _nextRateHandler = nextHandler; }
        protected virtual IParkingReceipt ProcessParkingRate(ParkingInOutDateAndTimeDTO inOutTimeDTO)
        {
            if (_nextRateHandler == null) return null;

            var timeInOut = inOutTimeDTO.ParkingInOutDateAndTime;

            var entryDay = timeInOut.EntryDateTime.Date.DayOfWeek;
            var exitDay = timeInOut.ExitDateTime.Date.DayOfWeek;

            var entryTimeCondition = timeInOut.EntryDateTime.TimeBetween(inOutTimeDTO.EntryTimeFrame.EntryCommenceTime, inOutTimeDTO.EntryTimeFrame.EntryFinishTime);
            var exitTimeCondition = timeInOut.ExitDateTime.TimeBetween(inOutTimeDTO.ExitTimeFrame.ExitCommenceTime, inOutTimeDTO.ExitTimeFrame.ExitFinishTime);

            var entryDayCondition = inOutTimeDTO.DaysOfWeek.Any(w => w.Equals(entryDay));
            var exitDayCondition = inOutTimeDTO.DaysOfWeek.Any(w => w.Equals(exitDay));
            var lessThan24Hr = timeInOut.ExitDateTime.Subtract(timeInOut.EntryDateTime).Days < 1;

            if (entryDayCondition && exitDayCondition && lessThan24Hr && entryTimeCondition && exitTimeCondition) {
                return new ParkingReceipt { ParkingName = ParkingName, ParkingPrice = ParkingRate, Erred=false, RateType=RateType } ;
            }
            else{
                return _nextRateHandler.GetParkingCharges(timeInOut.EntryDateTime,timeInOut.ExitDateTime);
            }
        }
    }
}
