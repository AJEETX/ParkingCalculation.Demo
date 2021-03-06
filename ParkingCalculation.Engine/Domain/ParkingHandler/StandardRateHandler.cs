﻿using System;
using ParkingCalculation.Engine.Model;

namespace ParkingCalculation.Engine.Handler
{
    interface IStandardParkingRateHandler : IParkingRateHandler { }
    class StandardRateHandler : ParkingRateHandler, IStandardParkingRateHandler
    {
        Decimal StandardParkingRate = 20;string standardRateName = "Standard Rate"; Decimal price = 0;
        RateType standardType = RateType.STANDARD;
        public override int Id { get {return 4; } }
        public override decimal ParkingRate { get { return StandardParkingRate; } set { StandardParkingRate = value; } }
        public override string ParkingName{ get { return standardRateName; }}
        public override RateType RateType { get { return standardType; } }

        public override IParkingReceipt GetParkingCharges(DateTime entryDateAndTime, DateTime exitDateAndTime)
        {
            var timeSpan = exitDateAndTime.Subtract(entryDateAndTime);
            if (timeSpan.Days > 0){
                price = StandardParkingRate * timeSpan.Days;
            }
            
            if (timeSpan.Hours > 3 && timeSpan.Hours <= 24)            {
                price = price + ParkingRate;
                return new ParkingReceipt { ParkingName = standardRateName, ParkingPrice = price, RateType = standardType };
            }
            if((timeSpan.Hours > 2 && timeSpan.Hours <= 3))  price = price + 15;
            if (timeSpan.Hours > 1 && timeSpan.Hours <= 2)  price = price + 10;
            if (timeSpan.Hours > 0 && timeSpan.Hours <= 1)  price = price + 5;
            if (timeSpan.Minutes > 0 && timeSpan.Minutes <= 59)  price = price + 5;
            return new ParkingReceipt { ParkingName=standardRateName, ParkingPrice=price, RateType=standardType };
        }
    }
}
