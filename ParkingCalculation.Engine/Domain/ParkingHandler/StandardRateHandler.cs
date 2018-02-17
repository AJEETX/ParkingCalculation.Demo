using System;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Handler
{
    public class XandardRateHandler : ParkingRateHandler
    {
        Decimal StandardParkingRate = 20;string standardRateName = "Standard Rate"; Decimal price = 0;
        RateType standardType = RateType.STANDARD;

        protected override decimal ParkingRate { get { return StandardParkingRate; } }

        protected override string ParkingName{ get { return standardRateName; }}
        protected override RateType RateType { get { return standardType; } }

        public override IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime)
        {
            var timeSpan = exitDateAndTime.Subtract(entryDateAndTime);
            if (timeSpan.Days > 0)
            {
                price = StandardParkingRate * timeSpan.Days;
            }
            
            if (timeSpan.Hours > 3 && timeSpan.Hours <= 24)  price=price+ParkingRate;
            if (timeSpan.Hours > 2 && timeSpan.Hours <= 3)  price = price + 15;
            if (timeSpan.Hours > 1 && timeSpan.Hours <= 2)  price = price + 10;
            if (timeSpan.Minutes > 0 && timeSpan.Minutes <= 59)  price = price + 5;
            return new ParkingReceipt { ParkingName=standardRateName, ParkingPrice=price, RateType=standardType };
        }
    }
}
