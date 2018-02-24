using System;
using System.Linq;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Handler
{
    interface IParkingRateHandler
    {
        int Id { get; }
        Decimal ParkingRate { get; set; }
        string ParkingName { get; }
        RateType RateType { get; }
        void SetNextHandler(IParkingRateHandler nextHandler);
        IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime);
        IParkingReceipt ProcessParkingRate(ParkingInOutDateAndTimeDTO inOutTimeDTO);
    }
    abstract class ParkingRateHandler: IParkingRateHandler
    {
        protected IParkingRateHandler _nextRateHandler;
        public abstract int Id { get; }
        public abstract Decimal ParkingRate { get; set; }
        public abstract string ParkingName { get; }
        public abstract RateType RateType { get; }
        public abstract IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime);
        public virtual void SetNextHandler(IParkingRateHandler nextHandler) { _nextRateHandler = nextHandler; }
        public virtual IParkingReceipt ProcessParkingRate(ParkingInOutDateAndTimeDTO inOutTimeDTO)
        {
            if (_nextRateHandler == null) return null;

            var timeInOut = inOutTimeDTO.ParkingInOutDateAndTime;

            var entryTimeCondition = timeInOut.EntryDateTime.TimeBetween(inOutTimeDTO.EntryTimeFrame.EntryCommenceTime, inOutTimeDTO.EntryTimeFrame.EntryFinishTime);
            var exitTimeCondition = timeInOut.ExitDateTime.TimeBetween(inOutTimeDTO.ExitTimeFrame.ExitCommenceTime, inOutTimeDTO.ExitTimeFrame.ExitFinishTime);

            if (inOutTimeDTO.EntryExitConditionMet && entryTimeCondition && exitTimeCondition) {
                return new ParkingReceipt { ParkingName = ParkingName, ParkingPrice = ParkingRate, Erred=false, RateType=RateType } ;
            }
            else{
                return _nextRateHandler.GetParkingCharges(timeInOut.EntryDateTime,timeInOut.ExitDateTime);
            }
        }
    }
}
