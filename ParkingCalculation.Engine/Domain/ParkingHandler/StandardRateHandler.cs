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
            double remainedHours = 0;
            var timeSpan = exitDateAndTime.Subtract(entryDateAndTime);
            if (timeSpan.Days > 0)
                price= StandardParkingRate * timeSpan.Days;
            if(timeSpan.Minutes<60)
                remainedHours = 1;
            remainedHours = timeSpan.TotalHours;
            if (remainedHours > 3 && remainedHours <= 24)  price=price+ParkingRate;
            if (remainedHours > 2 && remainedHours <= 3)  price = price + 15;
            if (remainedHours > 1 && remainedHours <= 2)  price = price + 10;
            if (remainedHours > 0 && remainedHours <= 1)  price = price + 5;
            return new ParkingReceipt { ParkingName=standardRateName, ParkingPrice=price };
        }
    }
}
